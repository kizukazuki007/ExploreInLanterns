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

    [SerializeField]
    GameObject storage;

    int rad;

    int trsuea_rand;

    bool seisei=true,open = false;
    

	// Use this for initialization
	void Start ()
    {
        pos = transform.position;

        Mainsprite = GetComponent<SpriteRenderer>();

        rad = Random.Range(1, 4);

        trsuea_rand = Random.Range(1, 4);
        

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Attack1"||other.tag== "Attack2")&&open ==false)
        {
            Mainsprite.sprite = trasuerOpen;

            if (rad == 1)
            {
                if (seisei == true)
                {
                    trasure_oil[0].transform.position = new Vector3(pos.x, pos.y, pos.y);
                    storage = Instantiate(trasure_oil[0]);
                    seisei = false;
                }
            }

            if (rad == 2)
            {
                if (seisei == true)
                {
                    trasure_oil[4].transform.position = new Vector3(pos.x, pos.y, pos.y);
                    storage = Instantiate(trasure_oil[4]);
                    seisei = false;
                }
            }
            if(rad==3)
            {
                if (seisei == true)
                {
                    if (trsuea_rand == 1)
                    {
                        trasure_oil[1].transform.position = new Vector3(pos.x, pos.y, pos.z);
                        storage = Instantiate(trasure_oil[1]);
                        seisei = false;
                    }
                    if (trsuea_rand == 2)
                    {
                        trasure_oil[2].transform.position = new Vector3(pos.x, pos.y, pos.z);
                        storage = Instantiate(trasure_oil[2]);
                        seisei = false;
                    }

                    if (trsuea_rand==3)
                    {
                        trasure_oil[3].transform.position = new Vector3(pos.x, pos.y, pos.z);
                        storage = Instantiate(trasure_oil[3]);
                        seisei = false;
                    }
                
                 
                }
            }
            open = true;
            storage.transform.parent = transform;
        }

           
    }
   
}

