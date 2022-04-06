using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forDownLadderScr : MonoBehaviour
{
    Collider2D ggcol;
    Collider2D chestcol;
    Collider2D thiscol;
    public int earnedMoney;
    public int minMoneyEarned, maxMoneyEarned;
    [SerializeField] public bool show_coins_wchest = false;
    [SerializeField] public bool show_coins_gchest = false;
    [SerializeField] private float scale = 0.2f;
    [SerializeField] private float coinsTime = 0.0f;
    [SerializeField] private float showCoinsTime = 3f;
    [SerializeField] public float coord_x, coord_y;
    [SerializeField] private Text text_coins;
    // Start is called before the first frame update

    void Start()
    {
        ggcol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();  
        thiscol = GetComponent<Collider2D>();
        //thiscol.enabled = false;
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
            //thiscol.enabled = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wchest"))
        {
            //scr for money up////
            earnedMoney = UnityEngine.Random.Range(minMoneyEarned, maxMoneyEarned);
            Stats.GG_CurrGold += earnedMoney;
            chestcol = collision.GetComponent<Collider2D>();
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.enabled = false;
            show_coins_wchest = true;
        }
        if (collision.CompareTag("gchest"))
        {
            earnedMoney = UnityEngine.Random.Range(minMoneyEarned, maxMoneyEarned) * 10;
            Stats.GG_CurrGold += earnedMoney;
            chestcol = collision.GetComponent<Collider2D>();
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.enabled = false;
            show_coins_gchest = true;
        }
    }
    private void ShowCoins()
    {
        if (show_coins_wchest)
        {
            show_coins_gchest = false;
           
            text_coins.text = earnedMoney + " \u267F";
            if (showCoinsTime >= coinsTime)
            {
                coinsTime += Time.deltaTime;
                coord_x = chestcol.transform.position.x;
                coord_y = chestcol.transform.position.y + scale;
                text_coins.transform.position = new Vector2(coord_x, coord_y);
                scale += 0.01f;
            }
            else
            {
                text_coins.text = null;
                coinsTime = 0f;
                scale = 0.2f;
                show_coins_wchest = false;
            }
        }
        if (show_coins_gchest)
        {
            show_coins_wchest = false;
            
            text_coins.text = earnedMoney + " \u267F";
            if (showCoinsTime >= coinsTime)
            {

                coord_x = chestcol.transform.position.x;
                coord_y = chestcol.transform.position.y + scale;
                text_coins.transform.position = new Vector2(coord_x, coord_y);
                scale += 0.01f;
            }
            else
            {
                text_coins.text = null;
                coinsTime = 0f;
                scale = 0.2f;
                show_coins_gchest = false;
            }
        }
    }
}
