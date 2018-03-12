using UnityEngine;
using System.Collections;

public class left_attck : MonoBehaviour {

    public float speed = 1.0f;

    private float time = 0.0f;

    public float rimit = 3.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (time > rimit)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        print("kgkkedfsv vfaav@fwfdndnvn:");
        //GameObject hitter = other.gameObject;
        //if (hitter.GetComponent<BoxCollider2D>().isTrigger ==false)
        //{
        //    Destroy(gameObject);
        //}
      
       
    }
}
