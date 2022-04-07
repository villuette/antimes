using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_Coins : MonoBehaviour
{
    [SerializeField] private GameObject obj_coins;
    public GameObject fdl; //for down ladder object
    public GameObject generated_coins;
    private float coord_x, coord_y;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void CreateCoin()
    {
        generated_coins = Instantiate(obj_coins);
        //forDownLadderScr coins = fdl.GetComponent<forDownLadderScr>();
        //coord_x = coins.coord_x;
        //coord_y = coins.coord_y;
        //gen_coins.transform.position = new Vector2(coord_x, coord_y);
    }
}
