using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Controller : MonoBehaviour {

    //プレイヤー(プレハブ)につける
    [SerializeField, Tooltip("player")]
    GameObject Player;

    GameObject UI_Controller;

    [SerializeField]
    float Oil;

    float Oil_Max = 180.0f;
    int Number;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //プレイヤーからオイル量を引っ張ってくる
        Oil = Player.GetComponent<Oil_Controller>().Get_Oil();

        //オイル量から割合を出し、その割合分Contentsの表示を変更
        GetComponent<Image>().fillAmount = Oil / Oil_Max;

        if (Oil == 0.0f)
        {
            UI_Controller.GetComponent<UI_Controller>().Player_Death(Number);
        }
	}

    //プレイヤーをスクリプト内の変数にセット
    public void Set_Player(GameObject player,GameObject UI_Con,int Num)
    {
        Player = player;
        UI_Controller = UI_Con;
        Number = Num;
    }
}
