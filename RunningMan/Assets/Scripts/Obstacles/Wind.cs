using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int windValue;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AiAgent"))
        {
          
                other.GetComponent<Rigidbody>().AddForce(new Vector3(windValue, 0, 0), ForceMode.Impulse);
            
        }

    }
}
