using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public static int GG_Experience;
    public static int GG_UExperience;
    public static int GG_Gold;
    public static int GG_UGold;
    public static int GG_Health;
    public static int GG_MaxHealth;
    public static int GG_Mana;
    public static int GG_MaxMana;
    public static int GG_Damage;
    public static float GG_Armor;
    public static float GG_CRT_CHN;
    public static float GG_CRT_DMG;
    public static float GG_SUP_DMG;
    public static int GG_SUP_Manacost;
    public static int Enemy_Damage;
    public static int MaxHealth_Level = 0;
    public static int Damage_Level = 0;
    public static int Armor_Level = 0;
    public static int CRIT_Level = 0;
    public static int SUP_Level = 0;
    public static int Shop_Level = 0;
    public static int Max_Level = 5;
    public static GameObject GG;
    public static Text coinText;
    public static Text expText;

    public static int costHP;
    public static int costDMG;
    public static int costARM;
    public static int costCRT;
    public static int costSUP;
    public static int costSHOP;
    public static Text costHPt;
    public static Text costDMGt;
    public static Text costARMt;
    public static Text costCRTt;
    public static Text costSUPt;
    public static Text costSHOPt;
    public GameObject canv;
    public static Text expLosed;
    public static Text coinLosed;

    public static GameObject deathmenu;
    void Start()
    {
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            canv = GameObject.Find("canv");
            costHPt = GameObject.Find("costHPt").GetComponent<Text>();
            costDMGt = GameObject.Find("costDMGt").GetComponent<Text>();
            costARMt = GameObject.Find("costARMt").GetComponent<Text>();
            costCRTt = GameObject.Find("costCRTt").GetComponent<Text>();
            costSUPt = GameObject.Find("costSUPt").GetComponent<Text>();
            costSHOPt = GameObject.Find("costSHOPt").GetComponent<Text>();
            canv.SetActive(false);

        }
        if (SceneManager.GetActiveScene().name == "level1")
        {
            expLosed = GameObject.Find("ExpLosed").GetComponent<Text>();
            coinLosed = GameObject.Find("CoinLosed").GetComponent<Text>();
            deathmenu =GameObject.Find("DeathMenu");
            deathmenu.SetActive(false);
        }

        GG = GameObject.Find("GG");
        ShowCoins();
        ShowExp();
    }
    public static void ShowCostsInShop()
    {
        costHPt.text = null;
        costDMGt.text = null;
        costARMt.text = null;
        costCRTt.text = null;
        costSUPt.text = null;
        costSHOPt.text = null;

        costHP = 200 + (MaxHealth_Level / 5) * 100;
        costDMG = 200 + (Damage_Level / 5) * 100;
        costARM = 200 + (Armor_Level / 5) * 100;
        costCRT = 200 + (CRIT_Level / 5) * 100;
        costSUP = 200 + (SUP_Level / 5) * 100;
        costSHOP = Max_Level * 100;

        costHPt.text = Convert.ToString(costHP);
        costDMGt.text = Convert.ToString(costDMG);
        costARMt.text = Convert.ToString(costARM);
        costCRTt.text = Convert.ToString(costCRT);
        costSUPt.text = Convert.ToString(costSUP);
        costSHOPt.text = Convert.ToString(costSHOP);
    }
    public static void ShowCoins()
    {
        coinText.text = Convert.ToString(GG_Gold + GG_UGold);
    }
    public static void ShowExp()
    {
        expText.text = Convert.ToString(GG_Experience + GG_UExperience);
    }
    public void ShowDeathMenu()
    {
        deathmenu.SetActive(true);
        expLosed.text = Convert.ToString(GG_UExperience);
        coinLosed.text = Convert.ToString(GG_UGold);
        StopCoroutine("Wait");
    }
    private  IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        ShowDeathMenu();
        
    }
    public void GG_Death()
    {
        //onoBehaviour mb = new MonoBehaviour();
        GG.GetComponent<Animator>().Play("gg_death");
        //Invoke("ShowDeathMenu", 2f);
        StartCoroutine("Wait"); 
        //ShowDeathMenu();
        GG_UGold = 0;
        GG_UExperience = 0;
        SaveLoadSystem.SaveGame();
        //SceneSwap.Load_Town();
        GG_Moving.CanDoLaddering = true;
        GG_Moving.canMove = true;
    }
}