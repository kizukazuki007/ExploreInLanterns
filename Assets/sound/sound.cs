using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {

    soundContolloer sound_come;

    void Awake()
    {
        sound_come = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
    }

	// Use this for initialization
	void Start () {

        sound_come.select_BGM(3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
