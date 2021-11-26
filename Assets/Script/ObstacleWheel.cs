using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWheel : MonoBehaviour
{
    [SerializeField]private float speed = 0.5f;
 
    public void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, 1) * 8 - 4;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
