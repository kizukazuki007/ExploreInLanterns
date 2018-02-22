using UnityEngine;
using System.Collections;

public class AnemyMove : MonoBehaviour {
    public Camera camera;
    int distance=10;
    float speed = 1;
	void Start ()
    {
	
	}

    void Update ()
    {

        Vector3 playerVector = camera.transform.position-transform.position;
        transform.position += playerVector.normalized * speed * Time.deltaTime;         //normalized
	}
}
//HP ダメージを受ける。　受けた時にスピードを遅くする
        //if ((transform.position.x < camera.transform.position.x + distance && transform.position.x > camera.transform.position.x - distance)&& (transform.position.y < camera.transform.position.y + distance && transform.position.y > camera.transform.position.y - distance))
        //{
        //    attack = true;
        //}
        //else
        //{
        //    attack = false;
        //}