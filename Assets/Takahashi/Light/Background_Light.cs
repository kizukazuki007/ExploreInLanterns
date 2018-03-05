using UnityEngine;
using System.Collections;

public class Background_Light : MonoBehaviour {

    GameObject[] players = new GameObject[4];

    [SerializeField]
    int PNum;
    
    bool cange;
    float distance, lightpower, lpower_total;
    int px, py;

    // Use this for initialization
    void Start()
    {
        //players = new GameObject[4];
        Color_Brack();
        PNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cange)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);

            if (PNum == 0)
                cange = false;
            lpower_total = 0.0f;
            for (int i = 0; i < PNum; i++)
            {
                if (players[i] == null)
                {
                    Player_Sort(i);
                }
                else
                {
                    px = (int)players[i].transform.position.x;
                    py = (int)players[i].transform.position.y;
                    float distance = Vector2.Distance(players[i].transform.position, new Vector2(px, py));
                    lightpower = 2.0f / (distance + 1.0f);
                    lpower_total += lightpower;
                    lpower_total = Mathf.Max(lpower_total, 1.0f);
                }
            }
            GetComponent<SpriteRenderer>().color = new Color(lpower_total, lpower_total, lpower_total);
        }

    }

    public void Color_Cange(GameObject player, float ratio)
    {
        Debug.Log("入った");
        cange = true;
        players[PNum] = player;
        PNum++;
    }
    public void Exit_Player(GameObject player)
    {
        for (int i = 0; i < PNum; i++)
        {
            if (players[i] == player)
            {
                Player_Sort(i);
            }
        }
        PNum--;
        PNum = Mathf.Max(PNum, 0);
        players[PNum] = null;

        if (PNum == 0)
        {
            Color_Brack();
        }
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
    void Player_Sort(int SortNum)
    {

        for (int i = SortNum; i < PNum-1; i++)
        {
            int j = i++;
            if (players[j] != null)
            {
                players[i] = players[j];
            }
        }
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }
    void Color_Brack()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
    }
}
