using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_shootingScript : MonoBehaviour
{
    public Rigidbody pillbug;
    public float speed = 30;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rigidbody bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = transform.TransformDirection(Vector3.forward *50);
            
        }
        //idk how to make it delay
        //Invoke("Delay", 0.05f);
    }

  /*  private void Delay() {
        Destroy(gameObject);
    }*/

}
