using UnityEngine;
using System.Collections;

public class anim : MonoBehaviour
{

    Vector3 strtpos; //現在地

    Vector3 nowpos; //今いる位置

    SpriteRenderer Mainsprite;

    public Sprite[] ani_up = new Sprite[3];

    public Sprite[] ani_down = new Sprite[3];

    public Sprite[] ani_right = new Sprite[3];

    public Sprite[] ani_left = new Sprite[3];



    [SerializeField, Tooltip("方向")]
    Vector3 place2;

    Vector3 place;

    Vector3 place3;

    Vector3 dir;



    int y = 0;

    int i = 0;

    

    

    Vector3 ford;
    // Use this for initialization
    void Start()
    {

        Mainsprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 2 == 0)
        {
            nowpos = transform.position; //移動した場所の位置を取得
            //place.x= nowpos.x * strtpos.x + nowpos.y * strtpos.y;
            //place2 = place.normalized;
        }
        else
        {
            strtpos = transform.position; //今現在の位置を取得
            //place.y = nowpos.x * strtpos.x + nowpos.y * strtpos.y;
            //place3 = place.normalized;

        }

        //dir = place2 - place3;


        place = nowpos - strtpos;
        place2 = place.normalized;

        
        if (place2.x > 0 && place2.y>0)
        {

            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_up[i];
                i++;
            }
        }
        else if(place2.x<0&& place2.y < 0)
        {

            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_down[i];
                i++;
            }
        }
        
        else if (place2.x > 0)
        {
            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_right[i];
                i++;
            }
        }

        else if (place2.x< 0)
        {
            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_left[i];
                i++;
            }
        }



        else if (place2.y > 0)
        {
            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_up[i];
                i++;
            }
        }
        else if (place2.y <0)
        {
            if (i > 2)
            {
                i = 0;
            }
            if (Time.frameCount % 10 == 0)
            {
                Mainsprite.sprite = ani_down[i];
                i++;
            }
        }
    }
}


       





        

        
