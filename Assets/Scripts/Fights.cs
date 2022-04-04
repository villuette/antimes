using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fights : MonoBehaviour
{
    private bool attack = false;
    private int Enemy_Health;
    private int Enemy_Damage;
    public float coord_x, coord_y;
    [SerializeField] private Text enemy_hp;
    Animator anim_gg, anim_enemy;

    void Start()
    {
        Stats_Enemy enemy = gameObject.AddComponent<Stats_Enemy>();
        Enemy_Health = enemy.Enemy_Health;
        Enemy_Damage = enemy.Enemy_Damage;
        anim_gg = GameObject.Find("GG").GetComponent<Animator>();
        anim_enemy = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        ShowEnemyHp();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attack = true;
            anim_gg.SetInteger("is_fights_1", 1);
            anim_enemy.SetInteger("is_fights_enemy", 1);
            StartCoroutine(FightCoroutine());
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attack = false;
            enemy_hp.text = null;
            anim_gg.SetInteger("is_fights_1", 0);
            anim_enemy.SetInteger("is_fights_enemy", 0);
            StopCoroutine(FightCoroutine());
        }
    }

    // Выводит над мобами их хп
    private void ShowEnemyHp()
    {
        if (attack)
        {
            // Получает координаты моба
            coord_x = transform.position.x;
            coord_y = transform.position.y + 0.2f;
            // Присваивает координаты моба к тексту
            enemy_hp.transform.position = new Vector2(coord_x, coord_y);
            enemy_hp.text = Enemy_Health + "\u2764";
        }
    }
    IEnumerator FightCoroutine()
    {
        while (attack)
        {
            yield return new WaitForSeconds(0.5f);
            Stats.GG_Health -= (int)((1 - Stats.GG_Armor) * Enemy_Damage);
            Enemy_Health -= Stats.GG_Damage;
            Debug.Log("GG: " + Stats.GG_Health);
            if (Stats.GG_Health <= 0)
            {
                Destroy(GameObject.Find("GG"));
                attack = false;
            }
            if (Enemy_Health <= 0)
            {
                Destroy(gameObject);
                attack = false;
                enemy_hp.text = null;
               
            }
        }
    }
}
