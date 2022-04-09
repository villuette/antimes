using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fights : MonoBehaviour
{
    private bool attack = false;
    private bool gg_attack = true;
    private int Enemy_Health;
    private int Enemy_Damage;
    private int Eneme_lvl;
    private float coord_x, coord_y, gg_coord_x;
    [SerializeField] private Text enemy_hp;
    Animator anim_gg, anim_enemy;
    GameObject gg_obj;
   

    void Start()
    {
        Stats_Enemy enemy = gameObject.AddComponent<Stats_Enemy>();
        Enemy_Health = enemy.Enemy_Health;
        Enemy_Damage = enemy.Enemy_Damage;
        Eneme_lvl = enemy.Enemy_lvl;
        anim_gg = GameObject.Find("GG").GetComponent<Animator>();
        anim_enemy = GetComponent<Animator>();
        gg_obj = GameObject.Find("GG");
    }
    private void FixedUpdate()
    {
        ShowEnemyHp();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemyRotate();
            attack = true;
            anim_gg.SetInteger("is_running", 0);
            GG_Moving.canMove = false;
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
            anim_gg.SetInteger("is_hide", 0);
            anim_gg.SetInteger("is_running", 1);
            anim_enemy.SetInteger("is_fights_enemy", 0);
            anim_enemy.SetInteger("is_enemy_hide", 0);
            GG_Moving.canMove = true;
            StopCoroutine(FightCoroutine());
        }
    }

    // Разворачивает моба если он находится справа
    private void EnemyRotate()
    {
        gg_coord_x = gg_obj.transform.position.x;
        coord_x = transform.position.x;
        if(gg_coord_x < coord_x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    // Выводит над мобами их хп
    private void ShowEnemyHp()
    {
        if (attack)
        {
            // Получает координаты моба
            coord_x = transform.position.x;
            coord_y = transform.position.y + 0.3f;
            // Присваивает координаты моба к тексту
            enemy_hp.transform.position = new Vector2(coord_x, coord_y);
            enemy_hp.text = "lvl " + Eneme_lvl + "\n" + Enemy_Health + "\u2764";
        }
    }
    private void WhoIsAttacking()
    {
        if(gg_attack)
        {
            Stats.GG_Health -= (int)((1 - Stats.GG_Armor) * Enemy_Damage);
            anim_enemy.SetInteger("is_fights_enemy", 0);
            anim_enemy.SetInteger("is_enemy_hide", 1);
            anim_gg.SetInteger("is_fights_1", 1);
            anim_gg.SetInteger("is_hide", 0);
            gg_attack = false;
        } 
        else
        {
            Enemy_Health -= Stats.GG_Damage;
            anim_enemy.SetInteger("is_fights_enemy", 1);
            anim_enemy.SetInteger("is_enemy_hide", 0);
            anim_gg.SetInteger("is_fights_1", 0);
            anim_gg.SetInteger("is_hide", 1);
            gg_attack = true;
        }
    }
    IEnumerator FightCoroutine()
    {
        while (attack)
        {
            yield return new WaitForSeconds(1f);
            WhoIsAttacking();
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
