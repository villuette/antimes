using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public Town town = null;
    public void SaveGame()
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
        PlayerPrefs.SetInt("MaxHealth_Level", town.MaxHealth_Level);
        PlayerPrefs.SetInt("Damage_Level", town.Damage_Level);
        PlayerPrefs.SetInt("Armor_Level", town.Armor_Level);
        PlayerPrefs.SetInt("CRIT_Level", town.CRIT_Level);
        PlayerPrefs.SetInt("SUP_Level", town.SUP_Level);
        PlayerPrefs.SetInt("Shop_Level", town.Shop_Level);
    }
    public void LoadGame()
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
        town.MaxHealth_Level = PlayerPrefs.GetInt("MaxHealth_Level");
        town.Damage_Level = PlayerPrefs.GetInt("Damage_Level");
        town.Armor_Level = PlayerPrefs.GetInt("Armor_Level");
        town.CRIT_Level = PlayerPrefs.GetInt("CRIT_Level");
        town.SUP_Level = PlayerPrefs.GetInt("SUP_Level");
        town.Shop_Level = PlayerPrefs.GetInt("Shop_Level");
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        Stats.GG_Experience = 0;
        Stats.GG_Gold = 0;
        Stats.GG_Health = 500;
        Stats.GG_MaxHealth = 500;
        Stats.GG_Mana = 0;
        Stats.GG_MaxMana = 0;
        Stats.GG_Damage = 6;
        Stats.GG_Armor = 0.0f;
        Stats.GG_CRT_CHN = 0.1f;
        Stats.GG_CRT_DMG = 1.0f;
        Stats.GG_SUP_DMG = 0.0f;
        Stats.GG_SUP_Manacost = 1;
        Stats.Enemy_Damage = 30;
        town.MaxHealth_Level = 0;
        town.Damage_Level = 0;
        town.Armor_Level = 0;
        town.CRIT_Level = 0;
        town.SUP_Level = 0;
        town.Shop_Level = 0;
        SaveGame();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SaveGame();
        }
    }
}