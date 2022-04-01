using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using System.Linq;


public class Generation : MonoBehaviour
{ 
    public GameObject character, earth, leftCornerEarth, rightCornerEarth, ladder;
    public float platLength;
    public BoxCollider2D col;

    public float deltaY = 1.44f;
    public int platformQuantity; 
    SpriteRenderer sr;

    float previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower, previousLadderY_lower;
    float  previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper, previousLadderY_upper;
      
    float previousPlatY, previousLadderY, previousPlatX, previousPlatHalf;

    float upperTrigger, lowerTrigger;

    //private void Start()
    //{
    //    platLength = Random.Range(5, 40) * 0.32f;
    //    for (int i = 0; i <= 1; i++)
    //    {
    //        if (i == 0)
    //        {
    //            sr = earth.gameObject.GetComponent<SpriteRenderer>();
    //            sr.size = new Vector2(platLength, sr.size.y);

    //            col = earth.gameObject.GetComponent<BoxCollider2D>();
    //            col.size = new Vector2(sr.size.x + 0.61f, col.size.y);

    //            earth.transform.position = new Vector2(0.0f, 0.0f);

    //            leftCornerEarth.transform.position = new Vector2(earth.transform.position.x - (platLength / 2.0f) - 0.16f, earth.transform.position.y);
    //            rightCornerEarth.transform.position = new Vector2(earth.transform.position.x + (platLength / 2.0f) + 0.16f, earth.transform.position.y);

    //            previousPlatX_lower = earth.transform.position.x;
    //            previousPlatHalf_lower = platLength / 2.0f;
    //            previousPlatY_lower = earth.transform.position.y;
    //        }
    //        if (i == 1)
    //        {
    //            GameObject platClone = Instantiate(earth);
    //            GameObject leftCornerClone = Instantiate(leftCornerEarth);
    //            GameObject rightCornerClone = Instantiate(rightCornerEarth);

    //            sr = platClone.gameObject.GetComponent<SpriteRenderer>();
    //            sr.size = new Vector2(platLength, sr.size.y);

    //            col = platClone.gameObject.GetComponent<BoxCollider2D>();
    //            col.size = new Vector2(sr.size.x + 0.61f, col.size.y); ;

    //            platClone.transform.position = new Vector2(0.0f, previousPlatY_lower + deltaY);

    //            leftCornerClone.transform.position = new Vector2(platClone.transform.position.x - (platLength / 2.0f) - 0.16f, platClone.transform.position.y);
    //            rightCornerClone.transform.position = new Vector2(platClone.transform.position.x + (platLength / 2.0f) + 0.16f, platClone.transform.position.y);

    //            ladder.transform.position = new Vector2(Random.Range(platClone.transform.position.x - (platLength / 2.0f), platClone.transform.position.x + (platLength / 2.0f)), platClone.transform.position.y - 0.64f);

    //            previousPlatX_upper = platClone.transform.position.x;
    //            previousPlatHalf_upper = platLength / 2.0f;
    //            previousPlatY_upper = platClone.transform.position.y;
    //            previousLadderY_upper = ladder.transform.position.y;
    //            previousLadderY_lower = ladder.transform.position.y;
    //        }
    //    }
    //    upperTrigger = previousPlatY_upper + deltaY * (platformQuantity - 1);
    //    lowerTrigger = previousPlatY_lower - deltaY * (platformQuantity - 1);

    //    generateUpperChunk(deltaY, previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper, previousLadderY_upper);
    //    generateLowerChunk(deltaY, previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower, previousLadderY_lower);
    //}


    private void Start()
    {
        platLength = Random.Range(5, 40) * 0.32f;
        sr = earth.gameObject.GetComponent<SpriteRenderer>();
        sr.size = new Vector2(platLength, sr.size.y);

        col = earth.gameObject.GetComponent<BoxCollider2D>();
        col.size = new Vector2(sr.size.x + 0.61f, col.size.y);

        earth.transform.position = new Vector2(0.0f, 0.0f);

        leftCornerEarth.transform.position = new Vector2(earth.transform.position.x - (platLength / 2.0f) - 0.16f, earth.transform.position.y);
        rightCornerEarth.transform.position = new Vector2(earth.transform.position.x + (platLength / 2.0f) + 0.16f, earth.transform.position.y);


        previousPlatX_lower = earth.transform.position.x;
        previousPlatHalf_lower = platLength / 2.0f;
        previousPlatY_lower = earth.transform.position.y;
        previousLadderY_lower = 0.64f + 0.12f;

        previousPlatX_upper = earth.transform.position.x;
        previousPlatHalf_upper = platLength / 2.0f;
        previousPlatY_upper = earth.transform.position.y;
        previousLadderY_upper = -0.64f;

        upperTrigger = previousPlatY_upper + deltaY * (platformQuantity - 1);
        lowerTrigger = previousPlatY_lower - deltaY * (platformQuantity - 1);

        generateUpperChunk(deltaY, previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper, previousLadderY_upper);
        generateLowerChunk(deltaY, previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower, previousLadderY_lower);

    }

    private void FixedUpdate()
    {
        if (character.transform.position.y > upperTrigger)
        {
            upperTrigger = previousPlatY_upper + deltaY * (platformQuantity - 1);
            generateUpperChunk(deltaY, previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper, previousLadderY_upper);
        }
        else if (character.transform.position.y < lowerTrigger)
        {
            lowerTrigger = previousPlatY_lower - deltaY * (platformQuantity - 1);
            generateLowerChunk(deltaY, previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower, previousLadderY_lower);
        }
    }

    void generateUpperChunk(float deltaY, float previousPlatX, float previousPlatHalf, float previousPlatY, float previousLadderY)
    {
        for (int i = 1; i <= platformQuantity; i++)
        {
            GameObject platClone = Instantiate(earth);
            GameObject ladderClone = Instantiate(ladder);
            GameObject leftCornerClone = Instantiate(leftCornerEarth);
            GameObject rightCornerClone = Instantiate(rightCornerEarth);

            platLength = Random.Range(5, 40) * 0.32f;
            sr = platClone.gameObject.GetComponent<SpriteRenderer>();
            sr.size = new Vector2(platLength, sr.size.y);

            col = platClone.gameObject.GetComponent<BoxCollider2D>(); 
            col.size = new Vector2(sr.size.x + 0.61f, col.size.y); ;

            platClone.transform.position = new Vector2(Random.Range(previousPlatX - platLength / 2.0f + 0.28f, previousPlatX + platLength / 2.0f - 0.28f), previousPlatY + deltaY);

            leftCornerClone.transform.position = new Vector3(platClone.transform.position.x - (platLength / 2.0f) - 0.16f, previousPlatY + deltaY);
            rightCornerClone.transform.position = new Vector3(platClone.transform.position.x + (platLength / 2.0f) + 0.16f, previousPlatY + deltaY);
 
            float firstPoint = 0.0f, lastPoint = 0.0f;
            float platPosition = platClone.transform.position.x;
 
            if (previousPlatX < platPosition)
            {
                if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf < platPosition + platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = previousPlatX + previousPlatHalf;
                }
                else if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf > platPosition + platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = platPosition + platLength / 2.0f;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = previousPlatX + previousPlatHalf;
                }

            }
            else if (previousPlatX > platPosition)
            {
                if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = platPosition + platLength / 2.0f;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf < platPosition + platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = previousPlatX + previousPlatHalf;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf > platPosition + platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = platPosition + platLength / 2.0f;
                }
            }
            ladderClone.transform.position = new Vector2(Random.Range(firstPoint, lastPoint), previousLadderY + deltaY);

            previousPlatX = platPosition;
            previousPlatHalf = platLength / 2.0f;
            previousPlatY = platClone.transform.position.y;
            previousLadderY = ladderClone.transform.position.y;
           
            if (i == platformQuantity)
            {
                previousPlatX_upper = platPosition;
                previousPlatHalf_upper = platLength / 2.0f;
                previousPlatY_upper = platClone.transform.position.y;
                previousLadderY_upper = ladderClone.transform.position.y;
            }
        }
    }

    void generateLowerChunk(float deltaY, float previousPlatX, float previousPlatHalf, float previousPlatY, float previousLadderY)
    {
        for (int i = 1; i <= platformQuantity; i++)
        {
            GameObject platClone = Instantiate(earth);
            GameObject ladderClone = Instantiate(ladder);
            GameObject leftCornerClone = Instantiate(leftCornerEarth);
            GameObject rightCornerClone = Instantiate(rightCornerEarth);

            platLength = Random.Range(5, 40) * 0.32f;
            sr = platClone.gameObject.GetComponent<SpriteRenderer>();
            sr.size = new Vector2(platLength, sr.size.y);

            col = platClone.gameObject.GetComponent<BoxCollider2D>(); 
            col.size = new Vector2(sr.size.x + 0.61f, col.size.y); ;

            platClone.transform.position = new Vector2(Random.Range(previousPlatX - platLength / 2.0f + 0.28f, previousPlatX + platLength / 2.0f - 0.28f), previousPlatY - deltaY);

            leftCornerClone.transform.position = new Vector3(platClone.transform.position.x - (platLength / 2.0f) - 0.16f, previousPlatY - deltaY);
            rightCornerClone.transform.position = new Vector3(platClone.transform.position.x + (platLength / 2.0f) + 0.16f, previousPlatY - deltaY);

            float firstPoint = 0.0f, lastPoint = 0.0f;
            float platPosition = platClone.transform.position.x;

            if (previousPlatX < platPosition)
            {
                if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf < platPosition + platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = previousPlatX + previousPlatHalf;
                }
                else if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf > platPosition + platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = platPosition + platLength / 2.0f;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = previousPlatX + previousPlatHalf;
                }

            }
            else if (previousPlatX > platPosition)
            {
                if (previousPlatX - previousPlatHalf < platPosition - platLength / 2.0f)
                {
                    firstPoint = platPosition - platLength / 2.0f;
                    lastPoint = platPosition + platLength / 2.0f;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf < platPosition + platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = previousPlatX + previousPlatHalf;
                }
                else if (previousPlatX - previousPlatHalf > platPosition - platLength / 2.0f && previousPlatX + previousPlatHalf > platPosition + platLength / 2.0f)
                {
                    firstPoint = previousPlatX - previousPlatHalf;
                    lastPoint = platPosition + platLength / 2.0f;
                }
            }
            ladderClone.transform.position = new Vector2(Random.Range(firstPoint, lastPoint), previousLadderY - deltaY);

            previousPlatX = platPosition;
            previousPlatHalf = platLength / 2.0f;
            previousPlatY = platClone.transform.position.y;
            previousLadderY = ladderClone.transform.position.y;

            if (i == platformQuantity)
            {
                previousPlatX_lower = platPosition;
                previousPlatHalf_lower = platLength / 2.0f;
                previousPlatY_lower = platClone.transform.position.y;
                previousLadderY_lower = ladderClone.transform.position.y;
            }
        }
    } 
}
