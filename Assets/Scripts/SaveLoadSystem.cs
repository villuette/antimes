using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public static void SaveGame()
    {
        PlayerPrefs.SetInt("GG_Experience_SAVE", Stats.GG_Experience);
        PlayerPrefs.SetInt("GG_Gold_SAVE", Stats.GG_Gold);
        PlayerPrefs.SetInt("GG_MaxHealth_SAVE", Stats.GG_MaxHealth);
        PlayerPrefs.SetInt("GG_MaxMana_SAVE", Stats.GG_MaxMana);
        PlayerPrefs.SetInt("GG_Damage_SAVE", Stats.GG_Damage);
        PlayerPrefs.SetFloat("GG_Armor_SAVE", Stats.GG_Armor);
        PlayerPrefs.SetFloat("GG_CRT_CHN_SAVE", Stats.GG_CRT_CHN);
        PlayerPrefs.SetFloat("GG_CRT_DMG_SAVE", Stats.GG_CRT_DMG);
        PlayerPrefs.SetFloat("GG_SUP_DMG_SAVE", Stats.GG_SUP_DMG);
        PlayerPrefs.SetInt("GG_SUP_Manacost_SAVE", Stats.GG_SUP_Manacost);
        PlayerPrefs.SetInt("MaxHealth_Level", Stats.MaxHealth_Level);
        PlayerPrefs.SetInt("Damage_Level", Stats.Damage_Level);
        PlayerPrefs.SetInt("Armor_Level", Stats.Armor_Level);
        PlayerPrefs.SetInt("CRIT_Level", Stats.CRIT_Level);
        PlayerPrefs.SetInt("SUP_Level", Stats.SUP_Level);
        PlayerPrefs.SetInt("Shop_Level", Stats.Shop_Level);
    }
    public static void LoadGame()
    {
        Stats.GG_Experience = PlayerPrefs.GetInt("GG_Experience_SAVE");
        Stats.GG_Gold = PlayerPrefs.GetInt("GG_Gold_SAVE");
        Stats.GG_MaxHealth = PlayerPrefs.GetInt("GG_MaxHealth_SAVE");
        Stats.GG_MaxMana = PlayerPrefs.GetInt("GG_MaxMana_SAVE");
        Stats.GG_Damage = PlayerPrefs.GetInt("GG_Damage_SAVE");
        Stats.GG_Armor = PlayerPrefs.GetFloat("GG_Armor_SAVE");
        Stats.GG_CRT_CHN = PlayerPrefs.GetFloat("GG_CRT_CHN_SAVE");
        Stats.GG_CRT_DMG = PlayerPrefs.GetFloat("GG_CRT_DMG_SAVE");
        Stats.GG_SUP_DMG = PlayerPrefs.GetFloat("GG_SUP_DMG_SAVE");
        Stats.GG_SUP_Manacost = PlayerPrefs.GetInt("GG_SUP_Manacost_SAVE");
        Stats.MaxHealth_Level = PlayerPrefs.GetInt("MaxHealth_Level");
        Stats.Damage_Level = PlayerPrefs.GetInt("Damage_Level");
        Stats.Armor_Level = PlayerPrefs.GetInt("Armor_Level");
        Stats.CRIT_Level = PlayerPrefs.GetInt("CRIT_Level");
        Stats.SUP_Level = PlayerPrefs.GetInt("SUP_Level");
        Stats.Shop_Level = PlayerPrefs.GetInt("Shop_Level");
    }
    public static void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        Stats.GG_Experience = 0;
        Stats.GG_Gold = 0;
        Stats.GG_Health = 500;
        Stats.GG_MaxHealth = 500;
        Stats.GG_Mana = 0;
        Stats.GG_MaxMana = 0;
        Stats.GG_Damage = 5;
        Stats.GG_Armor = 0.0f;
        Stats.GG_CRT_CHN = 0.05f;
        Stats.GG_CRT_DMG = 1.1f;
        Stats.GG_SUP_DMG = 0.0f;
        Stats.GG_SUP_Manacost = 1;
        Stats.Enemy_Damage = 30;
        Stats.MaxHealth_Level = 0;
        Stats.Damage_Level = 0;
        Stats.Armor_Level = 0;
        Stats.CRIT_Level = 0;
        Stats.SUP_Level = 0;
        Stats.Shop_Level = 0;
        SaveGame();
    }
}