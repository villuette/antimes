using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour
{
    public GameObject HPBar;
    public GameObject TownScriptsObj;
    public GameObject leftCornBar;
    public GameObject rightCornBar;
    public GameObject midCornBar;
    public GameObject healthParticle;
    GameObject[] particles;
    public int numOfBlocks;
    Town town;
    Color color = Color.red;
    float posX;
    float offset;
    public float[] positions;
    int maximal;

    public void Start()
    {
        town = TownScriptsObj.GetComponent<Town>();
        town.ColorSystem(0, ref color);
        posX = leftCornBar.GetComponent<Transform>().position.x;
        offset = (float)Math.Round(midCornBar.GetComponent<SpriteRenderer>().size.x / 2, 2);
        RendHPbar();
        ShowHP();
    }
    public void InstanceHP()
    {
        town = TownScriptsObj.GetComponent<Town>();
        town.ColorSystem(0, ref color);
        posX = leftCornBar.GetComponent<Transform>().position.x;
        offset = (float)Math.Round(midCornBar.GetComponent<SpriteRenderer>().size.x / 2, 2);
        RendHPbar();
        ShowHP();
    }
    
    public void RendHPbar()
    {
        maximal = Stats.GG_MaxHealth/ 100;
        positions = new float[maximal + 1]; ;
        positions[0] = leftCornBar.transform.position.x;
        
        if (maximal > 10) maximal = 10;
        for (int i = 0, k = 1; i < maximal - 2; i++, k++)
        {
            posX += offset;
            positions[k] = posX;
            Vector3 a = new Vector3(posX, leftCornBar.transform.position.y, leftCornBar.transform.position.z);
            GameObject clonedMid = Instantiate(midCornBar);
            clonedMid.transform.position = a;
            clonedMid.transform.parent = HPBar.transform;

        }
        posX += offset;
        positions[maximal - 1] = posX;
        rightCornBar.transform.position = new Vector3(positions[maximal - 1], leftCornBar.transform.position.y, leftCornBar.transform.position.z);
    }
    public void ShowHP()
    {
        int curHP = Stats.GG_Health;

        if (curHP % 100 != 0)
        {
            numOfBlocks = curHP / 100 + 1;
        }
        else numOfBlocks = curHP / 100;

        particles = new GameObject[Stats.GG_MaxHealth / 100];

        for (int i = 0,l=0, c = 0; i < numOfBlocks; i++,c++)
        {
            
            
            if (c >= 10)
            {
                town.ColorSystem(++l, ref color);
                healthParticle.GetComponent<SpriteRenderer>().sortingOrder++;
                c = 0;
            }

            particles[i] = Instantiate(healthParticle);
            particles[i].GetComponent<SpriteRenderer>().color = color;
            particles[i].transform.position = new Vector3(positions[i % 10], leftCornBar.transform.position.y, leftCornBar.transform.position.z);
            particles[i].transform.parent = HPBar.transform;

        }
    }

}
