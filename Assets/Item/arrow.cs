using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

    GameObject hitter;
    public string[] playername;

    int number = 0;

    [SerializeField, Tooltip("ランダムの値")]
    int arrow_number;

    stautascontolloer stautas;

    [SerializeField, Tooltip("矢の最大本数")]
    int arrow_max = 10;


    // Use this for initialization
    void Awake()
    {
        stautas = GameObject.Find("statusContolloer").GetComponent<stautascontolloer>();
        arrow_number = Random.Range(1, 4);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("jkjkjkjkjkjkj");
        if (other.tag == "Player")
        {
            hitter = other.gameObject;
            print(hitter);


            for(int i = 0; i < playername.Length; i++)
            {
                if (hitter.name == playername[i]) number = i;
            }
            //print("jdjdjdjdjdjdjdjdj");

            stautas.ya_honnsu[number] += arrow_number;

            if (stautas.ya_honnsu[number] > arrow_max)
            {
                stautas.ya_honnsu[number] = arrow_max;
            }
            Destroy(gameObject);
        }
       
    }
}
