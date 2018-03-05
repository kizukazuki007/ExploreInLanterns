using UnityEngine;
using System.Collections;

public class P1_Move : MonoBehaviour
{

    public float speed = 1; // プレイヤーの速度

    public Sprite[] walk_down = new Sprite[2];
    public Sprite walk_down_last;

    public Sprite[] walk_up = new Sprite[2];
    public Sprite walk_up_last;

    public Sprite[] walk_right = new Sprite[3];
    public Sprite walk_riht_last;

    public Sprite[] walk_left = new Sprite[3];
    public Sprite walk_left_last;

    SpriteRenderer MainSprite;

    private int i = 0;

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

        MainSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        x = (int)Input.GetAxis("Horizontal");

        if (x != null)
        {
            print(x);
        }
        y = (int)Input.GetAxis("Vertical");



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
            if (y == 1 && x == 0)
            {
                muki = 3;

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
            else if (y < 0 && x == 0)
            {

                muki = 4;

                if (Time.frameCount % framecount == 0)
                {
                    print(i);
                    if (i > 1)
                    {
                        i = 0;
                    }
                    MainSprite.sprite = walk_down[i];
                    i++;
                }

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
            }
        }
    }
}
