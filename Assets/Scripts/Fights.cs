using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Fights : MonoBehaviour
{
    private bool switch_attack = true;
    private int Enemy_Health;
    private int Enemy_Damage;
    private int Eneme_lvl;
    float FullTime = 2.0f, currTime = 0.0f;
    private float coord_x, coord_y, gg_coord_x;
    [SerializeField] private Text enemy_hp;
    [SerializeField] private Text earnedExp;
    bool showExp = false;
    float currTimeE = 0.0f;
    float FullTimeE = 3.0f;
    float scaleE = 0.2f;
    float invisabilityE = 0.0f;
    int expPerMob;

    public static float _game_speed = 3;
    [SerializeField] private Text dealed_dmg;
    float scale = 0.2f;
    bool ispersonbeat, isenemybeat;
    int dmg_dealt;
    bool show;
    float invisability = 0.0f;
    Animator anim_gg, anim_enemy;
    GameObject gg_obj;
    bool dead = false;
    public float margin = 0.4f;
    float dealt_offset = 0.1f;

    HealthSystem healthSystem;

    void Start()
    {
        healthSystem = GameObject.Find("HPLogic").GetComponent<HealthSystem>();
        earnedExp.color = Color.green;
        earnedExp = GameObject.Find("collectExp").GetComponent<Text>();
        Stats_Enemy enemy = gameObject.AddComponent<Stats_Enemy>();
        Enemy_Health = enemy.Enemy_Health;
        Enemy_Damage = enemy.Enemy_Damage;
        Eneme_lvl = enemy.Enemy_lvl;
        anim_gg = GameObject.Find("GG").GetComponent<Animator>();
        anim_enemy = GetComponent<Animator>();
        gg_obj = GameObject.Find("GG");
        anim_gg.speed = _game_speed / 2;
        anim_enemy.speed = _game_speed / 2;
    }
    private void ShowExpEarned()
    {         
        
        earnedExp.text = Convert.ToString(expPerMob);
        if (FullTimeE >= currTimeE)
        {
            earnedExp.color = new Color(0, 1, 0, 1 - invisabilityE);
            if (invisabilityE < 1)
                invisabilityE += 0.03f;
            currTimeE += Time.deltaTime;
            float coord_xE = Stats.GG.transform.position.x;
            float coord_yE = Stats.GG.transform.position.y + scaleE;
            earnedExp.transform.position = new Vector2(coord_xE, coord_yE);
            scaleE += 0.01f;
        }
        else
        {
            earnedExp.text = null;
            currTimeE = 0.0f;
            scaleE = 0.2f;
            showExp = false;
            invisabilityE = 0.0f;
        }
    }
    private void FixedUpdate()
    {
        DealedDMGShow();
        if (showExp)
            ShowExpEarned();
    }
    void RotateGG()
    {

        if (gg_obj.transform.position.x < transform.position.x)
        {
            gg_obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            dealt_offset = Math.Abs(dealt_offset) * -1;
        }
        else
        {
            gg_obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
            dealt_offset = Math.Abs(dealt_offset);
        }
    }
    void DealedDMGShow()
    {
        if (show)
        {
            if (ispersonbeat)
            {
                dealed_dmg.color = Color.white;
                dealed_dmg.text = null;
                dealed_dmg.text = "-" + Convert.ToString(dmg_dealt);
                if (FullTime >= currTime)
                {
                    dealed_dmg.color = new Color(1, 1, 1, 1 - invisability);
                    if (invisability < 1)
                        invisability += 0.03f;
                    currTime += Time.deltaTime;
                    coord_x = (transform.position.x + Stats.GG.transform.position.x) / 2.0f;
                    coord_y = transform.position.y + scale;
                    dealed_dmg.transform.position = new Vector2(coord_x - dealt_offset, coord_y);
                    scale += 0.01f;
                }
                else
                {
                    dealed_dmg.text = null;
                    currTime = 0f;
                    scale = 0.2f;
                    show = false;
                    invisability = 0.0f;
                }
            }
        }
        if (isenemybeat)
        {
            dealed_dmg.text = null;
            dealed_dmg.text = "-" + Convert.ToString(dmg_dealt);
            if (FullTime >= currTime)
            {
                dealed_dmg.color = new Color(1, 0, 0, 1 - invisability);
                if (invisability < 1)
                    invisability += 0.03f;
                currTime += Time.deltaTime;
                coord_x = (transform.position.x + Stats.GG.transform.position.x) / 2.0f;
                coord_y = transform.position.y + scale;
                dealed_dmg.transform.position = new Vector2(coord_x + dealt_offset, coord_y);
                scale += 0.01f;
            }
            else
            {
                dealed_dmg.text = null;
                currTime = 0f;
                scale = 0.2f;
                show = false;
                invisability = 0.0f;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GG_Moving.CanDoLaddering = false;
            GG_Moving.canMove = false;
            anim_gg.SetInteger("is_running", 0);
            BoxCollider2D thiscol = GetComponent<BoxCollider2D>();
            margin = thiscol.size.x / 2.0f;
            EnemyRotate();
            RotateGG();
            GG_Moving.canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            anim_gg.SetInteger("is_running", 0);
            if (collision.gameObject.transform.position.x < transform.position.x)
                collision.gameObject.transform.position = new Vector3(transform.position.x - margin, transform.position.y);
            else
                collision.gameObject.transform.position = new Vector3(transform.position.x + margin, transform.position.y);
            anim_gg.SetBool("is_laddering", false); //if person contacts while laddering
            anim_gg.SetTrigger("interrupts");              
            StartCoroutine(FightCoroutine());


        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GG_Moving.CanDoLaddering = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy_hp.text = null;
            GG_Moving.CanDoLaddering = true;
            GG_Moving.canMove = true;
            StopCoroutine(FightCoroutine());
        }
    }

    // Разворачивает моба если он находится справа
    private void EnemyRotate()
    {
        gg_coord_x = gg_obj.transform.position.x;
        coord_x = transform.position.x;
        if (gg_coord_x < coord_x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    // Выводит над мобами их хп
    private void ShowEnemyHp()
    {

        // Получает координаты моба
        coord_x = transform.position.x;
        coord_y = transform.position.y + 0.3f;
        // Присваивает координаты моба к тексту
        enemy_hp.transform.position = new Vector2(coord_x, coord_y);
        enemy_hp.text = "[lvl " + Eneme_lvl + "]" + "\n" + Enemy_Health + "\u2764";

    }
    IEnumerator FightCoroutine()
    {

        //GG_Moving.canMove = false;
        while (true)
        {
            if (dead)
            {
                Stats.GG_Death();
                StopCoroutine("FightCoroutine");
                GG_Moving.CanDoLaddering = true;
                break;
            }
            else //first the person, last the enemy
            {
                if (switch_attack)
                {
                    anim_gg.SetTrigger("is_fights_1");
                    switch_attack = false;
                }
                else
                {
                    anim_gg.SetTrigger("is_fights_2");
                    switch_attack = true;
                }
                anim_enemy.SetTrigger("interrupts");
                anim_enemy.SetTrigger("is_enemy_hide");



            }
            Debug.Log("GG: " + Stats.GG_Health);


            yield return new WaitForSeconds(1 / _game_speed);

            dmg_dealt = (int)UnityEngine.Random.Range(Stats.GG_Damage - Stats.GG_Damage/4f, Stats.GG_Damage + Stats.GG_Damage/4f); //damage, dealt to enemy
            ispersonbeat = true;
            isenemybeat = false;
            currTime = 0f;
            scale = 0.2f;
            invisability = 0.0f;
            show = true;
            Enemy_Health -= dmg_dealt; //deal damage
            ShowEnemyHp();
            if (Enemy_Health <= 0)
            {
                expPerMob = UnityEngine.Random.Range(5, 20);
                Stats.GG_UExperience += expPerMob;
                Stats.ShowExp();
                showExp = true;               
                enemy_hp.text = null;
                anim_gg.SetTrigger("interrupts");
                anim_enemy.Play("enemy_death");
                ispersonbeat = false; isenemybeat = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GG_Moving.CanDoLaddering = true;
                GG_Moving.canMove = true;
                StopCoroutine(nameof(FightCoroutine));
                Destroy(gameObject, 1f);
                break;
            }

            yield return new WaitForSeconds(1 / _game_speed);

            anim_gg.SetTrigger("interrupts");
            anim_enemy.SetTrigger("is_fights");
            //anim_gg.SetTrigger("interrupts");
            anim_gg.SetTrigger("is_hide");

            yield return new WaitForSeconds(1 / _game_speed);

            dmg_dealt = (int)((1 - Stats.GG_Armor) * Enemy_Damage); //damage, dealt to gg
            isenemybeat = true;
            ispersonbeat = false;
            healthSystem.InstanceHP(); //render hpbar after damage
            currTime = 0f;
            scale = 0.2f;
            invisability = 0.0f;
            show = true;
            Stats.GG_Health -= dmg_dealt;

            if (Stats.GG_Health <= 0)
            {
                anim_gg.Play("gg_death");
                anim_enemy.SetTrigger("interrupts");
                //anim_enemy.SetInteger("is_enemy_hide", 0);
                ispersonbeat = false; isenemybeat = false;
                dead = true;
            }
            yield return new WaitForSeconds(1 / _game_speed);

        }
    }
}
