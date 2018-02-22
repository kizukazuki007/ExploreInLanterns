using UnityEngine;
using System.Collections;

public class stautascontolloer : MonoBehaviour {

    // Use this for initialization
    public int[] number = new int[4];

    public int initial_value = 6;

    
    public int score = 0;

	void Start()
    { 
        for(int i = 0; i < number.Length; i++)
        {
            number[i] += initial_value;
        }

	
	}
	
	// Update is called once per frame
	
}
