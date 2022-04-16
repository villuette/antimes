using UnityEngine;
public class Stats_Enemy : MonoBehaviour
{
    public int Enemy_Health;
    public int Enemy_Damage;
    public int Enemy_lvl;
    private int[,] mas_lvl = { { 10,  5}, { 15, 6 }, { 25, 8}, { 30, 15 }, { 40,18 }, { 50, 20 }, { 60, 21 } };
    private void Awake()
    {
        Enemy_lvl = Random.Range(1, 7);
        Enemy_Health = mas_lvl[Enemy_lvl, 0];
        Enemy_Damage = mas_lvl[Enemy_lvl, 1];
    }
}
