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


    void BGM_select(int i=0)
    {
        sound_come.select_BGM(i);
    }

    void SE_select(int j = 0)
    {
        sound_come.select_SE(j);
    }
}
