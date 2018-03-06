using UnityEngine;
using System.Collections;

public class lantan : MonoBehaviour {

    Rigidbody2D rigit;

    public float time;

    public float rimit;

    titile titile;

    bool flg = true;

    public int z;

    public float second;


	// Use this for initialization
	void Start ()
    {
        rigit = GetComponent<Rigidbody2D>();
        titile = GameObject.Find("GAMEOVER").GetComponent<titile>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if (time > rimit)
        {
            if (flg == true)
            {
                rigit.velocity = Vector2.zero;
                rigit.isKinematic = true;
                titile.flg = true;
                flg = false;
                Invoke("Turnover",second);
            }
           

        }
	
	}

    void Turnover()
    {
        transform.Rotate(new Vector3(0, 0, z));
        ParticleSystem pt = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        pt.Stop();
    }
}
