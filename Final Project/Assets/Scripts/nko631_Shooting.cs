using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nko631_Shooting : MonoBehaviour
{
    public Rigidbody pillbug;
    public float bulletSpeed = 100;
    bool allowShoot = true;
    public Rigidbody bullet;
    void Update()
    {
        if (allowShoot)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("MouseDown");
                StartCoroutine("wait");

            }
            //idk how to make it delay
            //Invoke("Delay", 0.05f);

        }
    }

    IEnumerator wait()
    {
        allowShoot = false;
        bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        yield return new WaitForSeconds(1);
        allowShoot = true;
        Destroy(bullet.gameObject, 2);

    }

}
