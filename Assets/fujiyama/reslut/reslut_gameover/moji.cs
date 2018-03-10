using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moji : MonoBehaviour {
    
   
	// Use this for initialization
	void Start ()
    {
        moji_hyousji();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
      void moji_hyousji()
    {
        this.GetComponent<Text>().text = "到達階層: " +MapManege.Floor  +  "階";
    }


}
