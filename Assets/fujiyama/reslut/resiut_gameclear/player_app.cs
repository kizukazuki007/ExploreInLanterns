using UnityEngine;
using System.Collections;

public class player_app : MonoBehaviour {

    public GameObject[] player = new GameObject[4];

    int player_num=4;

    public int i = 0;

    public bool onflg = false;

    

    
    

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (onflg)
        {
            if (i < player_num)
            {
                if (Time.frameCount % 10 == 0)
                {
                    Instantiate(player[i]);
                    i++;
                }
               

            }
        }
	}
}
