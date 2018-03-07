using UnityEngine;
using System.Collections;

public class stautascontolloer : MonoBehaviour {
    

    // Use this for initialization
    public int[] ya_honnsu = new int[4];

    public int initial_value = 6;

    public static int score;


    void Start()
    {
        for (int i = 0; i <= 3; i++)
        {
            ya_honnsu[i] += initial_value;
        }

    }

    // Update is called once per frame
    public void score_set(int i)
    {

    }

}
