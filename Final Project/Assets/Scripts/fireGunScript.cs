using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGunScript : MonoBehaviour
{
    public Rigidbody pillbug;
    public float bulletSpeed = 100;
    public int bulletsRemaining = 10;
    bool allowShoot = true;
    private Rigidbody bullet;
    public oos266_GameController gameController;

    [System.Obsolete]
    void Update()
    {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine("wait");
                Destroy(bullet.gameObject, 2);

            }
        
    }

    public IEnumerator wait()
    {
        allowShoot = false;
        for (int i = 0; i < 10; i++)
        {
            bullet = Instantiate(pillbug, transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        }
        bulletsRemaining -= 1;
        yield return new WaitForSeconds(0.2f);
    }


    public void Start()
    {
        allowShoot = true;

        if (!gameController)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<oos266_GameController>();
        }
    }
}
