using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float destroyPosY = -6f;
    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < destroyPosY)
        {
            Destroy(gameObject);
        }
    }
}
