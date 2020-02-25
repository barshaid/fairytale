using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairy : MonoBehaviour
{
    public GameObject player;
    public float d;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector2.Distance(transform.position, player.transform.position) > d)
        {
            GetComponent<Pathfinding.AIPath>().canSearch = false;
        }
        else
        {
            GetComponent<Pathfinding.AIPath>().canSearch = true;
        }
    }
}
