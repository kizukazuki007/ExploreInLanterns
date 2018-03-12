using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSystem : MonoBehaviour
{
    public GameObject SINGLE; // Single
    public GameObject MULTI;  // Multi

    public GameObject EASY;   // 難易度
    public GameObject NORMAL; // 難易度
    public GameObject HARD;   // 難易度

    public GameObject READY;

    Button Single;
    Button Multi;

    Button Easy;
    Button Normal;
    Button Hard;

    public bool mode = false;    // モード選択のトリガー
    public bool ReEnter = false; // ボタンを押してねを二回発生させないトリガー
    public bool difficulty_View = false; // 難易度選択のトリガー

    public bool ModeBack = false;       // モード選択から戻るトリガー
    public bool DifficultyBack = false; // 難易度選択から戻るトリガー

    public bool SINGLE_SET = false; // シングルモードを選択した場合に渡す
    public bool MULTI_SET = false;  // マルチモードを選択した場合に渡す

    public bool test = false;

    bool easyselect=false;

    private float interval_button; // ゲームモード選択ボタン出現までの時間
    private float ready_time;

    static int Member;
    public int gamemode;
    static int Difficulty; // 難易度の変数

    public int Select;

    public AudioClip ok;
    public AudioClip cancel;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        // タイトルの文字の獲得と時間を測る

    }

    // Update is called once per frame
    void Update()
    {
        TitleStart();    // ボタンを押してね❤からゲームモード選択まで

        if (difficulty_View == true) // 難易度選択のトリガーがtrueなら
        {
            difficulty_set(); // 難易度を選択
        }

        if (test == true)
        {
            ready_time += Time.deltaTime;

            if (test == false)
            {
                ready_time = 0;
            }

            if (Input.GetButtonDown("Decision") && gamemode == 0 && ready_time > 1.0f)
            {
                ready_time = 0;
                SceneManager.LoadScene("GameMain");
            }

            else if (Input.GetButtonDown("Decision") && gamemode == 1 && ready_time > 1.0f)
            {
                ready_time = 0;
                SceneManager.LoadScene("MultiSetting");
            }
        }
        else
        {
            ready_time = 0;
        }

    }

    public void TitleStart()
    {
        if (Input.GetButtonDown("Decision") && ReEnter == false) // 何かのボタンを押したら
        {
            TextSystem.TextObject.SetActive(false);

            mode = true;    // モード選択のトリガーをtrueに
            ReEnter = true; // 再入力防止をtrueに

            audioSource.clip = ok;
            audioSource.Play();
        }

        // モード選択画面から戻る時
        if (Input.GetButtonDown("Cancel")&& ModeBack == true)
        {
            ModeBack = false; // 戻るトリガーをfalseに
            difficulty_View = false; // 難易度選択のトリガーをfalseに

            // プレイモードの選択リセット
            SINGLE_SET = false;
            MULTI_SET = false;

            // 非表示
            EASY.SetActive(false);   
            NORMAL.SetActive(false); 
            HARD.SetActive(false);

            // 表示
            SINGLE.SetActive(true);
            MULTI.SetActive(true);

            Single.Select();
            Select = 0;
            easyselect = false;

            audioSource.clip = cancel;
            audioSource.Play();

        }

        if (Input.GetButtonDown("Cancel") && DifficultyBack == true)
        {
            ModeBack = true;        // 戻るトリガーをtrueに
            DifficultyBack = false; // 戻るトリガーをfalseに
            difficulty_View = true; // 難易度選択のトリガーをfalseに

            Select = 0;
            easyselect = false;

            // 表示
            EASY.SetActive(true);
            NORMAL.SetActive(true);
            HARD.SetActive(true);

            // 非表示
            SINGLE.SetActive(false);
            MULTI.SetActive(false);

            READY.SetActive(false);

            test = false;

            audioSource.clip = cancel;
            audioSource.Play();
        }

        if (mode == true) // モード選択トリガーがtrueなら
        {
            interval_button += Time.deltaTime; // 文字を表示するまでの時間を測る
        }

        if (interval_button > 1.5f) // 1.5秒経過したら
        {
            SINGLE.SetActive(true); // シングルのボタンを表示
            MULTI.SetActive(true);  // マルチのボタンを表示

            Single = GameObject.Find("Canvas/SINGLE").GetComponent<Button>();
            Multi = GameObject.Find("Canvas/MULTI").GetComponent<Button>();

            Single.Select();

            if ((int)Input.GetAxis("P1_Horizontal") == 1)
            {
                Single.Select();
            }

            if ((int)Input.GetAxis("P1_Horizontal") == -1)
            {
                Multi.Select();
            }

            interval_button = 0.0f; // 1.5秒以上を経過してる限り表示されてしまうので0秒に変更
            mode = false;            // モード選択トリガーをfalseに
        }
    }


    public void SinglePlay()
    {
        ModeBack = true;         // 選択ミス対処
        SINGLE_SET = true;       // ゲームモードをシングルにセット
        difficulty_View = true;  // 難易度選択トリガーをtrueに
        SINGLE.SetActive(false); // SINGLEボタンを非表示
        MULTI.SetActive(false);  // MULTIボタンを非表示

        audioSource.clip = ok;
        audioSource.Play();

        Member = 1;

        gamemode = 0;

    }

    public void MultiPlay()
    {
        MULTI_SET = true;        //ゲームモードをマルチにセット
        ModeBack = true;         // 選択ミス対処
        difficulty_View = true;  // 難易度選択トリガーをtrueに
        SINGLE.SetActive(false); // SINGLEボタンを非表示
        MULTI.SetActive(false);  // MULTIボタンを非表示

        audioSource.clip = ok;
        audioSource.Play();

        gamemode = 1;
    }

    public void difficulty_set() // Update参照
    {
        EASY.SetActive(true);   //EASYボタンを表示
        NORMAL.SetActive(true); //NORMALボタンを表示
        HARD.SetActive(true);   //HARDボタンを表示

        Easy = GameObject.Find("Canvas/EASY").GetComponent<Button>();
        Normal = GameObject.Find("Canvas/NORMAL").GetComponent<Button>();
        Hard = GameObject.Find("Canvas/HARD").GetComponent<Button>();

        if ((int)Input.GetAxis("P1_Vertical") == -1)
        {
            Select = 1;
        }

        if (Select == 0&&easyselect == false)
        {
            Easy.Select();
            easyselect = true;
        }
    }

    public void EASYMODE()
    {
        Difficulty = 0; // 0を送る

        //非表示
        EASY.SetActive(false);
        NORMAL.SetActive(false);
        HARD.SetActive(false);

        ModeBack = false;
        DifficultyBack = true;

        difficulty_View = false;

        if (MULTI_SET == true)
        {
            // SceneManager.LoadScene("MultiSetting"); // マルチプレイ参加画面へ移動
        }

        audioSource.clip = ok;
        audioSource.Play();

        SET_READY();
    }

    public void NORMALMODE()
    {
        Difficulty = 1; // 1を送る

        //非表示
        EASY.SetActive(false);
        NORMAL.SetActive(false);
        HARD.SetActive(false);

        ModeBack = false;
        DifficultyBack = true;

        difficulty_View = false;


        if (MULTI_SET == true)
        {
            // SceneManager.LoadScene("MultiSetting");// マルチプレイ参加画面へ移動
        }

        audioSource.clip = ok;
        audioSource.Play();

        SET_READY();
    }

    public void HARDMODE()
    {
        Difficulty = 2; // 2を送る

        //非表示
        EASY.SetActive(false);
        NORMAL.SetActive(false);
        HARD.SetActive(false);

        ModeBack = false;
        DifficultyBack = true;

        difficulty_View = false;

        if (MULTI_SET == true)
        {
            // SceneManager.LoadScene("MultiSetting"); // マルチプレイ参加画面へ移動
        }

        audioSource.clip = ok;
        audioSource.Play();

        SET_READY();

    }

    /// <summary>
    /// 難易度設定
    /// </summary>
    public static int Get_Difficulty()
    {
        return Difficulty;
    }

    /// <summary>
    /// プレイヤー人数設定(マルチ参加のシーンから設定する)
    /// </summary>
    public static void Set_Member(int member)
    {
        Member = member;
    }

    /// <summary>
    /// プレイヤー人数設定
    /// </summary>
    public static int Get_Member()
    {
        return Member;
    }
    
    public void SET_READY()
    {
        READY.SetActive(true);

        test = true;
    }
}

