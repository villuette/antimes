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

    void Start()
    {
        Stats_Enemy enemy = gameObject.AddComponent<Stats_Enemy>();
        Enemy_Health = enemy.Enemy_Health;
        Enemy_Damage = enemy.Enemy_Damage;
    }
    private void Update()
    {
        ShowEnemyHp();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = true;
            StartCoroutine(FightCoroutine());
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = false;
            enemy_hp.text = null;
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
            yield return new WaitForSeconds(1f);
            Stats.GG_Health -= (int)((1 - Stats.GG_Armor) * Enemy_Damage);
            Enemy_Health -= Stats.GG_Damage;
            Debug.Log("GG: " + Stats.GG_Health);
            if (Stats.GG_Health <= 0)
            {
                Destroy(gameObject);
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
