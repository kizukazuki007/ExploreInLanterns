using UnityEngine;
using System.Collections;

public class Oil_Controller : MonoBehaviour {
    

    [SerializeField, Tooltip("playerの持つオイル量")]
    private float Oil;

    [SerializeField, Tooltip("playerの持つオイルの初期量")]
    private float initial;


    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Oil -= Time.deltaTime;
        Oil = Mathf.Max(Oil, 0.0f);
        
	}


    //オイル量　セット　ゲット
    public float Get_Oil()
    {
        return Oil;
    }
    public void Set_Oil(float plus)
    {
        Oil += plus;
        if (Oil > 180.0f)
        {
            Oil = 180.0f;
        }
    }
    public void Set_RestartOil(float Oil_Re)
    {
        Oil = Oil_Re;
    }
    
    //最初1回だけMAPから呼び出す
    public void set_InitialOil(int difficulty)
    {
        switch (difficulty)
        {
            //イージー
            case 0:
                initial = 120;
                break;
            //ノーマル
            case 1:
                initial = 90;
                break;
            //ハード
            case 2:
                initial = 60;
                break;
        }

        Oil = initial;
    }
}
