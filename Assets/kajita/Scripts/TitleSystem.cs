using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleSystem : MonoBehaviour
{
    public GameObject TextObject; //点滅させる文字
    public GameObject SINGLE; // Single
    public GameObject MULTI; // Multi
    public GameObject EASY;
    public GameObject NORMAL;
    public GameObject HARD;

    public bool Button1 = false; // モード選択のトリガー
    public bool a = false;
    public bool difficulty_View = false; // 難易度選択のトリガー

    private float NextTime;
    private float interval = 0.8f; // 周期
    private float interval_button1; // prefab生成までの時間
    public static int Difficulty;

    // Use this for initialization
    void Start()
    {
        TextObject = GameObject.Find("Title");

        NextTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        TitleStart(); // ボタンを押してね❤からゲームモード選択まで
        interval_Text(); // 文字の点滅

        if (difficulty_View == true)
        {
            difficulty_set(); // 難易度を選択
        }

    }

    public void TitleStart()
    {
        if (Input.GetMouseButtonDown(0)&& a==false)
        {
            TextObject.SetActive(false);

            Button1 = true;
            a = true;
        }

        if (Button1 == true)
        {
            interval_button1 += Time.deltaTime;
        }

        if (interval_button1 > 1.5f)
        {
            SINGLE.SetActive(true);
            MULTI.SetActive(true);

            interval_button1 = 0.0f;
            Button1 = false;
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

    public void difficulty_set()
    {
        EASY.SetActive(true);
        NORMAL.SetActive(true);
        HARD.SetActive(true);
    }
    public void SinglePlay()
    {
        difficulty_View = true;
        SINGLE.SetActive(false);
        MULTI.SetActive(false);

        
    }

    public void MultiPlay()
    {
        SceneManager.LoadScene("MultiSetting");
    }

    public void EASYMODE()
    {
        Difficulty = 0;
    }

    public void NORMALMODE()
    {
        Difficulty = 1;
    }

    public void HARDMODE()
    {
        Difficulty = 2;
        Debug.Log("2");
    }
}
