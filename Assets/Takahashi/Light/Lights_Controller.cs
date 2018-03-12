using UnityEngine;
using System.Collections;

public class Lights_Controller : MonoBehaviour
{
    
    [SerializeField, Tooltip("半径")]
    float radius;

    GameObject player,GOstorage;
    CircleCollider2D Lanterns_Range;

    //int player_x, player_y;
    float radius_max = 3.0f; //distance, lightPower;
    float oil, oil_max = 180.0f;
    float color;
    
    // Use this for initialization
    void Start()
    {
        player = transform.parent.gameObject;
        Lanterns_Range = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        oil = player.GetComponent<Oil_Controller>().Get_Oil();
        radius = oil / oil_max;
        Lanterns_Range.radius = radius_max * radius;
        if (Lanterns_Range.radius > radius_max)
        {
            Lanterns_Range.radius = radius_max;
        }
        /*
        color = radius;
        player.GetComponent<SpriteRenderer>().color = new Color(color,color,color);
	    */
        if (oil == 0.0f)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
        }
        if(transform.position != player.transform.position)
        {
            transform.position = player.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            if (player == null)
            {
                GOstorage = other.gameObject;
                Invoke("Bg_L", 0.001f);
            }
            //if (other.tag != "Light")
            //{

            try
                {
                    other.gameObject.GetComponent<Background_Light>().Color_Cange(player, radius);
                }
                catch
                {

                }
            //}
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            if (player == null)
            {
                Debug.Log("ぷれいやーはいってないです。");
            }
            //if (other.tag != "Light")
            //{
            try
                {
                    other.gameObject.GetComponent<Background_Light>().Exit_Player(player);
                }
                catch
                {

                }   
            //}
        }
    }
    void Bg_L()
    {
        GOstorage.GetComponent<Background_Light>().Color_Cange(player, radius);
    }
}
