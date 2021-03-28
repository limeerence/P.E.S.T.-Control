using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nko631_Enemy : MonoBehaviour
{
    public int health = 50;

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 10;
            Destroy(collision.gameObject);
        }
    }
  
}
