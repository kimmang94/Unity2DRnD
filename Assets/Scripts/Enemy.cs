using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float destroyPosY = -6f;

    [SerializeField]
    private float hp = 1;
    
    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < destroyPosY)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 난이도가 증가함에 따라 적의 속도 증가를 위한 기능
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    /// <summary>
    /// 공격을 적이 맞는 경우 데미지만큼 hp가 감소하는기능
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
