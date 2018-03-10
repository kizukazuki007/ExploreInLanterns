using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    stautascontolloer st;
    public float n;
    [SerializeField]
    int _score;
    [SerializeField]
    int N_score;
    bool cange;

    int rimit = 2;

    float second = 0;

    player_app app;




    // Use this for initialization
    void Start()
    {
        _score = stautascontolloer.score_get();//st.score;
        N_score = 0;
        cange = true;
        app = GameObject.Find("playera_app").GetComponent<player_app>();


        

    }

    void Update()
    {
        if ((Input.GetButtonDown("P1_D") || Input.GetButtonDown("P2_D") || Input.GetButtonDown("P3_D") || Input.GetButtonDown("P4_D")) && cange == true)
        {
            N_score = _score;
        }

        if (second > rimit)
        {


            if (cange)
            {
                if (_score == N_score)
                {
                    cange = false;
                    app.onflg = true;
                    
                }
                else
                {
                    N_score++;
                }


            }


        }
        else
        {
            second += Time.deltaTime;
        }
        this.GetComponent<Text>().text = "score:  " + N_score;


    }
    
}
	
	// Update is called once per frame

    
	
    
