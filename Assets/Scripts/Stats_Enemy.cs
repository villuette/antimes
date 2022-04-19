using UnityEngine;
public class Stats_Enemy : MonoBehaviour
{
    public int Enemy_Health;
    public int Enemy_Damage;
    public int Enemy_lvl;
    private void Awake()
    {
        if (UnityEngine.Random.Range(0f, 1f) < 0.9f)
            Enemy_lvl = Stats.Shop_Level + 1;
        else
            Enemy_lvl = Stats.Shop_Level + 2;       
        Enemy_Health = 50 * Enemy_lvl*5;
        if (Stats.Shop_Level == 0)
            Enemy_Health = 50;
        Enemy_Damage = 10 * Enemy_lvl;
    }
}
