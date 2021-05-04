using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vcd682_EnemyContoller : MonoBehaviour
{
    [SerializeField] private int aggroRange = 30; //The range at which the enemy will begin to follow the player
    [SerializeField] private int startAttackRange = 15; //The range at which the enemy will start their attack animation
    [SerializeField] protected int health = 10;
    [SerializeField] private int aggroSpeed = 2;
    [SerializeField] private int leashRange = 10000; //The max range the enemy can move from its spawnpoint
    private Vector3 spawnpoint;
    [SerializeField] protected bool isAggroed = false;

    [SerializeField] protected int contactDamage = 1; //The amount of damage the player will take by touching this enemy
    [SerializeField] protected int attackDamage = 2; //The amount of damage the player will take from the attack animation of this enemy

    protected Animator anim;
    protected NavMeshAgent agent;
    protected Transform playerLoc;

    protected bool isAttacking = false;
    private float wanderRange = 2.5f;
    private int passiveSpeed = 1;
    protected bool isDead = false;


    void Start()
    {
        spawnpoint = transform.position; //Record the spawnpoint for leashing
        anim = GetComponent<Animator>();

        //Grab the Mesh agent and locate the player
        agent = GetComponent<NavMeshAgent>();
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = passiveSpeed; //Set the speed of the enemy to it's passive wander speed
    }

    void Update()
    {
        //Debug.Log(health); -pnf839 just checking 

        //Set aggro if player is within range
        if (!isAggroed && Vector3.Distance(playerLoc.position, transform.position) < aggroRange)
        {
            isAggroed = true;
            agent.speed = aggroSpeed;
        }

        if (isAggroed)
        {
            //If the enemy is entering it's attack animation, pause the nav
            if (isAttacking)
                agent.enabled = false;
            else
            {
                //Resume the nav if not attacking
                agent.enabled = true;
                agent.SetDestination(playerLoc.position);

                //Face the player
                transform.LookAt(playerLoc);


                //Check if in range to start another attack
                if (Vector3.Distance(playerLoc.position, transform.position) < startAttackRange)
                {
                    attack();
                }
            }
        }
        else
        {
            if (!isDead)
                passiveWander();
            else
                agent.isStopped = true;
        }
    }

    void passiveWander()
    {
        //if the agent has reached its last wander dest, set a new one within the wanderRange
        if(agent.remainingDistance <= .2)
        {
            Vector3 newDest = new Vector3(spawnpoint.x + Random.Range(-wanderRange, wanderRange), spawnpoint.y, spawnpoint.z + Random.Range(-wanderRange, wanderRange));
            agent.SetDestination(newDest);
        }
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(gameObject); //pnf839- i made it so it would just die because since there is no animator, it just
                                                //comes back to life and it doesn't die
        //enterDeathState();
    }

    void enterDeathState()
    {
        isDead = true;
        agent.isStopped = true;

        anim.SetTrigger("Die");
        Destroy(gameObject, 5f);
    }

    protected virtual void attack()
    {
        Debug.Log("Whoops, entered the wrong method");
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            gameController.GetComponent<oos266_GameController>().updateHealth(-contactDamage);
        }
        else if(collision.gameObject.tag == "bullet") //pnf839- i changed the bullet to lowercase because that's what the tag was, sorry for the confusion.
        {
            Debug.Log("enemy taking damage");
            takeDamage(1);
        }
        else if (collision.gameObject.tag == "bulletFire") //pnf839 - H E L P: this one and the bulletToxic won't affect the enemy and idk why :/
        {
            Debug.Log("taking fire damage");
            takeDamage(6);
        }
        else if (collision.gameObject.tag == "bulletToxic")
        {
            Debug.Log("toxic damage");
            takeDamage(4);
        }
    }
}
