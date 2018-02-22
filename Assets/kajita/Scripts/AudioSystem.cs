using UnityEngine;
using System.Collections;

public class AudioSystem : MonoBehaviour {
    public AudioClip TitleBGM;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = TitleBGM;
        audioSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
