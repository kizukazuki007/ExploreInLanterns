using UnityEngine;
using System.Collections;

public class Light_Controller : MonoBehaviour {

    //[SerializeField, Tooltip("プレイヤー")]
    //GameObject player;
    [SerializeField, Tooltip("Light_GameObject")]
    GameObject[] Light = new GameObject[2];

    [SerializeField, Tooltip("Point_Light")]// Intensity の値変更
    Light Plight;

    [SerializeField, Tooltip("Spot_Light")] // Spot Angle の値変更
    Light Slight;

    [SerializeField, Tooltip("ランタンのオイル量")]
    float P_oil;

    float P_Max = 6.0f, S_Max = 80.0f,O_Max = 180.0f; // 各種Maxの値設定

    private float ratio; // オイルの割合

	// Use this for initialization
	void Start ()
    {

        Plight = Light[0].GetComponent<Light>();
        Slight = Light[1].GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ratio = P_oil / O_Max;
        Plight.intensity = P_Max * ratio;
        Slight.spotAngle = S_Max * ratio;
	}
    public void set_Oil(float oil)
    {
        P_oil = oil;
    }
}
