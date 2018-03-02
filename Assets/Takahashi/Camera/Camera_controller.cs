using UnityEngine;
using System.Collections;

public class Camera_controller : MonoBehaviour {

    [SerializeField,Tooltip("player")]
    GameObject[] players;

    [SerializeField, Tooltip("playerのオイル量")]
    float[] player_oil;

    [SerializeField, Tooltip("スピード")]
    float speed;

    [SerializeField,Tooltip("マルチかどうか")]
    bool multi = false;

    GameObject target_player,target_storage;
    new Vector3 Pos;
    float z;
    
	// Use this for initialization
	void Start ()
    {
        Start_Camera(players, 4);
	}
	
	// Update is called once per frame
	void Update ()
    {

        //マルチモード　カメラのターゲット変更
        if (multi)
        {
            Target();    
        }

        //ぬるぬる動く
        Pos = target_player.transform.position - transform.position;
        Pos.z = 0.0f;
        transform.position += Pos * Time.deltaTime * speed;
        
        
    }

    void Target()
    {
        float oil_max = 0;
        for(int i = 0;i < players.Length; i++)
        {
            player_oil[i] = players[i].GetComponent<Oil_Controller>().Get_Oil();
            if (oil_max < player_oil[i])
            {
                oil_max = player_oil[i];
                target_storage = players[i];
            }
        }
        target_player = target_storage;
    }

    //Map生成時に呼ぶ
    public void Start_Camera(GameObject [] player ,int PNum)
    {
        players = new GameObject[PNum];
        player_oil = new float[PNum];
        for (int i = 0;i < PNum; i++)
        {
            players[i] = player[i];
        }

        if(PNum == 1)
        {
            multi = false;
        }

        target_player = players[0];
        z = transform.position.z;

    }
    
}
