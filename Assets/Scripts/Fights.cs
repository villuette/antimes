using System.Collections;
using UnityEngine;

public class Fights : MonoBehaviour
{
    private bool attack = false;
    private int GG_health = Stats.GG_Health;
    private int GG_damage = Stats.GG_Damage;
    private float GG_armor = Stats.GG_Armor;
    private int Enemy_Health;
    private int Enemy_Damage;
    
    void Start()
    {
        Stats_Enemy enemy = gameObject.AddComponent<Stats_Enemy>();
        Enemy_Health = enemy.Enemy_Health;
        Enemy_Damage = enemy.Enemy_Damage;
    }

    void Update()
    {
        
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
            StopCoroutine(FightCoroutine());
        }
    }
    IEnumerator FightCoroutine()
    {
        while (attack)
        {
            yield return new WaitForSeconds(2f);
            GG_health -= (int)((1 - GG_armor) * Enemy_Damage);
            Enemy_Health -= GG_damage;
            Debug.Log("GG: " + GG_health);
            Debug.Log("Enemy: " + Enemy_Health);
            if (GG_health <= 0)
            {
                Destroy(gameObject);
                attack = false;
            }
            if (Enemy_Health <= 0)
            {
                Destroy(gameObject);
                attack = false;
            }
        }
    }
}
