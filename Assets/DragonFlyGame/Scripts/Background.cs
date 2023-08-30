using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3.0f;

    private float resetPosition = 20.0f;
    private float underPosition = -10.0f;
    
    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < underPosition)
        {
            transform.position += new Vector3(0, resetPosition, 0);
        }
    }
}
