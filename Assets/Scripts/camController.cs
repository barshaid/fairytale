using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float min, max= 124.666666666666f;
    public GameObject skybox;

    private void Start()
    {
        
        max *= GameObject.Find("LevelGenerator").GetComponent<randsequance>().segments;
        max += (GameObject.Find("LevelGenerator").GetComponent<randsequance>().segments * 10);

        Vector3 sb = skybox.transform.localScale;
        sb.x=1.9f*( GameObject.Find("LevelGenerator").GetComponent<randsequance>().segments+1);
        skybox.transform.localScale = sb;

        sb = skybox.transform.localPosition;
        sb.x+= 75 * (GameObject.Find("LevelGenerator").GetComponent<randsequance>().segments+1);
        skybox.transform.localPosition = sb;
    }
    void Update()
    {
      
       transform.position = new Vector3(Mathf.Clamp((player.position.x + offset.x), min, max), Mathf.Clamp((player.position.y + offset.y), 0, 150), offset.z); // Camera follows the player with specified offset position
    }
}
