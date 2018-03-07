using UnityEngine;
using System.Collections;

public class stairs : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MapManege move = GameObject.Find("MAPCreate").GetComponent<MapManege>();
            move.StairsUP();
        }
    }
}
