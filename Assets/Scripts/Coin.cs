using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private void Start()
    {
        Jump();
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 코인이 위로 올라가는 기능
    /// </summary>
    private void Jump()
    {
       Rigidbody2D rigid2D = GetComponent<Rigidbody2D>();

       float randomJumpForce = Random.Range(4f, 8f);
       Vector2 jumpVelocity = Vector2.up * randomJumpForce;
       rigid2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
}
