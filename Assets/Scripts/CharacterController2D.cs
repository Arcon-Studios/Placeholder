
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
        if(!jump && Input.GetKeyDown(KeyCode.W))
        {
            characterbody.AddForce(transform.up * 15.0f, ForceMode2D.Impulse);
            jump = true;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
 

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, move, speed * Time.deltaTime);

        if (raycastHit.collider.tag == "wall")
        {
           
        }
        else
            transform.position += move * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            jump = false;
    }
}
