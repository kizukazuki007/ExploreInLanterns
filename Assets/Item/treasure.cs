using UnityEngine;
using System.Collections;

public class treasure : MonoBehaviour {


    GameObject UI_Con;

    int treasure_score;

    public string trasure_name;

    public string trasure_name2;

    public string trasure_name3;

    soundContolloer SE;
    

    // Use this for initialization


    void Awake()
    {
        SE = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
        

        UI_Con = GameObject.Find("UI_Controller");

        if (gameObject.name == trasure_name)
        {
            treasure_score = 10;
        }

        else if (gameObject.name == trasure_name2)
        {
            treasure_score = 100;
        }

        else if (gameObject.name == trasure_name3)
        {
            treasure_score = 1000;
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SE.select_SE(2);
            stautascontolloer.score += treasure_score;
            UI_Con.GetComponent<UI_Controller>().Set_Score(treasure_score);
            Destroy(gameObject);

        }

    }
}
