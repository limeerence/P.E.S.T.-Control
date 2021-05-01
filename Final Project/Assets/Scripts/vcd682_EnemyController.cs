using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vcd682_EnemyContoller : MonoBehaviour
{
    [SerializeField] private int aggroRange = 30; //The range at which the enemy will begin to follow the player
    [SerializeField] private int startAttackRange = 7; //The range at which the enemy will start their attack animation
    [SerializeField] protected int health = 50;
    [SerializeField] private int aggroSpeed = 2;
    [SerializeField] private int leashRange = 10000; //The max range the enemy can move from its spawnpoint
    private Vector3 spawnpoint;
    [SerializeField] protected bool isAggroed = false;

    [SerializeField] private int contactDamage = 10; //The amount of damage the player will take by touching this enemy
    [SerializeField] private int attackDamage = 20; //The amount of damage the player will take from the attack animation of this enemy

    protected Animator anim;
    protected NavMeshAgent agent;
    private Transform playerLoc;

    protected bool isAttacking = false;
    private float wanderRange = 2.5f;
    private int passiveSpeed = 1;
    protected bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = transform.position; //Record the spawnpoint for leashing

        //Grab the Mesh agent and locate the player
        agent = GetComponent<NavMeshAgent>();
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = passiveSpeed; //Set the speed of the enemy to it's passive wander speed
    }

    // Update is called once per frame
    void Update()
    {
        //Set aggro if player is within range
        if (!isAggroed && Vector3.Distance(playerLoc.position, transform.position) < aggroRange)
        {
            isAggroed = true;
            agent.speed = aggroSpeed;
        }

        if (isAggroed)
        {
            agent.SetDestination(playerLoc.position);

            //If the enemy is entering it's attack animation, pause the nav
            if (isAttacking)
                agent.isStopped = true;
            else
            {
                //Resume the nav if not attacking
                agent.isStopped = false;

                //Check if in range to start another attack
                if(Vector3.Distance(playerLoc.position, transform.position) < startAttackRange)
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
            enterDeathState();
    }

    void enterDeathState()
    {
        isDead = true;
        agent.isStopped = true;

        anim.SetTrigger("Die");
        Destroy(gameObject, 5f);
    }

    void attack()
    {
        
    }
}
