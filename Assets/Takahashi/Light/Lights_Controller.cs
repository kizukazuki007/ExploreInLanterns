using UnityEngine;
using System.Collections;

public class Lights_Controller : MonoBehaviour
{
    
    [SerializeField, Tooltip("半径")]
    float radius;

    GameObject player;
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
        /*
        color = radius;
        player.GetComponent<SpriteRenderer>().color = new Color(color,color,color);
	    */
        if (oil == 0.0f)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            other.gameObject.GetComponent<Background_Light>().Color_Cange(player, radius);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            other.gameObject.GetComponent<Background_Light>().Exit_Player(player);
        }
    }
}
