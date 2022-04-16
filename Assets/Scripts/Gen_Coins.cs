using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_Coins : MonoBehaviour
{
    [SerializeField] private GameObject obj_coins;
    public GameObject generated_coins;
    public void CreateCoin()
    {
        generated_coins = Instantiate(obj_coins);
    }
}
