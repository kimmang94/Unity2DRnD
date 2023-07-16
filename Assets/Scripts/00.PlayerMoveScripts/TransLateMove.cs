using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransLateMove : MonoBehaviour
{
     private void Update()
     {
          TranslateMove();
     }

     private void TranslateMove()
     {
          if (Input.GetKeyDown(KeyCode.W))
          {
               Debug.Log("W Clicked");
               gameObject.transform.Translate(0, 1, 0);
          }
          if (Input.GetKeyDown(KeyCode.S))
          {
               Debug.Log("S Clicked");
               gameObject.transform.Translate(0, -1, 0);
          }
          if (Input.GetKeyDown(KeyCode.A))
          {
               Debug.Log("A Clicked");
               gameObject.transform.Translate(-1, 0, 0);
          }
          if (Input.GetKeyDown(KeyCode.D))
          {
               Debug.Log("D Clicked");
               gameObject.transform.Translate(1, 0, 0);
          }
     }
}
