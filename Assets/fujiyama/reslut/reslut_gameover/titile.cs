using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class titile : MonoBehaviour {

    Rigidbody2D Rigid;

    public float time;

    public bool flg=false;

    public float rimit=2.0f;

    public int z;

    public float second;

    Text tex;
	// Use this for initialization
	void Start ()
    {
        Rigid = GetComponent<Rigidbody2D>();
        tex = GetComponent<Text>();
	
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
       
	}

    void rotate()
    {
        transform.Rotate(new Vector3(0, 0, z));
              
    }

  
}
