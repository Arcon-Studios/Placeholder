using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private float dmg = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Grunt grunt = collision.GetComponent<Grunt>();    
        if(grunt != null)
        {
            grunt.TakeDamage(dmg);
            Object.Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
    }

    public void setdmg(float inc_dmg)
    {
        dmg = inc_dmg;
    }
}
