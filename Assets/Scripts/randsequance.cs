using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randsequance : MonoBehaviour
{
    public int segments=10;
    int[] seq;
    void Start()
    {
        int i = 0;
        seq = new int[segments];
        for(i=0; i<segments-1; i++)
        {
            
            seq[i] = Random.Range(0, GetComponent<LevelGenerator>().map.Length-1);
            Debug.Log(seq[i]);
        }
        
        seq[i] = GetComponent<LevelGenerator>().map.Length-1;
        Debug.Log(seq[i]);
        GetComponent<LevelGenerator>().GenerateLevel(seq);
        GetComponent<backgroundtiles>().GenerateLevel(seq);
        GetComponent<interactables>().GenerateLevel(seq);
        AstarPath.active.Scan();
    }

  
}
