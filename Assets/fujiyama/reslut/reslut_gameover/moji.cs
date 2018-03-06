using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moji : MonoBehaviour {
    
   
	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        moji_hyousji(2);
	
	}
    void moji_hyousji(int s = 0)
    {
        this.GetComponent<Text>().text = "到達階層: " + s +  "階";
    }


}
