using UnityEngine;
using System.Collections;

public class player_attack : MonoBehaviour {

    Vector3 playerpos;



    public GameObject[] ya = new GameObject[4];



    public GameObject[] knife = new GameObject[4];

    player_move direction;
    public float time = 10.0f;

    public float rimit = 0.0f;

    stautascontolloer ya_zanndann;
    // Use this for initialization
    void Start () {

        direction = GetComponent<player_move>();

        time = 10.0f;

        ya_zanndann = GameObject.Find("statusContolloer").GetComponent<stautascontolloer>();




    }
    
    // Update is called once per frame
    void Update ()

    {
        playerpos = transform.position;



        if (ya_zanndann.ya_honnsu[1] > 0)
        {


            if (Input.GetButtonDown("P1_attack"))
            {
                Debug.Log("aa");
                Debug.Log(direction.muki);
                switch (direction.muki)
                {
                    case 1:
                        ya[0].transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
                        if (time > rimit)
                        {
                            Instantiate(ya[0]);
                            time = 0.0f;
                            ya_zanndann.ya_honnsu[1] -= 1;
                        }

                        break;
                    case 2:

                        ya[1].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            Instantiate(ya[1]);
                            time = 0.0f;
                            ya_zanndann.ya_honnsu[1] -= 1;
                        }
                        break;
                    case 3:

                        ya[2].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            Instantiate(ya[2]);
                            time = 0.0f;
                            ya_zanndann.ya_honnsu[1] -= 1;
                        }
                        break;
                    case 4:

                        ya[3].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                        if (time > rimit)
                        {
                            Instantiate(ya[3]);
                            time = 0.0f;
                            ya_zanndann.ya_honnsu[1] -= 1;
                        }
                        break;



                }

            }

        }
        if (Input.GetButtonDown("P1_attack2"))
        {
            switch (direction.muki)
            {
                case 1:
                    knife[0].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    Instantiate(knife[0]);
                    break;
                case 2:
                    knife[1].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    Instantiate(knife[1]);                   
                    break;
                case 3:
                    knife[2].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    Instantiate(knife[2]);
                    break;
                case 4:
                    knife[3].transform.position = new Vector3(playerpos.x, playerpos.y, 0);
                    Instantiate(knife[3]);
                    break;
            }

        }

        time += Time.deltaTime;

        

        }

        
    
    }

