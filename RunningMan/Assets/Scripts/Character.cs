using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public GameObject gameManagerObject;
    GameManager gameManager;

    public bool war;

    public Transform stopArea;

    public RuntimeAnimatorController emptyCharAnim;

    public GameObject stop;
    public Slider slider;
    float distance;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();

        distance = Vector3.Distance(transform.position, stop.transform.position);
        slider.maxValue = distance;

    }
    private void FixedUpdate()
    {
        if (war == false)
            transform.Translate(transform.forward * .5f * Time.deltaTime);
    }


    void Update()
    {
        charMovement();
        
    }

    void charMovement()
    {
        if (war == false)
        {
            distance = Vector3.Distance(transform.position, stop.transform.position);
            slider.value = distance;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }

            }
        }
        else
        {
            transform.position =Vector3.Lerp(transform.position, stopArea.position,0.015f);
            if(slider.value!=0)
            slider.value -= .1f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.CompareTag("Multiplication") || other.gameObject.transform.CompareTag("Addition") || other.gameObject.transform.CompareTag("Subtraction") || other.gameObject.transform.CompareTag("Division"))
        {
            int number = int.Parse(other.gameObject.name);
            gameManager.aiCharactersActive(other.tag, number, other.transform);


        }

        if (other.gameObject.transform.CompareTag("WarArea"))
        {
            war = true;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Straight")|| collision.gameObject.CompareTag("NeedleBox"))
        {
          if(transform.position.x>0)
            transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
          else
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
        }
        if (collision.gameObject.CompareTag("NeedleWall"))
        {
            if (transform.position.x > collision.gameObject.transform.position.x)
                transform.position = new Vector3(transform.position.x -.4f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x +.4f, transform.position.y, transform.position.z);
        }
    }
}
