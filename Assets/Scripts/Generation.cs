using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Generation : MonoBehaviour
{
    public GameObject character, earth, leftCornerEarth, rightCornerEarth, ladder, enemy, chest;
    public BoxCollider2D platCollider;
    SpriteRenderer earthProps, ladderProps;

    public float deltaY;
    public int platformQuantity;

    float previousPlatY, previousLadderY, previousPlatX, previousPlatHalf;

    float previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower;
    float previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper;

    float destPlatX_lower, destPlatHalf_lower, destPlatY_lower;
    float destPlatX_upper, destPlatHalf_upper, destPlatY_upper;

    float upperTrigger, lowerTrigger;

    private void Start()
    {
        float platLength = UnityEngine.Random.Range(5, 40) * 0.32f;
        earthProps = earth.gameObject.GetComponent<SpriteRenderer>();
        earthProps.size = new Vector2(platLength, earthProps.size.y);

        platCollider = earth.gameObject.GetComponent<BoxCollider2D>();
        platCollider.size = new Vector2(earthProps.size.x + 0.61f, platCollider.size.y);

        earth.transform.position = new Vector2(0.0f, 0.0f);
        leftCornerEarth.transform.position = new Vector2(earth.transform.position.x - (platLength / 2.0f) - 0.16f, earth.transform.position.y);
        rightCornerEarth.transform.position = new Vector2(earth.transform.position.x + (platLength / 2.0f) + 0.16f, earth.transform.position.y);

        previousPlatX = earth.transform.position.x;
        previousPlatHalf = platLength / 2.0f;
        previousPlatY = earth.transform.position.y;

        upperTrigger = previousPlatY + deltaY * (platformQuantity - 1);
        lowerTrigger = previousPlatY - deltaY * (platformQuantity - 1);

        generateChunk(deltaY, previousPlatX, previousPlatHalf, previousPlatY, ref destPlatX_upper, ref destPlatHalf_upper, ref destPlatY_upper);
        generateChunk(-deltaY, previousPlatX, previousPlatHalf, previousPlatY, ref destPlatX_lower, ref destPlatHalf_lower, ref destPlatY_lower);
    }

    private void FixedUpdate()
    {
        if (character.transform.position.y > upperTrigger)
        {
            generateChunk(deltaY, destPlatX_upper, destPlatHalf_upper, destPlatY_upper, ref previousPlatX_upper, ref previousPlatHalf_upper, ref previousPlatY_upper);
            generateChunk(deltaY, previousPlatX_upper, previousPlatHalf_upper, previousPlatY_upper, ref destPlatX_upper, ref destPlatHalf_upper, ref destPlatY_upper);
            upperTrigger = destPlatY_upper - deltaY;

        }
        else if (character.transform.position.y < lowerTrigger)
        {
            generateChunk(-deltaY, destPlatX_lower, destPlatHalf_lower, destPlatY_lower, ref previousPlatX_lower, ref previousPlatHalf_lower, ref previousPlatY_lower);
            generateChunk(-deltaY, previousPlatX_lower, previousPlatHalf_lower, previousPlatY_lower, ref destPlatX_lower, ref destPlatHalf_lower, ref destPlatY_lower);
            lowerTrigger = destPlatY_lower + deltaY;
        }
    }

    void generateChunk(float deltaY, float previousPlatX, float previousPlatHalf, float previousPlatY, ref float destX, ref float destHalf, ref float destY)
    {
        for (int i = 1; i <= platformQuantity; i++)
        {
            GameObject platClone = Instantiate(earth);
            GameObject ladderClone = Instantiate(ladder);
            GameObject leftCornerClone = Instantiate(leftCornerEarth);
            GameObject rightCornerClone = Instantiate(rightCornerEarth); 

            ladderProps = ladderClone.gameObject.GetComponent<SpriteRenderer>();
            ladderProps.size = new Vector2(ladderProps.size.x, deltaY);

            float platLength = UnityEngine.Random.Range(5, 40) * 0.32f;
            earthProps = platClone.gameObject.GetComponent<SpriteRenderer>();
            earthProps.size = new Vector2(platLength, earthProps.size.y);

            platCollider = platClone.gameObject.GetComponent<BoxCollider2D>();
            platCollider.size = new Vector2(earthProps.size.x + 0.61f, platCollider.size.y); ;

            platClone.transform.position = new Vector2(UnityEngine.Random.Range(previousPlatX - platLength / 2.0f + 0.28f, previousPlatX + platLength / 2.0f - 0.28f), previousPlatY + deltaY);
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
            float ladderPos = UnityEngine.Random.Range(firstPoint, lastPoint) * 100;
            int ladderPosInt = (int)ladderPos - (int)ladderPos % 32;
            ladderPos = (float)ladderPosInt / 100.0f;
            ladderClone.transform.position = new Vector2(ladderPos, (previousPlatY + platClone.transform.position.y) / 2.0f + earthProps.size.y / 2.0f);

            int k = 0;
            bool[] isFree = new bool[(int)(Math.Ceiling(platLength / 0.32f)) + 1];
            float[] poss = new float[(int)(Math.Ceiling(platLength / 0.32f)) + 1];
          
            for (float j = platPosition - platLength / 2.0f; j < platPosition + platLength / 2.0f; j += 0.32f, k++)
            {
                poss[k] = j;
                if (Math.Abs(ladderClone.transform.position.x - j) < 0.01)
                {
                    isFree[k] = false;
                }
                else
                {
                    isFree[k] = true;
                }
            }

            bool firstPropGenerated = false;

            generateUsingOdds(enemy, platClone, ref firstPropGenerated, 0.5f, ref isFree, poss, platLength);
            if (firstPropGenerated == true && platLength > 9 * 0.32f)
            {
                generateUsingOdds(enemy, platClone, ref firstPropGenerated, 0.9f, ref isFree, poss, platLength);
            }

            generateUsingOdds(chest, platClone, ref firstPropGenerated, 0.97f, ref isFree, poss, platLength);
 
            previousPlatX = platPosition;
            previousPlatHalf = platLength / 2.0f;
            previousPlatY = platClone.transform.position.y;

            if (i == platformQuantity)
            {
                destX = platPosition;
                destHalf = platLength / 2.0f;
                destY = platClone.transform.position.y;
            }
        }
    }

    void generateUsingOdds(GameObject obj, GameObject earth, ref bool success, float odds, ref bool[] CheckIsFree, float[] positions, float platLength)
    {
        if (UnityEngine.Random.Range(0f, 1f) > odds)
        {
            while (true)
            {
                int thePropPos = UnityEngine.Random.Range(0, (int)(platLength / 0.32f));
                if (CheckIsFree[thePropPos])
                {
                    GameObject propClone = Instantiate(obj);
                    propClone.transform.position = new Vector2(positions[thePropPos], earth.transform.position.y + 0.32f);
                    CheckIsFree[thePropPos] = false;
                    if (thePropPos < (int)(Math.Ceiling(platLength / 0.32f)) + 1)
                    {
                        CheckIsFree[thePropPos++] = false;
                    }
                    if (thePropPos > 0)
                    {
                        CheckIsFree[thePropPos--] = false;
                    }
                    success = true;
                    break;
                }
            }
        }
    }
    
}
