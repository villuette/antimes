using UnityEngine;
public class Stats_Enemy : MonoBehaviour
{
    public int Enemy_Health;
    public int Enemy_Damage;
    public int Enemy_lvl;
    //private int[,] mas_lvl = { { 10, 5 }, { 15, 6 }, { 25, 8 }, { 30, 15 }, { 40, 18 }, { 50, 20 }, { 60, 21 } };

    //private void Start()
    //{

    //}
    //private void Update()
    //{
    //    print(BGparallax.tvy);
    //}
    private void Awake()
    {

        Enemy_lvl = Random.Range(Stats.Shop_Level + 1, Stats.Shop_Level + 3);
        Enemy_Health = 50 * Enemy_lvl;//mas_lvl[Enemy_lvl, 0];
        Enemy_Damage = 10 * Enemy_lvl;//mas_lvl[Enemy_lvl, 1];
    }
}
