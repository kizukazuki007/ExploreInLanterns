using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextSystem : MonoBehaviour {

    public static GameObject TextObject; //点滅させる文字

    private float NextTime;         // 文字点滅の奴に使ってるだけ
    private float interval = 0.8f;  // 周期

    // Use this for initialization
    void Start () {

        TextObject = GameObject.Find("Title");

        NextTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        if (TextObject == true)
        {
            interval_Text(); // 文字の点滅
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
}
