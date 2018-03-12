using UnityEngine;
using System.Collections;

public class soundContolloer : MonoBehaviour
{

    public AudioClip[] BGM;
    private AudioSource audio;
    public AudioClip[] SE;

    private static bool flg = false;

    // Use this for initialization
    void Awake()
    {
        audio = GetComponent<AudioSource>();

        if (flg != true)
        {
            DontDestroyOnLoad(this.gameObject);
            flg = true;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
   public void select_BGM(int i = 0)
    {
        audio.clip = BGM[i];
        audio.Play();
    }

   public void select_SE(int j = 0)
    {
        audio.PlayOneShot(SE[j]);
    }
}