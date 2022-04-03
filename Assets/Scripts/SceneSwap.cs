using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public void Load_level1()
    {
        SceneManager.LoadScene(2);
        
    }
    public void Load_Town()
    {
        SceneManager.LoadScene(1);
        Stats.GG_Gold += Stats.GG_UGold;
        Stats.GG_UGold = 0;
        Stats.GG_Health = Stats.GG_MaxHealth;
    }
    public void Load_Menu()
    {
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