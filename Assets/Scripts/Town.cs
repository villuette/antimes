using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    public int MaxHealth_Level = 0;
    public int Damage_Level = 0;
    public int Armor_Level = 0;
    public int CRIT_Level = 0;
    public int SUP_Level = 0;
    public int Shop_Level = 0;
    public int Max_Level = 10;
    public void Up_MaxHealth_Level()
    {
        MaxHealth_Level += 1;
        Stats.GG_MaxHealth += 30;
    }
    public void Up_Damage_Level()
    {
        Damage_Level += 1;
        Stats.GG_Damage += 2;
    }
    public void Up_Armor_Level()
    {
        Armor_Level += 1;
        Stats.GG_Armor += 1;
    }
    public void Up_CRT_CHN_Level()
    {
        CRIT_Level += 1;
        Stats.GG_CRT_CHN += 1;
        Stats.GG_CRT_DMG += 1;
    }
    public void Up_SUP_Level()
    {
        SUP_Level += 1;
        Stats.GG_SUP_DMG += 1;
    }
    public void Up_Shop_Level()
    {
        Shop_Level += 1;
        Max_Level += 10;
    }
    public GameObject canvas;
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            canvas.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        canvas.SetActive(false);
    }
}