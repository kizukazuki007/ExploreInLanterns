using UnityEngine;
using System.Collections;

public class stairs : MonoBehaviour {

    // Use this for initialization


    // Update is called once per frame

    soundContolloer SE;

    void Awake()
    {
        SE = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
    }
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SE.select_SE(4);
            MapManege move = GameObject.Find("MAPCreate").GetComponent<MapManege>();
            move.StairsUP();
        }
    }
}
