using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5;

    public Vector3 targetPos;
    public int damage = 1;

    private void Update()
    {
        if(targetPos!= null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * projectileSpeed);

            float dist = Vector3.Distance(transform.position, targetPos);
            if(dist <= .1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Damaging player with bullet");
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
            gameManager.GetComponent<oos266_GameController>().updateHealth(-damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            return;
        }
    }
    
}
