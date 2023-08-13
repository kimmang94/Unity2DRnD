using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    
    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
