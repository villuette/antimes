using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forDownLadderScr : MonoBehaviour
{
    BoxCollider2D ggcol;
    BoxCollider2D chestcol;
    BoxCollider2D thiscol;
    public int earnedMoney;
    public int minMoneyEarned, maxMoneyEarned;
    [SerializeField] public bool show_coins_wchest = false;
    [SerializeField] public bool show_coins_gchest = false;
    [SerializeField] private float scale = 0.2f;
    [SerializeField] private float coinsTime = 0.0f;
    [SerializeField] private float showCoinsTime = 3f;
    [SerializeField] public float coord_x, coord_y;
    [SerializeField] private Text text_coins;
    public float coin_margin;
    float invisability = 0.0f;


    Gen_Coins gen_coins;
    public GameObject gen_coins_obj; //скрипт gen_coins привязан к пустому объекту на сцене

    void Start()
    {
        gen_coins = gen_coins_obj.GetComponent<Gen_Coins>();
        ggcol = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        thiscol = GetComponent<BoxCollider2D>();

    }
    void FixedUpdate()
    {
        ShowCoins();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ggcol.isTrigger = false;
            GG_Moving.canMove = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wchest"))
        {
            //scr for money up////
            coinsTime = 0;
            earnedMoney = UnityEngine.Random.Range(minMoneyEarned, maxMoneyEarned);
            Stats.GG_UGold += earnedMoney;
            Stats.ShowCoins();
            chestcol = collision.GetComponent<BoxCollider2D>();
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.enabled = false;
            show_coins_wchest = true;
            if (show_coins_gchest || show_coins_wchest) //небольшой фикс при открытии
            {
                scale = 0.2f;
                Destroy(gen_coins.generated_coins);
                gen_coins.CreateCoin();
                coinsTime = 0;
                invisability = 0.0f;
                show_coins_gchest = false;
            }
            else
                gen_coins.CreateCoin();
        }
        if (collision.CompareTag("gchest"))
        {
            coinsTime = 0;
            earnedMoney = UnityEngine.Random.Range(minMoneyEarned, maxMoneyEarned) * 10;
            Stats.GG_UGold += earnedMoney;
            Stats.ShowCoins();
            chestcol = collision.GetComponent<BoxCollider2D>();
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.enabled = false;
            show_coins_gchest = true;

            if (show_coins_wchest || show_coins_gchest)
            {
                show_coins_wchest = false;
                Destroy(gen_coins.generated_coins);
                gen_coins.CreateCoin();
                coinsTime = 0;
                invisability = 0.0f;
                scale = 0.2f;
            }
            else gen_coins.CreateCoin();
        }
        //if (collision.CompareTag("ground"))
        //    GG_Moving.canMove = true;
    }
    private void ShowCoins()
    {
        if (show_coins_wchest)
        {
            text_coins.text = Convert.ToString(earnedMoney);
            if (showCoinsTime >= coinsTime)
            {
                text_coins.color = new Color(1, 0.92f, 0.016f, 1 - invisability);
                gen_coins.generated_coins.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - invisability);
                if (invisability < 1)
                    invisability += 0.03f;
                coinsTime += Time.deltaTime;
                coord_x = chestcol.gameObject.transform.position.x;
                coord_y = chestcol.transform.position.y + scale;
                text_coins.transform.position = new Vector2(coord_x, coord_y);
                gen_coins.generated_coins.transform.position = new Vector2(coord_x + coin_margin, coord_y);
                scale += 0.01f;
            }
            else
            {
                text_coins.text = null;
                Destroy(gen_coins.generated_coins);
                coinsTime = 0f;
                scale = 0.2f;
                invisability = 0.0f;
                show_coins_wchest = false;

            }
        }
        if (show_coins_gchest)
        {
            text_coins.text = Convert.ToString(earnedMoney);
            if (showCoinsTime >= coinsTime)
            {
                text_coins.color = new Color(1, 0.92f, 0.016f, 1 - invisability);
                gen_coins.generated_coins.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - invisability);
                if (invisability < 1)
                    invisability += 0.03f;
                coinsTime += Time.deltaTime;
                coord_x = chestcol.transform.position.x;
                coord_y = chestcol.transform.position.y + scale;
                text_coins.transform.position = new Vector2(coord_x, coord_y);
                gen_coins.generated_coins.transform.position = new Vector2(coord_x + coin_margin, coord_y);
                scale += 0.01f;
            }
            else
            {
                text_coins.text = null;
                Destroy(gen_coins.generated_coins);
                coinsTime = 0f;
                scale = 0.2f;
                invisability = 0.0f;
                show_coins_gchest = false;

            }
        }
    }
}
