using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randsequance : MonoBehaviour
{
    public int segments=10;
    int[] seq;
    void Start()
    {
        seq = new int[segments];
        for(int i=0; i<segments; i++)
        {
            seq[i] = Random.Range(0, GetComponent<LevelGenerator>().map.Length);
        }
        GetComponent<LevelGenerator>().GenerateLevel(seq);
        GetComponent<backgroundtiles>().GenerateLevel(seq);
       // GetComponent<interactables>().GenerateLevel(seq);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
