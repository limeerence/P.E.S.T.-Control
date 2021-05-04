using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnf839_shootingScript : MonoBehaviour
{
    public Rigidbody pillbug;
    public float bulletSpeed = 100;
    public float bulletDelay;
    private Rigidbody bullet;

    /*
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
        yield return new WaitForSeconds(bulletDelay);
        allowShoot = true;
    }
    
    void shootspawning()
    {
        bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }

    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            Debug.Log("Wall hit");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
            Destroy(gameObject);
        }
    }

    private float timeWhenAllowedNextShoot = 0.05f;
    public float timeBetweenShooting = 0.2f;

    void Update()
    {
        Destroy(GameObject.FindGameObjectWithTag("bullet"), 2);
        Destroy(GameObject.FindGameObjectWithTag("bulletFire"), 2);
        Destroy(GameObject.FindGameObjectWithTag("bulletToxic"), 2);
        checkIfShouldShoot();
    }

    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shoot();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
                Destroy(bullet.gameObject, 2);
            }
        }
    }

    void shoot()
    {
        bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
    }
}
