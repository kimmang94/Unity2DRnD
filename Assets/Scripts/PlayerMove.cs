using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0;
    
    private void Update()
    { 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);

        transform.position += moveTo * moveSpeed * Time.deltaTime;
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
    }
}
