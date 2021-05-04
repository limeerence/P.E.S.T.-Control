using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nok631_bulletCollide : MonoBehaviour
{
    private nko631_Shooting s;
    private nko631_Enemy e;
    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            Debug.Log("Wall hit");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("enemy hit");
        }
    }
}
