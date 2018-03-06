using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{

    int HP;
    int Attack1 = 1;
    int Attack2 = 10;
    int[] HPdifficulty = { 5, 7, 10 };

    static int difficulty; // 難易度の変数を入れる入れ物
    MapManege MManege;

    void Start()
    {
        difficulty = TitleSystem.Get_Difficulty(); // タイトルシステムから難易度の変数を読み込む。
        HP = HPdifficulty[difficulty];

        MManege = GameObject.Find("MAPCreate").GetComponent<MapManege>();
    }
    void OnCollisionEnter2D(Collision2D other)
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
            MManege.MonsterDedCreate();
            Destroy(gameObject);
        }
    }
}
