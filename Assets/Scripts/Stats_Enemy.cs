using UnityEngine;
public class Stats_Enemy : MonoBehaviour
{
    public int Enemy_Health;
    public int Enemy_Damage;
    public int Enemy_lvl;
    private int[,] mas_lvl = { { 10,  5}, { 15, 10 }, { 25, 15 }, { 30, 20 }, { 40, 30 }, { 50, 40 }, { 60, 50 } };
    private void Awake()
    {
        Enemy_lvl = Random.Range(1, 7);
        Enemy_Health = mas_lvl[Enemy_lvl, 0];
        Enemy_Damage = mas_lvl[Enemy_lvl, 1];
        Debug.Log(Enemy_Health);
        Debug.Log(Enemy_Damage);
    }
}
