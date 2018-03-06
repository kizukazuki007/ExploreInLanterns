using UnityEngine;
using System.Collections;

public class player_2 : MonoBehaviour {
    int x;
    int y;

    float speed = 10.0f;

    Vector3 move2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        x = (int)Input.GetAxis("Horizontal");
        y = (int)Input.GetAxis("Vertical");
        
        move2.x = x;
        move2.y = y;

        transform.position += move2.normalized * speed * Time.deltaTime;

    }
}
