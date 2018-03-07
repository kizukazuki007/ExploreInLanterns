using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{

    int HP=1;
    int Attack1 = 1;
    int Attack2 = 10;
    int[] HPdifficulty = { 5, 7, 10 };

    int destoryOil=3;

    public GameObject oil;

    static int difficulty; // 難易度の変数を入れる入れ物
    MapManege MManege;

    void Awake()
    {
        MManege = GameObject.Find("MAPCreate").GetComponent<MapManege>();
    }
    void Start()
    {
        difficulty = TitleSystem.Get_Difficulty(); // タイトルシステムから難易度の変数を読み込む。
        HP = HPdifficulty[difficulty];
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack1")//スペルが違う可能性あり。//アタック1なら
        {
            HP -= Attack1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Attack2")//スペルが違う可能性あり。//アタック２なら
        {
            HP -= Attack2;
            Destroy(other.gameObject);
        }
        if (HP <= 0)
        {
            oil.transform.position = this.transform.position;
            Instantiate(oil);
            MManege.MonsterDedCreate();
            Destroy(this.gameObject);
        }
    }
}
