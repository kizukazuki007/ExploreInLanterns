using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player_app : MonoBehaviour {

    public GameObject[] player = new GameObject[4];

    int player_num;

    public int i = 0;

    public bool onflg = false;

    

    
    

	// Use this for initialization
	void Start ()
    {
        player_num = TitleSystem.Get_Member();
	
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
            else if(Input.GetButtonDown("P1_D")|| Input.GetButtonDown("P2_D")|| Input.GetButtonDown("P3_D")|| Input.GetButtonDown("P4_D"))
            {
                SceneManager.LoadScene("Title");
            }

        }
	}
}
