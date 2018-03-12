using UnityEngine;
using System.Collections;

public class kine_up : MonoBehaviour {
    public float speed;

    public float time;
	// Use this for initialization
	void Start () {
        speed = 7.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed*Time.deltaTime, 0);

        time += Time.deltaTime;
        if (time > 1.0f)
        {
            Destroy(gameObject);
            time = 0.0f;
        }
	
	}
}
