using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public SaveLoadSystem saveLoadSystem = null;
    public void Load_level1()
    {
        saveLoadSystem.SaveGame();
        SceneManager.LoadScene(2);
        saveLoadSystem.LoadGame();
    }
    public void Load_Town()
    {
        saveLoadSystem.SaveGame();
        SceneManager.LoadScene(1);
        saveLoadSystem.LoadGame();
        Stats.GG_Gold += Stats.GG_UGold;
        Stats.GG_UGold = 0;
        //Stats.GG_Health = Stats.GG_MaxHealth;
        Stats.GG_Mana = Stats.GG_MaxMana;
    }
    public void Load_Menu()
    {
        saveLoadSystem.SaveGame();
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