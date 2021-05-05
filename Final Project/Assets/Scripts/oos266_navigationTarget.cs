using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class oos266_navigationTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    NavMeshAgent agent;

    void Start()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
