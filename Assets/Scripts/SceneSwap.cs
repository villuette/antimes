using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public static void Load_level1()
    {
        SaveLoadSystem.SaveGame();
        SceneManager.LoadScene(2);
        SaveLoadSystem.LoadGame();
        Stats.GG_Health = Stats.GG_MaxHealth;
    }
    public static void Load_Town()
    {
        SaveLoadSystem.SaveGame();
        SceneManager.LoadScene(1);
        SaveLoadSystem.LoadGame();
        Stats.GG_Gold += Stats.GG_UGold;
        Stats.GG_Experience += Stats.GG_UExperience;
        Stats.GG_UExperience = 0;
        Stats.GG_UGold = 0;
        Stats.GG_Health = Stats.GG_MaxHealth;
        Stats.GG_Mana = Stats.GG_MaxMana;

    }
    public static void Load_Menu()
    {
        SaveLoadSystem.SaveGame();
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Load_level1();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}