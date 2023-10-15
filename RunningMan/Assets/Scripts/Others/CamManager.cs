using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;

    Character character;

    public GameObject trs;
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
            transform.position = Vector3.Lerp(transform.position, trs.transform.position,.05f);
            transform.rotation = Quaternion.Lerp(transform.rotation,trs.transform.rotation, .05f);
        }

    }
}
