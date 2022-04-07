using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{
    public int MaxHealth_Level = 0;
    public int Damage_Level = 0;
    public int Armor_Level = 0;
    public int CRIT_Level = 0;
    public int SUP_Level = 0;
    public int Shop_Level = 0;
    public int Max_Level = 5;

    SpriteRenderer SR;
    public List<GameObject> MaxHP_UP;
    public List<GameObject> DMG_UP;
    public List<GameObject> Armor_UP;
    public List<GameObject> CRIT_UP;
    public List<GameObject> SUP_UP;
    public GameObject canvas;
    Color color = new Color(1, 0, 0);
    int flag;
    public bool check = true;
    private void Start()
    {
        Stats.GG_Experience += 1000;
        Stats.GG_Gold += 1000;
        SR = GetComponent<SpriteRenderer>();
        MaxHealth_Level = PlayerPrefs.GetInt("MaxHealth_Level");
        Damage_Level = PlayerPrefs.GetInt("Damage_Level");
        Armor_Level = PlayerPrefs.GetInt("Armor_Level");
        CRIT_Level = PlayerPrefs.GetInt("CRIT_Level");
        SUP_Level = PlayerPrefs.GetInt("SUP_Level");
        Shop_Level = PlayerPrefs.GetInt("Shop_Level");
    }
    public void Up_MaxHealth_Level()
    {
        if (MaxHealth_Level < Max_Level && Stats.GG_Experience >= 1)
        {
            Stats.GG_Experience -= 1;
            MaxHealth_Level += 1;
            Stats.GG_MaxHealth += 30;
            if (MaxHealth_Level <= 5)
            {
                if (MaxHealth_Level % 5 != 0)
                    flag = (MaxHealth_Level % 5) - 1;
                else
                    flag = 4;
                MaxHP_UP[flag].SetActive(true);
            }
            else
            {
                if (MaxHealth_Level % 5 != 0)
                    flag = (MaxHealth_Level % 5) - 1;
                else
                    flag = 4;
                MaxHP_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_Damage_Level()
    {
        if (Damage_Level < Max_Level && Stats.GG_Experience >= 1)
        {
            Stats.GG_Experience -= 1;
            Damage_Level += 1;
            Stats.GG_Damage += 2;
            if (Damage_Level <= 5)
            {
                if (Damage_Level % 5 != 0)
                    flag = (Damage_Level % 5) - 1;
                else
                    flag = Damage_Level - 1;
                DMG_UP[flag].SetActive(true);
            }
            else
            {
                if (Damage_Level % 5 != 0)
                    flag = (Damage_Level % 5) - 1;
                else
                    flag = 4;
                DMG_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_Armor_Level()
    {
        if (Armor_Level < Max_Level && Stats.GG_Experience >= 1)
        {
            Stats.GG_Experience -= 1;
            Armor_Level += 1;
            Stats.GG_Armor += 1;
            if (Armor_Level <= 5)
            {
                if (Armor_Level % 5 != 0)
                    flag = (Armor_Level % 5) - 1;
                else
                    flag = Armor_Level - 1;
                Armor_UP[flag].SetActive(true);
            }
            else
            {
                if (Armor_Level % 5 != 0)
                    flag = (Armor_Level % 5) - 1;
                else
                    flag = 4;
                Armor_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_CRIT_Level()
    {
        if (CRIT_Level < Max_Level && Stats.GG_Experience >= 1)
        {
            Stats.GG_Experience -= 1;
            CRIT_Level += 1;
            Stats.GG_CRT_CHN += 1;
            Stats.GG_CRT_DMG += 1;
            if (CRIT_Level <= 5)
            {
                if (CRIT_Level % 5 != 0)
                    flag = (CRIT_Level % 5) - 1;
                else
                    flag = CRIT_Level - 1;
                CRIT_UP[flag].SetActive(true);
            }
            else
            {
                if (CRIT_Level % 5 != 0)
                    flag = (CRIT_Level % 5) - 1;
                else
                    flag = 4;
                CRIT_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_SUP_Level()
    {
        if (SUP_Level < Max_Level && Stats.GG_Experience >= 1)
        {
            Stats.GG_Experience -= 1;
            SUP_Level += 1;
            Stats.GG_SUP_DMG += 1;
            if (SUP_Level <= 5)
            {
                if (SUP_Level % 5 != 0)
                    flag = (SUP_Level % 5) - 1;
                else
                    flag = SUP_Level - 1;
                SUP_UP[flag].SetActive(true);
            }
            else
            {
                if (SUP_Level % 5 != 0)
                    flag = (SUP_Level % 5) - 1;
                else
                    flag = 4;
                SUP_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_Shop_Level()
    {
        if (MaxHealth_Level == Max_Level && Damage_Level == Max_Level && Armor_Level == Max_Level && CRIT_Level == Max_Level && SUP_Level == Max_Level && Stats.GG_Gold >= 1)
        {
            Shop_Level += 1;
            Max_Level += 5;
            Stats.GG_Gold -= 1;
        }
        if (Shop_Level == 2)
            color = new Color(1, 0.5f, 0);
        if (Shop_Level == 3)
            color = new Color(1, 1, 0);
        if (Shop_Level == 4)
            color = new Color(0.5f, 1, 0);
        if (Shop_Level == 5)
            color = new Color(0, 1, 0);
        if (Shop_Level == 6)
            color = new Color(0, 1, 0.5f);
        if (Shop_Level == 7)
            color = new Color(0, 1, 1);
        if (Shop_Level == 8)
            color = new Color(0, 0.5f, 1);
        if (Shop_Level == 9)
            color = new Color(0, 0, 1);
        if (Shop_Level == 10)
            color = new Color(0.5f, 0, 0);
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (check)
            {
                Max_Level += 5 * Shop_Level;
                int check_LVL = MaxHealth_Level;
                MaxHealth_Level = 0;
                Stats.GG_Experience += 100000;
                for (int i = 0; i < check_LVL;++i)
                {
                    Up_MaxHealth_Level();
                    Stats.GG_Experience += 1;
                }
                check_LVL = Damage_Level;
                Damage_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    Up_Damage_Level();
                    Stats.GG_Experience += 1;
                }
                check_LVL = Armor_Level;
                Armor_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    Up_Armor_Level();
                    Stats.GG_Experience += 1;
                }
                check_LVL = CRIT_Level;
                CRIT_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    Up_CRIT_Level();
                    Stats.GG_Experience += 1;
                }
                check_LVL = SUP_Level;
                SUP_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    Up_SUP_Level();
                    Stats.GG_Experience += 1;
                }
                Stats.GG_Experience -= 100000;
                check = false;
            }
            canvas.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        canvas.SetActive(false);
    }
}