﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterController2D : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody2D characterbody;
    private bool jump = false;

    private void Awake()
    {
        characterbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !jump)
        {
            characterbody.AddForce(Vector2.up * 10.0f);
            jump = true;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            jump = false;
    }
}
