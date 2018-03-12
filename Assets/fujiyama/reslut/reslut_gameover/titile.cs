using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titile : MonoBehaviour {

    Rigidbody2D Rigid;

    public float time;

    public bool flg=false;

    public float rimit=2.0f;

    public int z;

    public float second;

    bool return_title;

    Text tex;

    soundContolloer BGM;

    void Awake()
    {
        BGM = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
        BGM.select_BGM(2);
    }
	// Use this for initialization
	void Start ()
    {
        Rigid = GetComponent<Rigidbody2D>();
        tex = GetComponent<Text>();
        return_title = false;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (flg == true)
        {
            Rigid.isKinematic = false;
            time += Time.deltaTime;
            if (time > rimit)
            {
                Rigid.velocity = Vector2.zero;
                Rigid.isKinematic = true;
                flg = false;
                Invoke("rotate",second);
            }
        }
        else if (return_title==true)
        {
            if(Input.GetButtonDown("P1_D") || Input.GetButtonDown("P2_D") || Input.GetButtonDown("P3_D") || Input.GetButtonDown("P4_D"))
            {
                SceneManager.LoadScene("Title");
            }
        }
       
	}

    void rotate()
    {
        transform.Rotate(new Vector3(0, 0, z));
        return_title = true;
    }

  
}
