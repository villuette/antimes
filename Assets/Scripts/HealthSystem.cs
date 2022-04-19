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
    GameObject[] clonedMid;
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
        //midCornBar.transform.localScale =  new Vector3(leftCornBar.transform.localScale.x, leftCornBar.transform.localScale.y, leftCornBar.transform.localScale.z);
        offset = midCornBar.GetComponent<SpriteRenderer>().size.x / 2;

        maximal = Stats.GG_MaxHealth / 100;
        particles = new GameObject[maximal]; //particles before cuts'10 maximal
        if (maximal > 10) maximal = 10;
        clonedMid = new GameObject[maximal - 2];
        positions = new float[maximal];
        RendHPbar();
        ShowHP();
    }
    public void InstanceHP()
    {
        //town = TownScriptsObj.GetComponent<Town>();
        //town.ColorSystem(0, ref color);
        posX = leftCornBar.GetComponent<Transform>().position.x;
        //offset = (float)Math.Round(midCornBar.GetComponent<SpriteRenderer>().size.x / 2, 2);
   
       


        for (int i = 0; i < maximal; i++) //max from last iteration
            if(particles[i] != null)
                Destroy(particles[i].gameObject); //destroy previous particles
        for (int i = 0; i < maximal - 2; i++)
            Destroy(clonedMid[i].gameObject);

        maximal = Stats.GG_MaxHealth / 100;
        particles = new GameObject[maximal];//particles before cuts'10 maximal
        if (maximal > 10) maximal = 10;
        positions = new float[maximal];
        clonedMid = new GameObject[maximal - 2];
        RendHPbar();
        ShowHP();

    }

    public void RendHPbar()
    {
        
        positions[0] = leftCornBar.transform.position.x; //left

        
        for (int i = 1; i < maximal - 1; i++) //mids
        {
            posX += offset;
            positions[i] = posX;
            Vector3 a = new Vector3(posX, leftCornBar.transform.position.y, leftCornBar.transform.position.z);
            clonedMid[i - 1] = Instantiate(midCornBar);
            clonedMid[i - 1].transform.position = a;
            clonedMid[i - 1].transform.parent = HPBar.transform;

        }
        posX += offset;
        positions[maximal - 1] = posX; //right pos
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

        

        for (int i = 0, l = 0, c = 0; i < numOfBlocks; i++, c++)
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
