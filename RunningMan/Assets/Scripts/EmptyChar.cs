using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyChar : MonoBehaviour
{
    public GameManager gameManager;
    Animator animator;
    AICharacter ýCharacter;

    public RuntimeAnimatorController emptyCharAnim;
    public Material material;
    public SkinnedMeshRenderer meshRenderer;

    AudioSource audioSource;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        ýCharacter = GetComponent<AICharacter>();

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player") || other.gameObject.transform.CompareTag("AiAgent"))
        {
            matAndAnim();
            this.enabled = false;
        }


    }
    void matAndAnim()
    {
        ýCharacter.enabled = true;
        if (gameObject.CompareTag("EmptyCharacter"))
            gameManager.addedChar(gameObject);
        gameObject.tag = "AiAgent";
        animator.runtimeAnimatorController = emptyCharAnim;
        Material[] mats = meshRenderer.materials;
        mats[0] = material;
        meshRenderer.materials = mats;
    }
}
