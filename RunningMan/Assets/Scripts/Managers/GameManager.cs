using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aleyna;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region
    [Header("Other")]
    public List<AudioSource> audioSource = new List<AudioSource>();
    public GameObject aiPos1;
    Scene scene,scene2, scene3;

    public Image settingsPanel;
    public List<Button> QSButtons = new List<Button>();
    public static int noInstantCharacters = 1;
    public List<GameObject> aiobjects = new List<GameObject>();
    public List<GameObject> bEffects = new List<GameObject>();
    public List<GameObject> eEffects = new List<GameObject>();
    public List<GameObject> Stain = new List<GameObject>();
    public GameObject charr;
    Character character;
    public SkinnedMeshRenderer nskinnedMeshRenderer;
    public Slider soundSlider;
    public List<Image> LoseWinPanels = new List<Image>();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> languageDatasMainObject2 = new List<LanguageDatasMainObject>();
    public List<Text> texts = new List<Text>();
    DataManager dataManager = new DataManager();
    public GameObject LoadingScene;
    public Slider LoadSceneSlider;

    #endregion
    #region
    [Header("Level Data")]
    public List<GameObject> Enemys = new List<GameObject>();
    public int enemysNumber;
    public bool finishGame;
    #endregion
    #region
    [Header("COSTUME")]
    public List<GameObject> Hats = new List<GameObject>();
    public List<GameObject> Sticks = new List<GameObject>();
    public List<Material> Costumes = new List<Material>();
    public Material defaulMaterial;
    #endregion
    private void Awake()
    {
        audioSource[0].volume = MemoryManager.GetData_Float("GameSound");
        soundSlider.value = MemoryManager.GetData_Float("GameSound");
        audioSource[1].volume = MemoryManager.GetData_Float("MenuFx");
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
        checkItems();
        foreach (var item in aiobjects)
        {
            item.SetActive(false);
            noInstantCharacters = 1;
        }
    }
    void Start()
    {

        activeEnemy();
        character = charr.GetComponent<Character>();
        scene = SceneManager.GetActiveScene();
        dataManager.LoadLang();
        languageDatasMainObject2 = dataManager.TakeListLang();
        languageDatasMainObjects.Add(languageDatasMainObject2[5]);
        checkLanguage();
    }
    void Update()
    {
        if (finishGame == false)
            WarStopp();
        AnimStop();
        if (noInstantCharacters == 0)
        {
            noInstantCharacters = 1;
        }

    }
    void checkLanguage()
    {
        switch (MemoryManager.GetData_String("Language"))
        {
            case "TR":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_TR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                break;
            case "AZ":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_AZ[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                break;
            case "EN":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_EN[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                break;
            case "KR":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_KR[i].text;
                    texts[i].fontStyle = FontStyle.Bold;
                }
                break;
            case "GR":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_GR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                break;
            case "JP":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_JP[i].text;
                    texts[i].fontStyle = FontStyle.Bold;
                }
                break;

        }
    }
    #region Game

    void AnimStop()
    {
        if (character.StopAnim == true)
        {
            foreach (var item in aiobjects)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("War", true);
                }
            }
            charr.GetComponent<Animator>().SetBool("War", true);
        }
    }
    void WarStopp()
    {


        if (character.war == true)
        {

            if (noInstantCharacters == 1 || enemysNumber == 0)
            {
                finishGame = true;

                if (noInstantCharacters < enemysNumber || noInstantCharacters == enemysNumber)
                {
                    LoseWinPanels[0].gameObject.SetActive(true);

                }
                else
                {
                    scene3 = SceneManager.GetActiveScene();
                    if (scene3.name != "Level20")
                        schange(MemoryManager.GetData_Int("LastLevel") + 1);
                    else
                        schange(24);
                }

            }
         

        }
    }
    void schange(int sceneID)
    {
        if (noInstantCharacters > 5)
        {
            MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") + 600);
            if (scene.buildIndex == MemoryManager.GetData_Int("LastLevel"))
            {
                MemoryManager.SaveData_Int("LastLevel", sceneID);
            }
        }

        else
        {
            MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") + 200);
            if (scene.buildIndex == MemoryManager.GetData_Int("LastLevel"))
            {
                MemoryManager.SaveData_Int("LastLevel", sceneID);
            }
        }
        LoseWinPanels[1].gameObject.SetActive(true);
    }
    #endregion
    #region
    public void addedChar(GameObject newChar)
    {
        aiobjects.Add(newChar);
        noInstantCharacters++;
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
        scene2 = SceneManager.GetActiveScene();
        for (int i = 0; i < enemysNumber; i++)
        {
            Enemys[i].SetActive(true);
        }
        if (scene2.name == "Level5" || scene2.name == "Level10" || scene2.name == "Level15" || scene2.name == "Level20")
        {
            for (int i = 0; i < enemysNumber; i++)
            {
                Enemys[i].transform.localScale = new Vector3(.6f, .6f, .6f);
            }

           


        }



    }

    #endregion
    #region
    public void enemys(GameObject gameObject)
    {
            if (noInstantCharacters > 1 && enemysNumber > 0)
            {
                for (int j = 0; j < aiobjects.Count; j++)
                {
                    if (aiobjects[j].activeInHierarchy && character.StopAnim == true)
                    {
                        
                           gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, aiobjects[j].transform.position,.05f);

                        
                    }

                }

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
    public void Buttons(string name)
    {
        switch (name)
        {
            case "Setting":
                foreach (var item in QSButtons)
                {
                    item.gameObject.SetActive(false);
                    settingsPanel.gameObject.SetActive(true);
                }

                Time.timeScale = 0;

                break;
            case "Quit":
                SceneManager.LoadScene(0);
                Time.timeScale = 1;

                break;
            case "Replay":
                SceneManager.LoadScene(scene.buildIndex);
                Time.timeScale = 1;

                break;
            case "Game":
                foreach (var item in QSButtons)
                {
                    item.gameObject.SetActive(true);
                }

                settingsPanel.gameObject.SetActive(false);
                Time.timeScale = 1;

                break;
            case "NextLevel":
                StartCoroutine(LoadAsync(scene.buildIndex + 1));
                break;
        }

    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScene.SetActive(true);
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            LoadSceneSlider.value = progress;
            yield return null;
        }
    }
    public void ButtonSound()
    {
        audioSource[1].Play();
    }
    public void Settings()
    {
        MemoryManager.SaveData_Float("GameSound", soundSlider.value);
        audioSource[0].volume = soundSlider.value;

    }
    #endregion


}
