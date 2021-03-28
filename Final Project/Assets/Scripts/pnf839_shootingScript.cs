using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_shootingScript : MonoBehaviour
{
    public Rigidbody pillbug;
    public float bulletSpeed = 100;
    bool allowShoot = true;
    private Rigidbody bullet;
    void Update()
    {
        if (allowShoot)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("MouseDown");
                StartCoroutine("wait");
                Destroy(bullet.gameObject, 2);

            }
        }
    }

    IEnumerator wait()
    {
        allowShoot = false;
        bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        yield return new WaitForSeconds(0.5f);
        allowShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            Debug.Log("Wall hit");
        }
    }
}
