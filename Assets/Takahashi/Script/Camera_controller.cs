using UnityEngine;
using System.Collections;

public class Camera_controller : MonoBehaviour {

    [SerializeField,Tooltip("player")]
    GameObject[] players;
    [SerializeField, Tooltip("playerのオイル量")]
    float[] player_oil;

    GameObject target_player,target_storage;
    new Vector3 Pos;
    bool multi = false;
    float z;
    
	// Use this for initialization
	void Start ()
    {
        target_player = players[0];
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (multi)
        {
            Target();    
        }

        //ぬるぬる動く
        Pos = target_player.transform.position - transform.position;
        Pos.z = 0.0f;
        transform.position += Pos * Time.deltaTime;

        //かくかく動く
        /*
        Pos = target_player.transform.position;
        Pos.z = z;
        transform.position = Pos;
        */
    }

    void Target()
    {
        float oil_max = 0;
        for(int i = 0;players[i] != null; i++)
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
}
