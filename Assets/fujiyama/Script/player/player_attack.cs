using UnityEngine;
using System.Collections;

public class player_attack : MonoBehaviour {

    Vector3 playerpos;

    GameObject ya;

    P1_Move direction;
    public float time = 0.0f;



    // Use this for initialization
    void Start () {

        direction = GetComponent<P1_Move>();

        ya = (GameObject)Resources.Load("ya.down");
       





    }
    
    // Update is called once per frame
    void Update ()

    {
        playerpos = transform.position;

       

        if (Input.GetButtonDown("P1_A"))
        {
            Debug.Log("aa");
            switch (direction.muki)
            {
                case 1:
                    ya = (GameObject)Resources.Load("ya.right");
                    ya.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
                    if (time > 3.0f)
                    {
                        Instantiate(ya);
                        time = 0.0f;
                    }
                   
                    break;
                case 2:
                    ya = (GameObject)Resources.Load("ya.left");
                    ya.transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time > 3.0f)
                    {
                        Instantiate(ya);
                        time = 0.0f;
                    }
                    break;
                case 3:
                    ya = (GameObject)Resources.Load("ya.up");
                    ya.transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time > 3.0f)
                    {
                        Instantiate(ya);
                        time = 0.0f;
                    }
                    break;
                case 4:
                    ya = (GameObject)Resources.Load("ya.down");
                    ya.transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    if (time > 3.0f)
                    {
                        Instantiate(ya);
                        time = 0.0f;
                    }
                    break;
            


            }
            
        }

        if (Input.GetButtonDown("P1_D"))
        {
            print("探検");
        }

        time += Time.deltaTime;



        }
    
    }

