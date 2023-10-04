using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMeshAgent;

    public GameObject gameManagerObject;
    GameManager gameManager;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
        target = gameManager.aiPos1;
    }
   

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }
    Vector3 givePos(float y)
    {

        return new Vector3(transform.position.x, y, transform.position.z); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles")||(other.gameObject.CompareTag("NeedleBox") || (other.gameObject.CompareTag("NeedleWall"))))
        {

            gameManager.eEffectsCreate(givePos(.5f));
            gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Sled"))
        {
            gameManager.eEffectsCreate(givePos(.5f));
            gameManager.activeStain(givePos(.01f));
            gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            gameManager.enemysNumber--;
            gameManager.eEffectsCreate(givePos(.25f));
        }
    }
}
