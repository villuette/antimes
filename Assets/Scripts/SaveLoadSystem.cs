using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public void SaveGame()
    {
        PlayerPrefs.SetInt("GG_Experience_SAVE", Stats.GG_Experience);
        PlayerPrefs.SetInt("GG_Gold_SAVE", Stats.GG_Gold);
        PlayerPrefs.SetInt("GG_Health_SAVE", Stats.GG_Health);
        PlayerPrefs.SetInt("GG_MaxHealth_SAVE", Stats.GG_MaxHealth);
        PlayerPrefs.SetInt("GG_Mana_SAVE", Stats.GG_Mana);
        PlayerPrefs.SetInt("GG_MaxMana_SAVE", Stats.GG_MaxMana);
        PlayerPrefs.SetInt("GG_Damage_SAVE", Stats.GG_Damage);
        PlayerPrefs.SetFloat("GG_Armor_SAVE", Stats.GG_Armor);
        PlayerPrefs.SetFloat("GG_CRT_CHN_SAVE", Stats.GG_CRT_CHN);
        PlayerPrefs.SetFloat("GG_CRT_DMG_SAVE", Stats.GG_CRT_DMG);
        PlayerPrefs.SetFloat("GG_SUP_DMG_SAVE", Stats.GG_SUP_DMG);
        PlayerPrefs.SetInt("GG_SUP_Manacost_SAVE", Stats.GG_SUP_Manacost);
    }
    public void LoadGame()
    {
        Stats.GG_Experience = PlayerPrefs.GetInt("GG_Experience_SAVE");
        Stats.GG_Gold = PlayerPrefs.GetInt("GG_Gold_SAVE");
        Stats.GG_Health = PlayerPrefs.GetInt("GG_Health_SAVE");
        Stats.GG_MaxHealth = PlayerPrefs.GetInt("GG_MaxHealth_SAVE");
        Stats.GG_Mana = PlayerPrefs.GetInt("GG_Mana_SAVE");
        Stats.GG_MaxMana = PlayerPrefs.GetInt("GG_MaxMana_SAVE");
        Stats.GG_Damage = PlayerPrefs.GetInt("GG_Damage_SAVE");
        Stats.GG_Armor = PlayerPrefs.GetFloat("GG_Armor_SAVE");
        Stats.GG_CRT_CHN = PlayerPrefs.GetFloat("GG_CRT_CHN_SAVE");
        Stats.GG_CRT_DMG = PlayerPrefs.GetFloat("GG_CRT_DMG_SAVE");
        Stats.GG_SUP_DMG = PlayerPrefs.GetFloat("GG_SUP_DMG_SAVE");
        Stats.GG_SUP_Manacost = PlayerPrefs.GetInt("GG_SUP_Manacost_SAVE");
    }
    void DelteSave()
    {
        PlayerPrefs.DeleteKey("SAVE");
    }
    
}