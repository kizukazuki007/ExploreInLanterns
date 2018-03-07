using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


/// <summary>
/// プレイヤーの番号
/// </summary>
public enum Player_Type
{
    player_1 = 1,
    player_2,
    player_3,
    player_4
}

public class JoinSystem : MonoBehaviour {

    //プレイヤーの番号を判別
    public Player_Type type;

    public GameObject P1entry;
    public GameObject P2entry;
    public GameObject P3entry;
    public GameObject P4entry;

    static int Member;

    public bool P1_join = false;
    public bool P2_join = false;
    public bool P3_join = false;
    public bool P4_join = false;

    // Use this for initialization
    void Start () {
        Member=TitleSystem.Get_Member();

        P1entry = GameObject.Find("1P_E");
        P2entry = GameObject.Find("2P_E");
        P3entry = GameObject.Find("3P_E");
        P4entry = GameObject.Find("4P_E");
        

    }
	
	// Update is called once per frame
	void Update () {
        Join();

    }

    void Join()
    {
        if (Input.GetButtonDown("P1_D") && P1_join == false)
        {
            Member++;
            P1_join = true;
            this.P1entry.GetComponent<Text>().text = "1P OK";
        }

        else if (Input.GetButtonDown("P2_D") && P2_join == false)
        {
            Member++;
            P2_join = true;
            this.P2entry.GetComponent<Text>().text = "2P OK";
        }

        else if (Input.GetButtonDown("P3_D") && P3_join == false)
        {
            Member++;
            P3_join = true;
            this.P3entry.GetComponent<Text>().text = "3P OK";
        }

         else if (Input.GetButtonDown("P4_D") && P4_join == false)
        {
            Member++;
            P4_join = true;
            this.P4entry.GetComponent<Text>().text = "4P OK";
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("");
        }
    }
}
