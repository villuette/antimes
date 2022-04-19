using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGparallax : MonoBehaviour
{
    public float GGy;
    public float BaseGGy;
    public float BGh;
    public float CAMh;
    public float speed = 5;
    public float Nmax = 20;
    Vector3 tv;
    public static float tvy;
    Vector3 GGbased;
    Transform GG;
    Transform CAM;
    SpriteRenderer sr;
    Vector3 Point_to_translate;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        CAM = GameObject.FindGameObjectWithTag("MainCamera").transform;
        GG = GameObject.FindGameObjectWithTag("Player").transform;
        GGbased = new Vector3(GG.position.x, GG.position.y,0);
        BaseGGy = GG.position.y;
        GGy = BaseGGy;
        transform.position = CAM.position;
        //if (Nmax > 0)
            Nmax = BaseGGy + Nmax;
        //else Nmax = BaseGGy - Nmax;
        BGh = sr.size.y;
        CAMh = CAM.gameObject.GetComponent<Camera>().pixelHeight / sr.sprite.pixelsPerUnit;
    }

    void Update()
    {
        tvy = tv.y;
        GGy = GG.position.y;
        tv = GG.position - GGbased;

        Point_to_translate = new Vector3(CAM.position.x,  (CAM.position.y - tv.y * (BGh - CAMh) /(Nmax)) - tv.y*3/Nmax, 0);
        
        if (Mathf.Abs(tv.y) > Nmax)
        {
            if (CAM.transform.position.y < transform.position.y)
                Point_to_translate = new Vector3(CAM.position.x, (CAM.position.y + (BGh - CAMh) + 3), 0);
            if (CAM.transform.position.y > transform.position.y)
                Point_to_translate = new Vector3(CAM.position.x, (CAM.position.y - (BGh - CAMh) - 3), 0);
        }
        //Vector3 currentPosition = Vector3.Lerp(transform.position, Point_to_translate, 1);
        Vector3 evect = Point_to_translate - transform.position;

        //transform.position = currentPosition;
        transform.Translate(evect * (float)(Time.deltaTime*speed));
    }
}
