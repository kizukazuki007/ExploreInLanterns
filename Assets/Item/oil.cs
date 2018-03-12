using UnityEngine;
using System.Collections;

public class oil : MonoBehaviour {

    GameObject hitter;
    float plus = 0.0f;

    [SerializeField, Tooltip("ランダム30以下のオイル量")]
    public float oil1 = 15.0f;

    [SerializeField, Tooltip("ランダム30以上60以下のオイル量")]
    public float oil2 = 30.0f;

    [SerializeField, Tooltip("ランダム60以上90以下のオイル量")]
    public float oil3 = 60.0f;

    // Use this for initialization

    soundContolloer SE;

    void Awake()
    {
        SE = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
    }
	
	
	// Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hitter = other.gameObject;

           
            int oil = Random.Range(1, 100);

            if (oil >= 30)
            {
                plus = oil1;
            }
            else if (oil >= 60)
            {
                plus = oil2;
            }
            else if (oil >= 90)
            {
                plus = oil3;
            }
            else
            {
                plus = 10.0f;
            }
            SE.select_SE(3);
            hitter.GetComponent<Oil_Controller>().Set_Oil(plus);
            Destroy(gameObject);

        }
    }
  
}
