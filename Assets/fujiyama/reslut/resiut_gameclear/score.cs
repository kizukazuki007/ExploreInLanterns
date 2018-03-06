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
        _score = 100;//st.score;
        N_score = 0;
        cange = true;
        app = GameObject.Find("playera_app").GetComponent<player_app>();



        //Invoke("score_instanc",n);

    }

    void Update()
    {
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
        this.GetComponent<Text>().text = "score:  " + N_score;
        second += Time.deltaTime;

    }

    void score_instanc()
    {
        //this.GetComponent<Text>().text = "score:  " + stautascontolloer.score;
    }
}
	
	// Update is called once per frame

    
	
    
