using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private float destroyPosY = -7f;
    
    private void Start()
    {
        Jump();
    }

    
    void Update()
    {
        if (transform.position.y < destroyPosY)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 코인이 위로 올라가는 기능
    /// </summary>
    private void Jump()
    {
       Rigidbody2D rigid2D = GetComponent<Rigidbody2D>();

       float randomJumpForce = Random.Range(4f, 8f);
       Vector2 jumpVelocity = Vector2.up * randomJumpForce;

       jumpVelocity.x = Random.Range(-2f, 2f);
       rigid2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
}
