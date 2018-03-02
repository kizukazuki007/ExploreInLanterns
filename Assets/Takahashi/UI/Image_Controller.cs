using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Controller : MonoBehaviour {

    //プレイヤー(プレハブ)につける
    [SerializeField, Tooltip("player")]
    GameObject Player;

    [SerializeField]
    float Oil;

    float Oil_Max = 180.0f;

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
	}

    //プレイヤーをスクリプト内の変数にセット
    public void Set_Player(GameObject player)
    {
        Player = player;
    }
}
