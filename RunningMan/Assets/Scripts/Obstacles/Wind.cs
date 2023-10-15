using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int windValue;

    public GameObject fanObject;
    Fan fan;

    private void Start()
    {
        fan = fanObject.GetComponent<Fan>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AiAgent"))
        {
            if (fan.anim == true)
            {
                other.GetComponent<Rigidbody>().AddForce(new Vector3(windValue, 0, 0), ForceMode.Impulse);
            }
                
            else
                other.GetComponent<Rigidbody>().AddForce(Vector3.zero);
        }

    }
}
