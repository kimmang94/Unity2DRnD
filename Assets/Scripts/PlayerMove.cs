using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 키보드 움직임 제어 스크립트
    [SerializeField]
    private float moveSpeed = 0;
    
    private void Update()
    { 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);

        transform.position += moveTo * moveSpeed * Time.deltaTime;
        Debug.Log(horizontalInput);
        //Debug.Log(verticalInput);
    }
}
