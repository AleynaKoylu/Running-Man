using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public GameObject warTarget;
    Character character;
    Animator animator;

    Scene scene;
    NavMeshAgent meshAgent;
    GameObject GameeManager;
    GameManager gameManager;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = warTarget.GetComponentInParent<Character>();
        meshAgent = GetComponent<NavMeshAgent>();
       GameeManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GameeManager.GetComponent<GameManager>();
    }


    void LateUpdate()
    {
        agentControl();
    }
    void agentControl()
    { scene = SceneManager.GetActiveScene();
        if (character.war == true)
        {

            if (scene.name == "Level5" || scene.name == "Level10" || scene.name == "Level15" || scene.name == "Level20")
            {
                //animator.SetBool("War", true);
                gameManager.enemys(gameObject);
            }
            else
            {
                    animator.SetBool("War", true);
                    meshAgent.SetDestination(warTarget.transform.position);
                
            }

        }
    }
    


}
