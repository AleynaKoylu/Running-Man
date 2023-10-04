using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aleyna;
public class GameManager : MonoBehaviour
{

    public GameObject aiPos1;


    public static int noInstantCharacters = 1;

    public List<GameObject> aiobjects = new List<GameObject>();
    public List<GameObject> bEffects = new List<GameObject>();
    public List<GameObject> eEffects = new List<GameObject>();

    public List<GameObject> Stain = new List<GameObject>();
    public GameObject charr;
    Character character;

    [Header("Level Data")]
    public List<GameObject> Enemys = new List<GameObject>();
    public int enemysNumber;

    public bool finishGame;

   
    void Start()
    {
        activeEnemy();
        character = charr.GetComponent<Character>();

    }


    void Update()
    {
       
        if (finishGame == false)
            WarStopp();
        Debug.Log(noInstantCharacters);
    }
    public void addedChar(GameObject newChar)
    {
        aiobjects.Add(newChar);
        noInstantCharacters++;
    }
    void WarStopp()
    {


        if (character.war == true)
        {
            
            if (noInstantCharacters == 1 || enemysNumber == 0)
            {
                finishGame = true;
               
                foreach (var item in aiobjects)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("War", true);
                    }
                }
                charr.GetComponent<Animator>().SetBool("War", true);
                if (noInstantCharacters < enemysNumber || noInstantCharacters == enemysNumber)
                {
                    Debug.Log("Kayýp");
                    Debug.Log("AI=" + noInstantCharacters);
                    Debug.Log("E=" + enemysNumber);

                }
                else
                {
                    Debug.Log("Kazan");
                    Debug.Log("AI=" + noInstantCharacters);
                    Debug.Log("E=" + enemysNumber);
                
                   
                }

            }

        }
    }
    public void aiCharactersActive(string tag, int nmbr, Transform trsf)
    {

        switch (tag)
        {
            case "Multiplication":


                Library.Multiplication(aiobjects, nmbr, trsf, bEffects);

                break;

            case "Addition":

                Library.Addition(aiobjects, nmbr, trsf, bEffects);

                break;
            case "Subtraction":

                Library.Subtraction(aiobjects, nmbr, eEffects);


                break;
            case "Division":

                Library.Division(aiobjects, nmbr, eEffects);


                break;
        }


    }

    public void eEffectsCreate(Vector3 pos)
    {
        foreach (var item in eEffects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = pos;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                noInstantCharacters--;
                break;
            }
        }
    }

    public void activeStain(Vector3 stainPos)
    {
        foreach (var item in Stain)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = stainPos;
                break;
            }
        }
    }

    public void activeEnemy()
    {
        for (int i = 0; i < enemysNumber; i++)
        {
            Enemys[i].SetActive(true);
        }

    }
}
