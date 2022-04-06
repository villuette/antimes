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
    public int Max_Level = 5;
    int flag;
    SpriteRenderer SR;
    public List <GameObject> DMG_UP;
    public GameObject canvas;
    Color color = new Color (255, 0, 0);
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    public void Up_MaxHealth_Level()
    {
        MaxHealth_Level += 1;
        Stats.GG_MaxHealth += 30;
    }
    public void Up_Damage_Level()
    {
        Damage_Level += 1;
        Stats.GG_Damage += 2;
        if (Damage_Level % 5 != 0)
            flag = (Damage_Level % 5) - 1;
        else
            flag = Damage_Level - 1;
        DMG_UP[flag].SetActive(true);

    }
    public void Up_Armor_Level()
    {
        Armor_Level += 1;
        Stats.GG_Armor += 1;
    }
    public void Up_CRIT_Level()
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
        Max_Level += 5;
    }
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