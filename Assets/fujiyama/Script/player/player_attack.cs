using UnityEngine;
using System.Collections;

public class player_attack : MonoBehaviour {

    Vector3 playerpos;



    public GameObject[] ya = new GameObject[4];



    public GameObject[] knife = new GameObject[4];

    player_move direction;


    [SerializeField, Header("自分がどのプレイヤーか検索する プレイヤーの名前を入れる")]
    GameObject[] player;

    [SerializeField, Header("プレイヤー番号(デバッグ用)　※いじらない")]
    int num;

    public float time = 10.0f;

    public float rimit = 0.0f;

    public float kinfe_rimit = 0.0f;

    public float time_2=0.0f;

    stautascontolloer st;

    [SerializeField]
    string attack,attack2;

    soundContolloer SE;


    void Awake()
    {
        
        for (int i = 0; i < player.Length; i++)
        {
            if (gameObject.name == player[i].name) num = i;
        }
        attack = "P" + GetComponent<player_move>().Get_PlayerNumber() + "_attack";
        attack2 = "P" + GetComponent<player_move>().Get_PlayerNumber() + "_attack2";
    }


    // Use this for initialization
    void Start () {

        direction = GetComponent<player_move>();
        SE = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();

        time = 10.0f;

        st = GameObject.Find("statusContolloer").GetComponent<stautascontolloer>();
    }
    
    // Update is called once per frame
    void Update ()

    {
        playerpos = transform.position;

        if (st.ya_honnsu[num] > 0)
        {


            if (Input.GetButtonDown(attack))
            {
                switch (direction.muki)
                {
                    case 1:
                        ya[0].transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
                        if (time > rimit)
                        {
                            SE.select_SE(0);
                            Instantiate(ya[0]);
                            time = 0.0f;
                            st.ya_honnsu[num] -= 1;
                        }

                        break;
                    case 2:

                        ya[1].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            SE.select_SE(0);
                            Instantiate(ya[1]);
                            time = 0.0f;
                            st.ya_honnsu[num] -= 1;
                        }
                        break;
                    case 3:

                        ya[2].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            SE.select_SE(0);
                            Instantiate(ya[2]);
                            time = 0.0f;
                            st.ya_honnsu[num] -= 1;
                        }
                        break;
                    case 4:

                        ya[3].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            SE.select_SE(0);
                            Instantiate(ya[3]);
                            time = 0.0f;
                            st.ya_honnsu[num] -= 1;
                        }
                        break;
                }

            }

        }
        if (Input.GetButtonDown(attack2))
        {
            switch (direction.muki)
            {
                case 1:
                    knife[0].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time_2 > kinfe_rimit)
                    {
                        SE.select_SE(1);
                        Instantiate(knife[0]);
                        time_2 = 0.0f;
                    }
                    break;
                case 2:
                    knife[1].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time_2 > kinfe_rimit)
                    {
                        SE.select_SE(1);
                        Instantiate(knife[1]);
                        time_2 = 0.0f;
                    }             
                    break;
                case 3:
                    knife[2].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time_2 > kinfe_rimit)
                    {
                        SE.select_SE(1);
                        Instantiate(knife[2]);
                        time_2 = 0.0f;
                    }
                    break;
                case 4:
                    knife[3].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time_2 > kinfe_rimit)
                    {
                        SE.select_SE(1);
                        Instantiate(knife[3]);
                        time_2 = 0.0f;
                    }
                    break;
            }

        }

        time += Time.deltaTime;
        time_2 += Time.deltaTime;

        

        }

        
    
    }

