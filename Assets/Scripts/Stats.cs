using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int GG_Experience = 0;
    public static int GG_Gold = 0;
    public static int GG_Health = 300;
    public static int GG_MaxHealth = 300;
    public static int GG_Mana = 0;
    public static int GG_MaxMana = 0;
    public static int GG_Damage = 6;
    public static float GG_Armor = 0.0f;
    public static float GG_CRT_CHN = 0.1f;
    public static float GG_CRT_DMG = 1.0f;
    public static float GG_SUP_DMG = 0.0f;
    public static int GG_SUP_Manacost = 1;
    public static int Enemy_Damage = 30;
    public void lowHP()
    {
        GG_Health -= 1;
        Debug.Log(GG_Health);
    }
    
}