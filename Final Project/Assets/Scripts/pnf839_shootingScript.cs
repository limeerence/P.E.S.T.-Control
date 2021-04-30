using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_shootingScript : MonoBehaviour
{
    public Rigidbody pillbug;
    public float bulletSpeed = 100;
    public float bulletDelay;
    public bool allowShoot = true;
    public bool allowSwitch = false;
    private Rigidbody bullet;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (allowShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }

    public IEnumerator shoot()
    {
        shootspawning();
        allowShoot = false;
        allowSwitch = false;
        yield return new WaitForSeconds(bulletDelay);
        allowShoot = true;
    }
    
    void shootspawning()
    {
        bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        allowSwitch = true;
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
