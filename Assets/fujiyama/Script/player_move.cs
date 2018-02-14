using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {
    public float speed=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal")==1)
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }

        if (Input.GetAxis("Horizontal")==-1)
        {
            transform.Translate(-speed * Time.deltaTime,0, 0);
        }

        if (Input.GetAxis("Vertical")==1)
        {
            transform.Translate(0,speed * Time.deltaTime,0);
        }

        if (Input.GetAxis("Vertical")==-1)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
