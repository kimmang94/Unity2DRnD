using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
