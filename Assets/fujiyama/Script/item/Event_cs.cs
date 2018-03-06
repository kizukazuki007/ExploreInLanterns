using UnityEngine;
using System.Collections;


public class Event_cs : MonoBehaviour {

    public int Type = 1;//識別の数字

    SpriteRenderer MainspriteRender;
    public Sprite BoxOpen;

    public Sprite wanaWorking;

    public bool openflg = false;

    [SerializeField, Tooltip("乱数")]
    int range;

    int hougyouku;

    [SerializeField, Tooltip("pos")]
    Vector3 pos;

    bool seisei = true;//生成のやつ

    [SerializeField, Tooltip("宝玉３")]
    GameObject hougyo3;

    [SerializeField, Tooltip("宝玉２")]
    GameObject hougyo2;

    [SerializeField, Tooltip("宝玉")]
    GameObject hougyo;

    GameObject yapre;

    GameObject oill;

    GameObject hougyoukudesu;

    GameObject trap_Im;

    public GameObject move;
    int yumiya = 0; //弓矢の本数 

    [SerializeField]
    int max = 10;


    public int number = 0;

    int save; //ランダム保存用

    int save2;   //ランダム(宝玉)保存用

    player_move man;

    public int score = 0;

    public int score1 = 10; //宝玉３用

    public int score2 = 100; //２宝玉用

    public int score3 = 1; //火竜の宝玉用  

    stautascontolloer status;

    GameObject subjects = null;

    public float time = 0.0f;

    bool claerFlg = false;

    [SerializeField]
    string [] playername;

    int PNum;


    // Use this for initialization
    void Start()
    {
        MainspriteRender = GetComponent<SpriteRenderer>();

        pos = transform.position;

        hougyo3 = (GameObject)Resources.Load("宝玉3");

        hougyo2 = (GameObject)Resources.Load("２宝玉");

        hougyo = (GameObject)Resources.Load("火竜");

        yapre = (GameObject)Resources.Load("ya");

        oill = (GameObject)Resources.Load("oil1");

        trap_Im = (GameObject)Resources.Load("wana");


        status = GameObject.Find("statusContolloer").GetComponent<stautascontolloer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (claerFlg)
        {
            time += Time.deltaTime;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //print("反応"); //デバッグ

        if (other.tag == "Player")
        {
            subjects = other.gameObject;

            for (int i = 0; i < PNum; i++)
            {
                if (subjects.name == playername[i])
                {
                    number = i;
                    i = PNum;
                }
            }
        }

        /*
        if (subjects.name == playername) number = 0;

        if (subjects.name == playername2) number = 1;

        if (subjects.name == playername3) number = 2;

        if (subjects.name == playername4) number = 3;
        */


        //print(subjects);

        if (Type == 1 && other.tag == "Player") stairs(); //階段

        if (Type == 2 && other.tag == "Attack") trasureChest(); //宝箱を空ける前

        if (Type == 2 && other.tag == "Player" && openflg == true) trsureChestopen(number, subjects); //宝箱が開いた時

        if (Type == 3 && other.tag == "Player") trap(subjects);//罠
    }


    public void stairs()
    {
        print("階段");

        MapManege move = GameObject.Find("MAPCreate").GetComponent<MapManege>();
        move.StairsUP();
    }


    public void trasureChest()
    {
        print("宝箱のメソッド");

        MainspriteRender.sprite = BoxOpen;

        range = Random.Range(0, 100);

        save = range;




        if (range <= 20) //20以下
        {
            if (seisei == true)
            {
                print("aaaaa");

                yapre.transform.position = pos;//new Vector3(pos.x, pos.y, 0);
                Instantiate(yapre);
                seisei = false;

            }
        }




        else if (range > 60) //6０より上
        {
            if (seisei == true)
            {
                hougyouku = Random.Range(0, 100);
                save2 = hougyouku;
                if (hougyouku <= 20) //宝玉３生成　20%
                {
                    //GameObject hougyo3 = (GameObject)Resources.Load("宝玉3");
                    hougyo3.transform.position = pos;// new Vector3(pos.x, pos.y, 0);
                    Instantiate(hougyo3);
                    seisei = false;
                    hougyoukudesu = GameObject.Find("宝玉3(Clone)");
                }

                else if (hougyouku >= 80) //宝玉２生成　20%
                {
                    //GameObject hougyo2 = (GameObject)Resources.Load("２宝玉");
                    hougyo2.transform.position = pos;//new Vector3(pos.x, pos.y, 0);
                    Instantiate(hougyo2);
                    seisei = false;
                    hougyoukudesu = GameObject.Find("２宝玉(Clone)");

                }
                else //それ以外
                {
                    //GameObject hougyo = (GameObject)Resources.Load("宝玉");
                    hougyo.transform.position = pos; // new Vector3(pos.x, pos.y, 0);
                    Instantiate(hougyo);
                    seisei = false;
                    hougyoukudesu = GameObject.Find("火竜(Clone)");

                }

            }
        }


        //if (range >= 90)  //８０以上
        else
        {
            if (seisei == true)
            {
                oill.transform.position = pos;// new Vector3(pos.x, pos.y, 0);
                Instantiate(oill);
                seisei = false;
            }

        }

        openflg = true;


        // gameObject.SetActive(false);
    }

    public void trsureChestopen(int num, GameObject player)
    {

        if (save <= 20) //矢
        {
            int yuram = Random.Range(1, 4);

            if (status.ya_honnsu[num] < max)
            {
                status.ya_honnsu[num] += yuram;
            }
            else
            {
                status.ya_honnsu[num] = max;
            }


            Destroy(GameObject.Find("ya(Clone)"));

        }

        if (range > 60) //スコア関連
        {
            if (save2 <= 20)
            {
                stautascontolloer.score += score1;
                status.GetComponent<stautascontolloer>().score_set(score1);
            }

            else if (save2 >= 80)
            {
                stautascontolloer.score += score2;
                status.GetComponent<stautascontolloer>().score_set(score2);
            }

            else
            {
                stautascontolloer.score += score3;
                status.GetComponent<stautascontolloer>().score_set(score3);
            }

            Destroy(hougyoukudesu);
        }

        else
        {
            float plus = 0.0f;
            int oil = Random.Range(0, 100);
            if (oil >= 30)
            {
                plus = 15.0f;
            }

            else if (oil >= 60)
            {
                plus = 30.0f;
            }

            if (oil >= 61)
            {
                plus = 60.0f;
            }
            else if (oil >= 90)
            {
                plus = 100.0f;
            }
            else
            {
                plus = 180.0f;
            }

            player.GetComponent<Oil_Controller>().Set_Oil(plus);
            Destroy(GameObject.Find("oil1(Clone)"));
        }


    }

    public void trap(GameObject player)
    {
        MainspriteRender.sprite = wanaWorking;
        
        player.GetComponent<player_move>().enabled = false;

        claerFlg = true;
        trapClear(player);
    }

    public void trapClear(GameObject ply)
    {

        print("発動しました");
      
        if (time > 4.0f)
        {

            //print("ffghddjdkkdkdk");
            ply.GetComponent<player_move>().enabled = true;
            Destroy(GameObject.Find("wana(Clone)"));
            claerFlg = false;
            time = 0.0f;
        }

    }

    //プレイヤーネーム　MAPから呼び出す
    public void Set_PlayerName(GameObject [] player ,int PlayerNum)
    {
        PNum = PlayerNum;
        playername = new string[PNum];
        for(int i =0;i<PNum;i++)
        {
            playername[i] = player[i].name;
        }
    }

    

}

