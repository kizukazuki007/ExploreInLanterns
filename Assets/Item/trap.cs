using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {

    [SerializeField, Header("当たったプレイヤーを保存しておく変数")]
    GameObject player;

    [SerializeField, Header("罠が発動した時に切り替える画像")]
    Sprite wanaWoriking;

    [SerializeField, Header("罠の発動するためのフラグ")]

    bool flg = false;

    [SerializeField, Header("罠が発動する秒数")]
    float traptime = 4.0f;

    float time;

    SpriteRenderer MainSprite;

	// Use this for initialization
	void Start () {

        MainSprite = GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flg == true)
        {
            time += Time.deltaTime;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            player = other.gameObject;
            MainSprite.sprite = wanaWoriking;
            player.GetComponent<player_move>().enabled = false;
            if (time > traptime)
            {
                player.GetComponent<player_move>().enabled = true;
                time = 0.0f;
                Destroy(gameObject);
            }

        }
    }
}
