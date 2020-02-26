using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float min, max;

    void Update()
    {
      
       transform.position = new Vector3(Mathf.Clamp((player.position.x + offset.x), min, max), Mathf.Clamp((player.position.y + offset.y), 0, 150), offset.z); // Camera follows the player with specified offset position
    }
}
