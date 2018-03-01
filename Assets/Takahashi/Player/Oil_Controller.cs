using UnityEngine;
using System.Collections;

public class Oil_Controller : MonoBehaviour {

    [SerializeField, Tooltip("playerの持つライト")]
    GameObject Light;

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

        //Light.GetComponent<Light_Controller>().set_Oil(Oil);
	}


    //オイル量　セット　ゲット
    public float Get_Oil()
    {
        return Oil;
    }
    public void Set_Oil(float plus)
    {
        Oil += plus;
        Oil = Mathf.Max(Oil, 180.0f);
    }
    
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
            default:
                initial = 60;
                break;
        }

        Oil = initial;
    }
}
