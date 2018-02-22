using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    //受け渡し必要
    [SerializeField, Tooltip("player")]
    GameObject[] player;

    //受け渡し必要
    [SerializeField, Tooltip("洞窟名")]
    Text Cave_Name;
    
    [SerializeField, Tooltip("Score(Text)")]
    Text Score_Text;

    [SerializeField, Tooltip("Playerのランタン画像")]
    Image [] players_Image = new Image[4];

    [SerializeField, Tooltip("Playerのランタン中身")]
    Image [] players_Contents = new Image[4];

    //受け渡し必要
    [Tooltip("score(値)")]
    public static int score;

    //受け渡し必要
    [SerializeField, Tooltip("プレイ人数")]
    int Player_Number;

    // Use this for initialization
    void Start ()
    {
        score = 0;

        //プレイヤーランタン画像セット
        Set_PlayerImage(1);
        
        //それぞれのImage_Controllerにプレイヤーを配布
        for(int i = 0;i < Player_Number; i++)
        {
            players_Contents[i].GetComponent<Image_Controller>().Set_Player(player[i]);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
    
    //プレイ人数分 Canvas のランタン表示
    //一回だけ稼働
    public void Set_PlayerImage(int playerNum)
    {
        for(int i = 0; i < playerNum; i++)
        {
            players_Image[i].gameObject.SetActive(true);
        }
        Player_Number = playerNum;
    }

    //スコア加算(他スクリプトから変更)
    public void Set_Score(int plus)
    {
        score += plus;
        Score_Text.text = score.ToString("D6");
    }

    //リザルト用
    public int Get_Score()
    {
        return score;
    }

    //洞窟名、階数表示　MAPの方から設定する
    public void Set_CaveName(int floor)
    {
        //洞窟名、階数表示
        Cave_Name.text = "暗闇の洞窟" + floor + "/5階";
    }
}
