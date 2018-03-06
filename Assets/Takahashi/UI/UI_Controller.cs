using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {
    
    [SerializeField, Tooltip("player")]
    GameObject[] player;
    
    [SerializeField, Tooltip("洞窟名")]
    Text Cave_Name;
    
    [SerializeField, Tooltip("Score(Text)")]
    Text Score_Text;

    [SerializeField, Tooltip("Playerのランタン画像")]
    Image [] players_Image = new Image[4];

    [SerializeField, Tooltip("Playerのランタン中身")]
    Image [] players_Contents = new Image[4];
    
    [SerializeField,Tooltip("score(値)")]
    int score;
    
    [SerializeField, Tooltip("プレイ人数")]
    int Player_Number;

    // Use this for initialization
    void Start ()
    {
        //スコア初期化
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    
    //プレイ人数分 Canvas のランタン表示
    //最初一回だけ稼働
    void Set_PlayerImage()
    {
        for(int i = 0; i < Player_Number; i++)
        {
            players_Image[i].gameObject.SetActive(true);
        }
    }

    //スコア加算(他スクリプトから変更)　宝箱等からスコアが増えた時使用
    public void Set_Score(int plus)
    {
        score += plus;
        Score_Text.text = "Score:" + score.ToString("D6");
    }

    //洞窟名、階数表示　MAPの方からフロアが変わるときに使用
    public void Set_CaveName(int floor)
    {
        //洞窟名、階数表示
        Cave_Name.text = "暗闇の洞窟 " + floor + "/5 階";
    }

    //マップから設定する 1回だけ使用
    public void Set_player(GameObject[] player, int PNum)
    {
        this.player = new GameObject[PNum];
        Player_Number = PNum;
        for (int i = 0;i<PNum;i++)
        {
            this.player[i] = player[i];
        }

        //プレイヤーランタン画像セット
        Set_PlayerImage();

        //それぞれのImage_Controllerにプレイヤーを配布
        for (int i = 0; i < Player_Number; i++)
        {
            players_Contents[i].GetComponent<Image_Controller>().Set_Player(player[i]);
        }
    }
}
