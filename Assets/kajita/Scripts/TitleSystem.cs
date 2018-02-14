using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSystem : MonoBehaviour
{
    public GameObject TextObject; //点滅させる文字

    public GameObject SINGLE; // Single
    public GameObject MULTI;  // Multi

    public GameObject EASY;   // 難易度
    public GameObject NORMAL; // 難易度
    public GameObject HARD;   // 難易度

    public bool mode = false;    // モード選択のトリガー
    public bool ReEnter = false; // ボタンを押してねを二回発生させないトリガー
    public bool difficulty_View = false; // 難易度選択のトリガー
    public bool Back = false; // 戻るトリガー

    private float NextTime;         // 文字点滅の奴に使ってるだけ
    private float interval = 0.8f;  // 周期
    private float interval_button1; // prefab生成までの時間

    public static int Difficulty; // 難易度の変数
    public static int Member;     // プレイヤーの数

    // Use this for initialization
    void Start()
    {
        // タイトルの文字の獲得と時間を測る場所

        TextObject = GameObject.Find("Title");

        NextTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        TitleStart();    // ボタンを押してね❤からゲームモード選択まで
        interval_Text(); // 文字の点滅

        if (difficulty_View == true) // 難易度選択のトリガーがtrueなら
        {
            difficulty_set(); // 難易度を選択
        }

    }

    public void TitleStart()
    {
        if (Input.GetMouseButtonDown(0)&& ReEnter == false) // 何かのボタンを押したら
        {
            TextObject.SetActive(false); // ボタンを押してね❤を非表示に

            mode = true;    // モード選択のトリガーをtrueに
            ReEnter = true; // 再入力防止をtrueに
        }

        if (Input.GetMouseButtonDown(1)&& Back == true)
        {
            Back = false;
            difficulty_View = false;

            EASY.SetActive(false);
            NORMAL.SetActive(false);
            HARD.SetActive(false);

            SINGLE.SetActive(true);
            MULTI.SetActive(true);
            
        }

        if (mode == true) // モード選択トリガーがtrueなら
        {
            interval_button1 += Time.deltaTime; // 文字を表示するまでの時間を測る
        }

        if (interval_button1 > 1.5f) // 1.5秒経過したら
        {
            SINGLE.SetActive(true); // シングルのボタンを表示
            MULTI.SetActive(true);  // マルチのボタンを表示

            interval_button1 = 0.0f; // 1.5秒以上を経過してる限り表示されてしまうので0秒に変更
            mode = false;            // モード選択トリガーをfalseに
        }
    }

    public void interval_Text()
    {
        if (Time.time > NextTime)
        {
            float alpha = TextObject.GetComponent<CanvasRenderer>().GetAlpha();
            if (alpha == 1.0f)
                TextObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            else
                TextObject.GetComponent<CanvasRenderer>().SetAlpha(1.0f);

            NextTime += interval;
        }
    }

    public void SinglePlay()
    {
        Member = 0;
        Back = true;
        difficulty_View = true;  // 難易度選択トリガーをtrueに
        SINGLE.SetActive(false); // SINGLEボタンを非表示
        MULTI.SetActive(false);  // MULTIボタンを非表示

        
    }

    public void MultiPlay()
    {
        //SceneManager.LoadScene("MultiSetting"); // マルチプレイ参加画面へ移動
    }

    public void difficulty_set() // Update参照
    {
        EASY.SetActive(true);   //EASYボタンを表示
        NORMAL.SetActive(true); //NORMALボタンを表示
        HARD.SetActive(true);   //HARDボタンを表示
    }

    public void EASYMODE()
    {
        Difficulty = 0; // 0を送る
    }

    public void NORMALMODE()
    {
        Difficulty = 1; // 1を送る
    }

    public void HARDMODE()
    {
        Difficulty = 2; // 2を送る
    }
}
