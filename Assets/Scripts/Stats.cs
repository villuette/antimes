using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int GG_Experience;
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
    public void lowHP()
    {
        GG_Health -= 1;
        Debug.Log(GG_Health);
    }
    
}