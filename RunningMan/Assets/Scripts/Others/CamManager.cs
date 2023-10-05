using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;

    Character character;

    public Vector3 tranformPos;//,12-3,73,32,95, 
    public Quaternion transformRot;//45.195
    void Start()
    {
        character = target.gameObject.GetComponent<Character>();
        targetOffset = transform.position - target.position;
    }


    private void LateUpdate()
    {
        if (character.war == false)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, tranformPos,.01f);
            transform.rotation = Quaternion.Lerp(transform.rotation, transformRot, .01f);
        }

    }
}
