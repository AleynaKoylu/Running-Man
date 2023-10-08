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
    public SkinnedMeshRenderer nskinnedMeshRenderer;

    [Header("Level Data")]
    public List<GameObject> Enemys = new List<GameObject>();
    public int enemysNumber;

    public bool finishGame;

    [Header("COSTUME")]
    public List<GameObject> Hats = new List<GameObject>();
    public List<GameObject> Sticks = new List<GameObject>();
    public List<Material> Costumes = new List<Material>();
    public Material defaulMaterial;
    private void Awake()
    {
        checkItems();
    }
    void Start()
    {
        activeEnemy();
        character = charr.GetComponent<Character>();

        
    }


    void Update()
    {
       
        if (finishGame == false)
            WarStopp();
       
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
                    

                }
                else
                {
                    if (noInstantCharacters > 5)
                    {
                        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") + 600);
                        Debug.Log(MemoryManager.GetData_Int("Point"));
                        MemoryManager.SaveData_Int("LastLevel", MemoryManager.GetData_Int("LastLevel") + 1);
                    }
                    else 
                    {
                        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") + 200);
                        Debug.Log(MemoryManager.GetData_Int("Point"));
                        MemoryManager.SaveData_Int("LastLevel", MemoryManager.GetData_Int("LastLevel") + 1);
                    }
                    
                    
                
                   
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

    public void checkItems()
    {
        if (MemoryManager.GetData_Int("ActiveHat") != -1)
            Hats[MemoryManager.GetData_Int("ActiveHat")].SetActive(true);
        if (MemoryManager.GetData_Int("ActiveStick") != -1)
            Sticks[MemoryManager.GetData_Int("ActiveStick")].SetActive(true);
        if (MemoryManager.GetData_Int("ActiveCostume") != -1)
        {
            Material[] materials = nskinnedMeshRenderer.materials;
            materials[0] = Costumes[MemoryManager.GetData_Int("ActiveCostume")];
            nskinnedMeshRenderer.materials = materials;
        }
        else
        { 
        Material[] materials = nskinnedMeshRenderer.materials;
        materials[0] = defaulMaterial;
        nskinnedMeshRenderer.materials = materials;
        }

    }
}
