using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadout : MonoBehaviour {

   public float aplha=1.0f;

 

	// Use this for initialization
	void Start ()
    {
        aplha = GetComponent<Image>().color.a;
       
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (aplha > 0)
        {
            aplha -= Time.deltaTime;
            GetComponent<Image>().color = new Color(0, 0, 0, aplha);
            
        }
        
	}
}
