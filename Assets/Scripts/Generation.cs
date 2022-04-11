using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Generation : MonoBehaviour
{
    public GameObject character, earth, leftCornerEarth, rightCornerEarth, ladder, enemy, gchest, wchest; //originals
    GameObject platClone, ladderClone, leftCornerClone, rightCornerClone; //copies

    bool[] isFree, latestUpIsFree, latestDownIsFree;
    float[] poss, latestUpPoss, latestDownPoss;

    int PerfectPlatSize = 0, latestPerfectUp = 0, latestPerfectDown = 0;
    float latestUP_y, latestDown_y, latestUP_x, latestDown_x,
        latestUP_half, latestDown_half, latestUP_ladder, latestDown_ladder; //sheesh there is so much vars......... exactly idk how to realize easier

    float ladderAbove = 0; //верхняя лестница при стартовой генерации
    BoxCollider2D platCollider;
    SpriteRenderer earthSR, ladderSR;
    float margin = 0.96f;
    public float StartDeltaY;
    public int platformQuantity; // num of plats in chunk
    bool goFirstTime;


    public float upperTrigger, lowerTrigger;

    private void Start()
    {
        latestUpIsFree = isFree;
        latestDownIsFree = isFree;
        latestUpPoss = poss;
        latestDownPoss = poss;

        goFirstTime = true;
        float platLength = UnityEngine.Random.Range(30, 30) * 0.32f;//resizing platform

        earthSR = earth.gameObject.GetComponent<SpriteRenderer>();
        earthSR.size = new Vector2(platLength, earthSR.size.y); //resize sprite

        platCollider = earth.gameObject.GetComponent<BoxCollider2D>();
        platCollider.size = new Vector2(earthSR.size.x + 0.55f, platCollider.size.y); //resize collider

        earth.transform.position = new Vector2(0.0f, 0.0f); //based pos
        leftCornerEarth.transform.position = new Vector2(earth.transform.position.x - (platLength / 2.0f) - 0.16f, earth.transform.position.y); //replacing corners
        rightCornerEarth.transform.position = new Vector2(earth.transform.position.x + (platLength / 2.0f) + 0.16f, earth.transform.position.y);


        upperTrigger = +StartDeltaY * (platformQuantity - 1); //set trigger highs to generate
        lowerTrigger = -StartDeltaY * (platformQuantity - 1);

        latestUP_y = earth.transform.position.y;
        latestDown_y = earth.transform.position.y;
        latestUP_x = earth.transform.position.x;
        latestDown_x = earth.transform.position.x;
        latestUP_half = earthSR.size.x / 2.0f;
        latestDown_half = earthSR.size.x / 2.0f;
        latestUP_ladder = ladder.transform.position.x;
        latestDown_ladder = ladder.transform.position.x;

        platClone = earth;//set clones as start objects
        leftCornerClone = leftCornerEarth;
        rightCornerClone = rightCornerEarth;
        ladderClone = ladder;

        generateChunk(StartDeltaY); //up before down

        platClone = earth; //re-set clones as start objects (start-only)
        leftCornerClone = leftCornerEarth;
        rightCornerClone = rightCornerEarth;
        ladderClone = ladder;

        generateChunk(-1 * StartDeltaY);
        goFirstTime = false;
        //upperTrigger += StartDeltaY * (platformQuantity - 1);
        //lowerTrigger -= StartDeltaY * (platformQuantity - 1);
    }

    private void FixedUpdate()
    {
        if (character.transform.position.y > upperTrigger)
        {
            upperTrigger += StartDeltaY * platformQuantity;
            generateChunk(StartDeltaY);

        }
        else if (character.transform.position.y < lowerTrigger)
        {
            lowerTrigger -= StartDeltaY * platformQuantity;
            generateChunk(-StartDeltaY);
        }
    }

    void generateChunk(float deltaY)
    {

        for (int i = 1; i <= platformQuantity; i++)
        {
            float previousPlatY;// taking prev properties as latest of its orientation
            float previousPlatHalf;
            float previousPlatX;
            float prevLadderPosX;

            if (deltaY > 0) //determinate prevs
            {
                if (latestPerfectUp != 0)
                {
                    PerfectPlatSize = latestPerfectUp;
                    isFree = new bool[latestPerfectUp];
                    poss = new float[latestPerfectUp];
                    latestUpIsFree.CopyTo(isFree, 0);
                    latestUpPoss.CopyTo(poss, 0);
                }

                previousPlatY = latestUP_y;
                previousPlatX = latestUP_x;
                prevLadderPosX = latestUP_ladder;
                previousPlatHalf = latestUP_half;
            }
            else
            {
                if (latestPerfectDown != 0)
                {
                    PerfectPlatSize = latestPerfectDown;
                    isFree = new bool[latestPerfectDown];
                    poss = new float[latestPerfectDown];
                    latestDownIsFree.CopyTo(isFree, 0);
                    latestDownPoss.CopyTo(poss, 0);
                }

                previousPlatY = latestDown_y;
                previousPlatX = latestDown_x;
                prevLadderPosX = latestDown_ladder;
                previousPlatHalf = latestDown_half;
            }

            platClone = Instantiate(earth);
            ladderClone = Instantiate(ladder);
            leftCornerClone = Instantiate(leftCornerEarth);
            rightCornerClone = Instantiate(rightCornerEarth); //re-refs to new objects

            ladderSR = ladderClone.gameObject.GetComponent<SpriteRenderer>(); //resizing ladder
            ladderSR.size = new Vector2(ladderSR.size.x, deltaY);

            float platLength = UnityEngine.Random.Range(42, 42) * 0.32f;//resizing platform
                                                                        //probably you had to self-answering - why is 15? 
                                                                        //bicoz at least halfsize of plat must be composed of 2 margins (ladder can be placed at max on the middle of intersection)
                                                                        // and include ladders widths. now i cant understand how the width going but it works...  my eng so darn but its ok coz i have done your work and you must suck my ass///

            earthSR = platClone.gameObject.GetComponent<SpriteRenderer>();
            earthSR.size = new Vector2(platLength, earthSR.size.y);

            platCollider = platClone.gameObject.GetComponent<BoxCollider2D>(); //resizing collider
            platCollider.size = new Vector2(earthSR.size.x + 0.61f, platCollider.size.y); ;

            float platPosition = UnityEngine.Random.Range(previousPlatX - platLength / 2.0f, previousPlatX + platLength / 2.0f);
            platPosition *= 100;
            int platPositionInt = (int)platPosition - (int)platPosition % 32;
            platPosition = platPositionInt / 100.0f;
            platClone.transform.position = new Vector2(platPosition, previousPlatY + deltaY); //position

            leftCornerClone.transform.position = new Vector3(platClone.transform.position.x - (platLength / 2.0f) - 0.16f, platClone.transform.position.y);
            rightCornerClone.transform.position = new Vector3(platClone.transform.position.x + (platLength / 2.0f) + 0.16f, platClone.transform.position.y);



            float firstPoint = Mathf.Max((previousPlatX - previousPlatHalf), (platPosition - platLength / 2.0f)); //takes intersection of both plats
            float lastPoint = Mathf.Min((previousPlatX + previousPlatHalf), (platPosition + platLength / 2.0f)); //mummy there was so much strings so i replaced they to this ones (lukz good, right?)

            if (goFirstTime && i == 1)////////////конструкция позволит сгенерировать две лестницы с отступом margin - в самом начале уровня/////////////////////////
            {
                if (deltaY > 0) //в этой части кода вообще проблем не ищи -_-
                {
                    float ladderPosc = UnityEngine.Random.Range(firstPoint, lastPoint);
                    ladderPosc *= 100;
                    int ladderPosIntc = (int)ladderPosc - (int)ladderPosc % 32;
                    ladderPosc = ladderPosIntc / 100.0f;
                    ladderAbove = ladderPosc; //main different (operating with vice versa oriented ladder)
                    ladderClone.transform.position = new Vector2(ladderPosc, (previousPlatY + platClone.transform.position.y) / 2.0f + earthSR.size.y / 2.0f);
                    goto laddergenskip;
                }
                if (deltaY < 0)
                {
                    float prevFirstPointc = ladderAbove - margin;
                    float prevLastPointc = ladderAbove + margin;
                    float ladderPosc = UnityEngine.Random.Range(firstPoint, lastPoint);

                    while (ladderPosc > prevFirstPointc && ladderPosc < prevLastPointc)
                        ladderPosc = UnityEngine.Random.Range(firstPoint, lastPoint);
                    ladderPosc *= 100;
                    int ladderPosIntc = (int)ladderPosc - (int)ladderPosc % 32;
                    ladderPosc = ladderPosIntc / 100.0f;
                    ladderClone.transform.position = new Vector2(ladderPosc, (previousPlatY + platClone.transform.position.y) / 2.0f + earthSR.size.y / 2.0f);
                    goto laddergenskip;
                }
            }
        laddergenstart: //точка спавна всех лестниц (ну почти)
            float prevFirstPoint = prevLadderPosX - margin; //common ladder generation
            float prevLastPoint = prevLadderPosX + margin;
            float ladderPos = UnityEngine.Random.Range(firstPoint, lastPoint);

            while (ladderPos > prevFirstPoint && ladderPos < prevLastPoint) //holy shit it was so hard to realize meh......2 strings bro......
                ladderPos = UnityEngine.Random.Range(firstPoint, lastPoint);//returns a place outside the margin of prev ladder ;)

            ladderPos *= 100;
            int ladderPosInt = (int)ladderPos - (int)ladderPos % 32; //танцы с бубном какиета (но вроде работает)
            ladderPos = (float)ladderPosInt / 100.0f;

            for (int p = 0; p < PerfectPlatSize; p++)
            {
                if (Mathf.Abs(poss[p] - ladderPos) < 0.1 && ((p > 0 && p < PerfectPlatSize - 1 && isFree[p - 1] && isFree[p] && isFree[p + 1])
                    || (p == 0 && isFree[p] && isFree[p + 1])
                    || (p == PerfectPlatSize - 1 && isFree[p - 1] && isFree[p]))) //вот тут самое интересное, нужно чтобы ничего нигде не ломалось, но я не могу((((((((((
                {
                    ladderClone.transform.position = new Vector2(poss[p], (previousPlatY + platClone.transform.position.y) / 2.0f + earthSR.size.y / 2.0f);

                    isFree[p] = false;
                    if (p > 0)
                        isFree[p - 1] = false;
                    if (p < PerfectPlatSize)
                        isFree[p + 1] = false;
                    goto laddergenskip;
                }
            }
            goto laddergenstart; /*если лестница аккурат падает на занятую точку (в массиве сохраненному с прошлого прохода) 
                                 то заново ищет в рандоме пока не найдёт 
                                 более подходящее*/

        laddergenskip: //метка для пропуска повторной генерации лестницы на первом уровне


            //int k = 0;
            platPosition *= 100;
            float platHalf = platLength / 2.0f;
            platHalf *= 100;
            platPositionInt = (int)platPosition - (int)platPosition % 32;
            int platHalfInt = (int)platHalf - (int)platHalf % 32;
            platPosition = platPositionInt / 100.0f;
            platHalf = platHalfInt / 100.0f;
            PerfectPlatSize = platHalfInt / 16 + 2; //mmmm es
            isFree = new bool[PerfectPlatSize];
            poss = new float[PerfectPlatSize];

            for (int j = platPositionInt - platHalfInt, k = 0; j <= platPositionInt + platHalfInt; j += 32, k++)
            {
                poss[k] = j / 100.0f;
                isFree[k] = true;
                //Debug.Log(j / 100.0f);

                if (Math.Abs(ladderClone.transform.position.x - j / 100.0f) < 0.1)
                {
                    isFree[k] = false;
                    if (k > 0)
                        isFree[k - 1] = false;
                    if (k < PerfectPlatSize - 1)
                        isFree[k + 1] = false;
                }

            }


            if (GenerateUsingOdds(enemy, platClone, 0.9f, PerfectPlatSize) && PerfectPlatSize > 20)
            {
                GenerateUsingOdds(enemy, platClone, 0.9f, PerfectPlatSize);
            }

            GenerateUsingOdds(wchest, platClone, 0.97f, PerfectPlatSize);
            GenerateUsingOdds(gchest, platClone, 0.97f, PerfectPlatSize);


            if (deltaY > 0) //saving lasts
            {
                latestUP_y = platClone.transform.position.y;
                latestUP_x = platClone.transform.position.x;
                latestUP_ladder = ladderClone.transform.position.x;
                latestUP_half = platClone.GetComponent<SpriteRenderer>().size.x / 2.0f;
                latestUpIsFree = new bool[PerfectPlatSize];
                isFree.CopyTo(latestUpIsFree, 0);
                latestUpPoss = new float[PerfectPlatSize];
                poss.CopyTo(latestUpPoss, 0);
                latestPerfectUp = PerfectPlatSize;
            }
            if (deltaY < 0)
            {
                latestDown_y = platClone.transform.position.y;
                latestDown_x = platClone.transform.position.x;
                latestDown_ladder = ladderClone.transform.position.x;
                latestDown_half = platClone.GetComponent<SpriteRenderer>().size.x / 2.0f;
                latestDownIsFree = new bool[PerfectPlatSize];
                isFree.CopyTo(latestDownIsFree, 0);
                latestDownPoss = new float[PerfectPlatSize];
                poss.CopyTo(latestDownPoss, 0);
                latestPerfectDown = PerfectPlatSize;
            }
            //GC.Collect();

        }

    }

    bool GenerateUsingOdds(GameObject obj, GameObject earth, float odds, int ArrSize)
    {
        if (UnityEngine.Random.Range(0f, 1f) < odds)
        {
            while (true)
            {
                int thePropPos = UnityEngine.Random.Range(0, ArrSize - 1);
                if (isFree[thePropPos])
                {
                    GameObject objClone = Instantiate(obj);
                    objClone.transform.position = new Vector2(poss[thePropPos], earth.transform.position.y + 0.32f);
                    isFree[thePropPos] = false;
                    if (thePropPos < ArrSize - 1)
                        isFree[thePropPos + 1] = false;
                    if (thePropPos > 0)
                        isFree[thePropPos - 1] = false;

                    return true;
                }
            }
        }
        return false;
    }

}
