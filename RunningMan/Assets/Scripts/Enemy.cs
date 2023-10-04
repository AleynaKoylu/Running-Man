using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject warTarget;
    Character character;
    Animator animator;


    NavMeshAgent meshAgent;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = warTarget.GetComponentInParent<Character>();
        meshAgent = GetComponent<NavMeshAgent>();
    }


    void LateUpdate()
    {
        agentControl();
    }
    void agentControl()
    {
        if (character.war == true)
        {
            animator.SetBool("War", true);
            meshAgent.SetDestination(warTarget.transform.position);
        }
      
    }


}
