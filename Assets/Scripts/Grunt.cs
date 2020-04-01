using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    public float health = 20.0f;

    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Object.Destroy(gameObject);
    }

}
