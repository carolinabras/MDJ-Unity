using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float speed = 200f;
   [SerializeField] private string inputNameHorizontal;
   [SerializeField] private string inputNameVertical;

   private Rigidbody rb;
 
   private float inputHorizontal;
   private float inputVertical;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      inputHorizontal = Input.GetAxis(inputNameHorizontal);
      inputVertical = Input.GetAxis(inputNameVertical);
   }
   
   private void FixedUpdate()
   {
      rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
   }
}
