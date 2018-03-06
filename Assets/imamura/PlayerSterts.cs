using UnityEngine;
using System.Collections;

public class PlayerSterts : MonoBehaviour
{

    int Enemy1;
    int Enemy2;
    int[] Enemy1difficulty = { 3, 5, 10 };
    int[] Enemy2difficulty = { 5, 7, 10 };
    static int difficulty; // 難易度の変数を入れる入れ物
    void Start()
    {
        difficulty = TitleSystem.Get_Difficulty(); // タイトルシステムから難易度の変数を読み込む。
        Enemy1 = Enemy1difficulty[difficulty];
        Enemy2 = Enemy2difficulty[difficulty];

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collider other)
    {
        if (other.gameObject.tag == "Enemy1")//スペルが違う可能性あり。//アタック1なら
        {
            HP -= Enemy1;
        }
        if (other.gameObject.tag == "Enemy2")//スペルが違う可能性あり。//アタック1なら
        {
            HP -= Enemy2;
        }
    }
}
