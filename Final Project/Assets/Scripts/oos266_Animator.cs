using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oos266_Animator : MonoBehaviour
{
    private Animator anim;
    private Rigidbody m_RigidBody;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Speed", m_RigidBody.velocity.magnitude);
    }
}
