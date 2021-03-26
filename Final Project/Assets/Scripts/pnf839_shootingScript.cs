using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_shootingScript : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 30;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
