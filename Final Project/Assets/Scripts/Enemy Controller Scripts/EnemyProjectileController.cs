using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5;

    public Transform target;
    public int damage = 1;

    private void Update()
    {
        if(target!= null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * projectileSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Damaging player");
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
            gameManager.GetComponent<oos266_GameController>().updateHealth(-damage);
            Debug.Log("Destroying projectile");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            return;
        }
        else
            Destroy(gameObject);

    }
}
