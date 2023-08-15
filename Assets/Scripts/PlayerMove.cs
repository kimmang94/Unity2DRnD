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
        PlayerMoveDefFunc();
    }
    
    /// <summary>
    /// Player의 상하 움직임을 막기위해 vertical을 사용하지 않는 방법
    /// </summary>
    private void PlayerMoveFunc()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);

        transform.position += moveTo * moveSpeed * Time.deltaTime;
        Debug.Log(horizontalInput);
        //Debug.Log(verticalInput);
    }

    /// <summary>
    /// 좌우값을 -, + 로 moveTo 에 대입 해서 좌우 이동
    /// </summary>
    private void PlayerMoveDefFunc()
    {
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveTo;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveTo;
        }
    }
    
}
