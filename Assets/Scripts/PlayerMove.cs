using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed = 0;

    [SerializeField] private GameObject weapon = null;
    [SerializeField] private Transform shootTransform = null;

    [SerializeField] private float shootInterval = 0.05f; 
    
    private float lastShotTime = 0f;
    private void Update()
    {
        PlayerMoveDefFunc();
        PlayerMoveOnMouse();
        Attack();
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

    private void PlayerMoveOnMouse()
    {
        // 마우스 해상도 기준 -> 포지션위치로 변경
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
    }

    private void Attack()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
        
    }
}
