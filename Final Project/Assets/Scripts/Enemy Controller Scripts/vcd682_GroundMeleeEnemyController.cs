using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vcd682_GroundMeleeEnemyController : vcd682_EnemyContoller 
{
    [SerializeField] private bool hasAttackAnimation = false; //If false, use the this script's default attack anim
    [SerializeField] private float attackAnimDuration = 5f;


    protected override void attack()
    {
        isAttacking = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (hasAttackAnimation)
        {
            //Run the given attack anim and run a timer for the duration
            anim.SetTrigger("Attack");
            StartCoroutine("attackTimer");
        }
        else
        {
            StartCoroutine("DefaultAttack");
        }
    }


    IEnumerator DefaultAttack()
    {
        transform.LookAt(playerLoc); // Aim at the player
        yield return new WaitForSeconds(1f); // Give them a moment to dodge

        //Charge at the player
        GetComponent<Rigidbody>().AddForce(transform.forward * 15, ForceMode.Impulse);
        yield return new WaitForSeconds(4f);

        //Reset vel so the enemy doesn't end up sliding across the whole map
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        isAttacking = false;
    }

    IEnumerator attackTimer()
    {
        yield return new WaitForSeconds(attackAnimDuration);
        isAttacking = true;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");

            if (isAttacking)
            {
                gameManager.GetComponent<oos266_GameController>().updateHealth(-attackDamage);
            }
            else
            {
                gameManager.GetComponent<oos266_GameController>().updateHealth(-contactDamage);
            }
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            takeDamage(1);
        }
    }
}
