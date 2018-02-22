using UnityEngine;
using System.Collections;


public class right_attack : MonoBehaviour {

    public float speed = 1.0f;

    private float time = 0.0f;

    public float rimit = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(speed*Time.deltaTime, 0, 0);

        if (time > rimit)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;

	
	}
}
