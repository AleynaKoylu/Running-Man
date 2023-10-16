using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class AICharacter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMeshAgent;

    public GameObject gameManagerObject;
    GameManager gameManager;
    Scene scene2;
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
        if (other.gameObject.CompareTag("Obstacles") || (other.gameObject.CompareTag("NeedleBox") || (other.gameObject.CompareTag("NeedleWall"))))
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

            scene2 = SceneManager.GetActiveScene();
            if (scene2.name == "Level5" || scene2.name == "Level10" || scene2.name == "Level5" || scene2.name == "Level20")
            {

                gameObject.SetActive(false);
                other.gameObject.transform.localScale = Vector3.Lerp(other.gameObject.transform.localScale, new Vector3(other.gameObject.transform.localScale.x - .1f, other.gameObject.transform.localScale.z - .1f, other.gameObject.transform.localScale.y - .1f), 1);
                gameManager.eEffectsCreate(givePos(.25f));
                if (other.transform.localScale.x <= 0.0001f && other.transform.localScale.y <= 0.0001f && other.transform.localScale.z <= 0.0001f)
                {
                    other.gameObject.SetActive(false);
                    gameManager.enemysNumber = 0;
                }
                else
                {
                    gameManager.enemysNumber = 1;

                }
            }
            else
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                gameManager.enemysNumber--;
                gameManager.eEffectsCreate(givePos(.25f));
            }
        }
    }


}
