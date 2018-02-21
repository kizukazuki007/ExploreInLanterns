using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    [SerializeField, Tooltip("洞窟名")]
    Text Cave_Name;

    [SerializeField, Tooltip("Score(Text)")]
    Text Score_Text;

    [SerializeField, Tooltip("Playerのランタン画像")]
    Image [] players = new Image[4];

    [SerializeField, Tooltip("score(値)")]
    float score;

    [SerializeField, Tooltip("Oilの量")]
    float Oil;

    [SerializeField, Tooltip("プレイ人数")]
    int Player_Number;

    // Use this for initialization
    void Start ()
    {
        Set_PlayerImage(1);
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
            players[i].gameObject.SetActive(true);
        }
        Player_Number = playerNum;
    }
}
