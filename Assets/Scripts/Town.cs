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
    public int Up_Cost = 200;
    public bool check = true;
    public bool keyTouched = false;
    private void Start()
    {
        Stats.GG_Experience += 1000000;
        Stats.GG_Gold += 10000000;
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
        if (MaxHealth_Level < Max_Level && Stats.GG_Experience >= Up_Cost)
        {
            Stats.GG_Experience -= Up_Cost;
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
        if (Damage_Level < Max_Level && Stats.GG_Experience >= Up_Cost)
        {
            Stats.GG_Experience -= Up_Cost;
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
        if (Armor_Level < Max_Level && Stats.GG_Experience >= Up_Cost)
        {
            Stats.GG_Experience -= Up_Cost;
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
        if (CRIT_Level < Max_Level && Stats.GG_Experience >= Up_Cost)
        {
            Stats.GG_Experience -= Up_Cost;
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
        if (SUP_Level < Max_Level && Stats.GG_Experience >= Up_Cost)
        {
            Stats.GG_Experience -= Up_Cost;
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
    public void ColorSystem(int i, ref Color col)
    {
        switch (i)
        {
            case 0:
                col = new Color(0, 0, 0);
                break;
            case 1:
                col = new Color(1, 0, 0);
                break;
            case 2:
                col = new Color(1, 0.5f, 0);
                break;
            case 3:
                col = new Color(1, 1, 0);
                break;
            case 4:
                col = new Color(0, 1, 1);
                break;
            case 5:
                col = new Color(0, 1, 0);
                break;
            case 6:
                col = new Color(0, 0, 1);
                break;
            case 7:
                col = new Color(0, 0, 0.5f);
                break;
            case 8:
                col = new Color(0.5f, 0, 0.5f);
                break;
            case 9:
                col = new Color(0.5f, 0, 0);
                break;
        }
    }
    public void Up_Shop_Level()
    {
        if (MaxHealth_Level == Max_Level && Damage_Level == Max_Level && Armor_Level == Max_Level && CRIT_Level == Max_Level && SUP_Level == Max_Level && Stats.GG_Gold >= 1 && Shop_Level < 9)
        {
            Shop_Level += 1;
            Max_Level += 5;
            Stats.GG_Gold -= 1;
        }
        ColorSystem(Shop_Level, ref color);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            keyTouched = true;
        if (Input.GetKeyUp(KeyCode.F))
            keyTouched = false;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && keyTouched)
        {
            GG_Moving.canMove = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("is_running", 0);
            if (check)
            {
                Max_Level += 5 * Shop_Level;
                Stats.GG_Experience += 100000;
                int CheckColor = -1;
                int check_LVL = MaxHealth_Level;
                MaxHealth_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    if (i % 5 == 0)
                    {
                        CheckColor++;
                        ColorSystem(CheckColor, ref color);
                        Up_MaxHealth_Level();
                    }
                    else
                        Up_MaxHealth_Level();
                    ColorSystem(CheckColor, ref color);
                    Stats.GG_MaxHealth -= 30;
                    Stats.GG_Experience += Up_Cost;
                }


                CheckColor = -1;
                check_LVL = Damage_Level;
                Damage_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    if (i % 5 == 0)
                    {
                        CheckColor++;
                        ColorSystem(CheckColor, ref color);
                        Up_Damage_Level();
                    }
                    else
                        Up_Damage_Level();
                    ColorSystem(CheckColor, ref color);
                    Stats.GG_Experience += Up_Cost;
                    Stats.GG_Damage -= 2;
                }
                CheckColor = -1;
                check_LVL = Armor_Level;
                Armor_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    if (i % 5 == 0)
                    {
                        CheckColor++;
                        ColorSystem(CheckColor, ref color);
                        Up_Armor_Level();
                    }
                    else
                        Up_Armor_Level();
                    ColorSystem(CheckColor, ref color);
                    Stats.GG_Armor -= 1;
                    Stats.GG_Experience += Up_Cost;
                }
                CheckColor = -1;
                check_LVL = CRIT_Level;
                CRIT_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    if (i % 5 == 0)
                    {
                        CheckColor++;
                        ColorSystem(CheckColor, ref color);
                        Up_CRIT_Level();
                    }
                    else
                        Up_CRIT_Level();
                    ColorSystem(CheckColor, ref color);
                    Stats.GG_CRT_CHN -= 1;
                    Stats.GG_CRT_DMG -= 1;
                    Stats.GG_Experience += Up_Cost;
                }
                CheckColor = -1;
                check_LVL = SUP_Level;
                SUP_Level = 0;
                for (int i = 0; i < check_LVL; ++i)
                {
                    if (i % 5 == 0)
                    {
                        CheckColor++;
                        ColorSystem(CheckColor, ref color);
                        Up_SUP_Level();
                    }
                    else
                        Up_SUP_Level();
                    ColorSystem(CheckColor, ref color);
                    Stats.GG_SUP_DMG -= 1;
                    Stats.GG_Experience += Up_Cost;
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
        GG_Moving.canMove = true;
    }
}