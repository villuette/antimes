using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Town : MonoBehaviour
{

    //public GameObject hplogic;
    //SpriteRenderer SR;
    public List<GameObject> MaxHP_UP;
    public List<GameObject> DMG_UP;
    public List<GameObject> Armor_UP;
    public List<GameObject> CRIT_UP;
    public List<GameObject> SUP_UP;
    public GameObject canvas;
    HealthSystem healthSystem;
    Color color = new Color(1, 0, 0);
    int flag;
    public int Up_Cost = 200;
    public bool check = true;
    public bool keyTouched = false;
    private void Start()
    {
        healthSystem = GameObject.Find("HPLogic").GetComponent<HealthSystem>();
    }
    public void Up_MaxHealth_Level()
    {
        if (Stats.MaxHealth_Level < Stats.Max_Level && Stats.GG_Experience >= Stats.costHP)
        {
            Stats.GG_Experience -= Stats.costHP;
            Stats.MaxHealth_Level += 1;
            Stats.GG_MaxHealth += 100;
            Stats.GG_Health = Stats.GG_MaxHealth;
            healthSystem.InstanceHP();
            if (Stats.MaxHealth_Level <= 5)
            {
                if (Stats.MaxHealth_Level % 5 != 0)
                    flag = (Stats.MaxHealth_Level % 5) - 1;
                else
                    flag = 4;
                MaxHP_UP[flag].SetActive(true);
            }
            else
            {
                if (Stats.MaxHealth_Level % 5 != 0)
                    flag = (Stats.MaxHealth_Level % 5) - 1;
                else
                    flag = 4;
                ColorSystem((Stats.MaxHealth_Level - 1) / 5, ref color);
                MaxHP_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_Damage_Level()
    {
        if (Stats.Damage_Level < Stats.Max_Level && Stats.GG_Experience >= Stats.costDMG)
        {
            Stats.GG_Experience -= Stats.costDMG;
            Stats.Damage_Level += 1;
            Stats.GG_Damage += 5;
            if (Stats.Damage_Level <= 5)
            {
                if (Stats.Damage_Level % 5 != 0)
                    flag = (Stats.Damage_Level % 5) - 1;
                else
                    flag = Stats.Damage_Level - 1;
                DMG_UP[flag].SetActive(true);
            }
            else
            {
                if (Stats.Damage_Level % 5 != 0)
                    flag = (Stats.Damage_Level % 5) - 1;
                else
                    flag = 4;
                ColorSystem((Stats.Damage_Level - 1) / 5, ref color);
                DMG_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_Armor_Level()
    {
        if (Stats.Armor_Level < Stats.Max_Level && Stats.GG_Experience >= Stats.costARM)
        {
            Stats.GG_Experience -= Stats.costARM;
            Stats.Armor_Level += 1;
            Stats.GG_Armor += 0.016f;
            if (Stats.Armor_Level <= 5)
            {
                if (Stats.Armor_Level % 5 != 0)
                    flag = (Stats.Armor_Level % 5) - 1;
                else
                    flag = Stats.Armor_Level - 1;
                Armor_UP[flag].SetActive(true);
            }
            else
            {
                if (Stats.Armor_Level % 5 != 0)
                    flag = (Stats.Armor_Level % 5) - 1;
                else
                    flag = 4;
                ColorSystem((Stats.Armor_Level - 1) / 5, ref color);
                Armor_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_CRIT_Level()
    {
        if (Stats.CRIT_Level < Stats.Max_Level && Stats.GG_Experience >= Stats.costCRT)
        {
            Stats.GG_Experience -= Stats.costCRT;
            Stats.CRIT_Level += 1;
            Stats.GG_CRT_CHN += 0.01f; //
            Stats.GG_CRT_DMG += 0.02f;
            if (Stats.CRIT_Level <= 5)
            {
                if (Stats.CRIT_Level % 5 != 0)
                    flag = (Stats.CRIT_Level % 5) - 1;
                else
                    flag = Stats.CRIT_Level - 1;
                CRIT_UP[flag].SetActive(true);
            }
            else
            {
                if (Stats.CRIT_Level % 5 != 0)
                    flag = (Stats.CRIT_Level % 5) - 1;
                else
                    flag = 4;
                ColorSystem((Stats.CRIT_Level -1)/ 5, ref color);
                CRIT_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void Up_SUP_Level()
    {
        if (Stats.SUP_Level < Stats.Max_Level && Stats.GG_Experience >= Stats.costSUP)
        {
            Stats.GG_Experience -= Stats.costSUP;
            Stats.SUP_Level += 1;
            Stats.GG_SUP_DMG += 1;
            if (Stats.SUP_Level <= 5)
            {
                if (Stats.SUP_Level % 5 != 0)
                    flag = (Stats.SUP_Level % 5) - 1;
                else
                    flag = Stats.SUP_Level - 1;
                SUP_UP[flag].SetActive(true);
            }
            else
            {
                if (Stats.SUP_Level % 5 != 0)
                    flag = (Stats.SUP_Level % 5) - 1;
                else
                    flag = 4;
                ColorSystem((Stats.SUP_Level-1) / 5, ref color);
                SUP_UP[flag].GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void ColorSystem(int i, ref Color col)
    {
        switch (i)
        {
            case 0:
                col = new Color(1, 1, 1);
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
        //if (Stats.MaxHealth_Level == Stats.Max_Level && Stats.Damage_Level == Stats.Max_Level && Stats.Armor_Level == Stats.Max_Level
        //    && Stats.CRIT_Level == Stats.Max_Level && Stats.SUP_Level == Stats.Max_Level && Stats.GG_Gold >= 1 && Stats.Shop_Level < 9)
        if (Stats.GG_Gold > Stats.costSHOP && Stats.Shop_Level < 9)
        {
            Stats.Shop_Level += 1;
            Stats.Max_Level += 5;
            Stats.GG_Gold -= Stats.costSHOP;
        }
        //ColorSystem(Stats.Shop_Level, ref color);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenShop();
                Stats.ShowCostsInShop();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
                CloseMenu();
        }

    }

    public void OpenShop()
    {

        GG_Moving.canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("is_running", 0);
        if (check)
        {
            Stats.Max_Level += 5 * Stats.Shop_Level;
            Stats.GG_Experience += 100000;
            int CheckColor = -1;
            int check_LVL = Stats.MaxHealth_Level;
            Stats.MaxHealth_Level = 0;
            for (int i = 0; i < check_LVL; ++i)
            {
                if (i % 5 == 0)
                {
                    CheckColor++;
                    ColorSystem(CheckColor, ref color);
                    Up_MaxHealth_Level();
                    Stats.GG_MaxHealth -= 100;
                }
                else
                {
                    Up_MaxHealth_Level();
                    Stats.GG_MaxHealth -= 100;
                }
                ColorSystem(CheckColor, ref color);
                Stats.GG_Experience += Up_Cost;
            }


            CheckColor = -1;
            check_LVL = Stats.Damage_Level;
            Stats.Damage_Level = 0;
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
            check_LVL = Stats.Armor_Level;
            Stats.Armor_Level = 0;
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
            check_LVL = Stats.CRIT_Level;
            Stats.CRIT_Level = 0;
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
            check_LVL = Stats.SUP_Level;
            Stats.SUP_Level = 0;
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
            ColorSystem(Stats.Shop_Level, ref color);
            Stats.GG_Experience -= 100000;
            check = false;
        }
        canvas.SetActive(true);

    }
    public void CloseMenu()
    {
        Stats.ShowCostsInShop();
        canvas.SetActive(false);
        GG_Moving.canMove = true;
    }
}