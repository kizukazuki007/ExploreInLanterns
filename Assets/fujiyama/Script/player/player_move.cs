using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの番号
/// </summary>
public enum PlayerType
{
    player_1 = 1,
    player_2,
    player_3,
    player_4
}

public class player_move : MonoBehaviour
{
    public float speed = 1;

    //プレイヤーの番号を判別
    public PlayerType type;

    //仮想入力の名前
    [SerializeField]
    string Horizontal_p;
    string Vertical_p;

    public Sprite[] walk_down = new Sprite[2];
    public Sprite walk_down_last;

    public Sprite[] walk_up = new Sprite[2];
    public Sprite walk_up_last;

    public Sprite[] walk_right = new Sprite[3];
    public Sprite walk_riht_last;

    public Sprite[] walk_left = new Sprite[3];
    public Sprite walk_left_last;

    //Sprite[] arr = new Sprite[5]; 
    SpriteRenderer MainSprite;

    private int i = 0;

    int jught = 0;

    public int muki = 0;

    public int framecount = 30;

    [SerializeField, Tooltip("x")]
    int x;
    [SerializeField, Tooltip("y")]
    int y;

    Vector3 move2;

    // Use this for initialization
    void Start()
    {
        Horizontal_p = "P" + (int)type + "_Horizontal";
        Vertical_p = "P" + (int)type + "_Vertical";

        MainSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        x = (int)Input.GetAxis(Horizontal_p);
        y = (int)Input.GetAxis(Vertical_p);

        if (x == 0 && y == 0)
        {
            switch (muki)
            {
                case 1:
                    MainSprite.sprite = walk_riht_last;
                    break;
                case 2:
                    MainSprite.sprite = walk_left_last;
                    break;
                case 3:
                    MainSprite.sprite = walk_up_last;
                    break;
                case 4:
                    MainSprite.sprite = walk_down_last;
                    break;



            }
        }
        else
        {
            move2.x = x;
            move2.y = y;

            transform.position += move2.normalized * speed * Time.deltaTime;

            //右
            if (x > 0 || x == 1 && y == 1)
            {
                muki = 1;
                //transform.Translate(speed * Time.deltaTime, 0, 0);
                if (Time.frameCount % framecount == 0)
                {
                    if (i > 2)
                    {
                        i = 0;
                    }
                    MainSprite.sprite = walk_right[i];
                    i++;


                }
            }

            //左
            else if (x < 0)
            {
                muki = 2;
                //transform.Translate(-speed * Time.deltaTime, 0, 0);
                if (Time.frameCount % framecount == 0)
                {
                    if (i > 1)
                    {
                        i = 0;
                    }
                    MainSprite.sprite = walk_left[i];
                    i++;


                }


            }
            //上
            if (y==1&&x==0)
            {
                muki = 3;
                //transform.Translate(0, speed * Time.deltaTime, 0);
                if (Time.frameCount % framecount == 0)
                {
                    print(i);
                    if (i > 1)
                    {
                        i = 0;
                    }
                    MainSprite.sprite = walk_up[i];
                    i++;


                }
            }
            

            //下
            else if (y < 0&&x==0)
            {
            
                muki = 4;
               
                //if (Time.frameCount % framecount == 0)
                //{
                    if (Time.frameCount % framecount == 0)
                    {
                        if (i > 1)
                        {
                            i = 0;
                        }
                        MainSprite.sprite = walk_down[i];
                        i++;


                    }
               // }

                if (x != 0 && y != 0)
                {
                    Debug.Log("斜め");
                    if (y > 0)
                    {

                        if (Time.frameCount % framecount == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_up[i];
                            i++;
                        }
                    }
                    else
                    {

                        if (Time.frameCount % framecount == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_down[i];
                            i++;

                        }
                    }
                }

                    /*
                    //右
                    if (Input.GetAxis("Horizontal")>0)
                    {
                        muki = 1;
                        transform.Translate(speed * Time.deltaTime,0,0);
                        if (Time.frameCount % framecount == 0)
                        {
                             if (i > 2)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_right[i];
                            i++;


                        }
                    }

                    //左
                    else if (Input.GetAxis("Horizontal")<0)
                    {
                        muki = 2;   
                        transform.Translate(-speed * Time.deltaTime,0, 0);
                        if (Time.frameCount % framecount == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_left[i];
                            i++;


                        }


                    }
                    //上
                    if (Input.GetAxis("Vertical")>0||)
                    {
                        muki = 3;
                        transform.Translate(0,speed * Time.deltaTime,0);
                        if (Time.frameCount % framecount == 0)
                        {
                            print(i);
                            if (i > 1)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_up[i];
                            i++;


                        }
                    }
                    //else
                    //{
                    //    jught = 2;
                    //}

                    //下
                    if (Input.GetAxis("Vertical")<0)
                    {
                        //MainSprite.sprite = walk_down_last;
                        muki = 4;
                        transform.Translate(0, -speed * Time.deltaTime, 0);
                        if (Time.frameCount % framecount == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            MainSprite.sprite = walk_down[i];
                            i++;

                        }
                    }

                    else
                    {
                        switch (muki)
                        {
                            case 1:
                                MainSprite.sprite = walk_riht_last;
                                break;
                            case 2:
                                MainSprite.sprite = walk_left_last;
                                break;
                            case 3:
                                MainSprite.sprite = walk_up_last;
                                break;
                            case 4:
                                MainSprite.sprite = walk_down_last;
                                break;



                        }
                    }
                    */


                }
            }
        }
    }


