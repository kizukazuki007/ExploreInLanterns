using UnityEngine;
using System.Collections;

public class item_event : MonoBehaviour {

    [SerializeField, Header("宝箱が開いたときの画像")]
    Sprite trasuerOpen;

    SpriteRenderer Mainsprite;

    [SerializeField, Header("宝の生成位置")]
    Vector3 pos;

    [SerializeField, Header("0、オイル　1から3の間に宝玉を入れて下さい")]
    GameObject[] trasure_oil;

    int rad;

    int trsuea_rand;

    bool seisei=true;
    

	// Use this for initialization
	void Start ()
    {
        pos = transform.position;

        Mainsprite = GetComponent<SpriteRenderer>();

        rad = Random.Range(1, 3);

        trsuea_rand = Random.Range(1, 4);
        

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "attack")
        {
            Mainsprite.sprite = trasuerOpen;

            if (rad == 1)
            {
                if (seisei == true)
                {
                    trasure_oil[0].transform.position = new Vector3(pos.x, pos.y, pos.y);
                    Instantiate(trasure_oil[1]);
                    seisei = false;
                }
            }

            if (rad == 2)
            {
                trasure_oil[4].transform.position = new Vector3(pos.x, pos.y, pos.y);
                Instantiate(trasure_oil[4]);
                seisei = false;
            }
        }
            else
            {
                if (seisei == true)
                {
                    if (trsuea_rand == 1)
                    {
                        trasure_oil[1].transform.position = new Vector3(pos.x, pos.y, pos.z);
                        Instantiate(trasure_oil[2]);
                        seisei = false;
                    }

                }
                if (seisei == true)
                {
                    if(trsuea_rand == 2)
                    {
                        trasure_oil[2].transform.position = new Vector3(pos.x, pos.y, pos.z);
                        Instantiate(trasure_oil[2]);
                        seisei = false;
                    }
                }

                else
                {
                    trasure_oil[3].transform.position = new Vector3(pos.x, pos.y, pos.z);
                    Instantiate(trasure_oil[3]);
                    seisei = false;
                }
            }

           
        }
   
}

