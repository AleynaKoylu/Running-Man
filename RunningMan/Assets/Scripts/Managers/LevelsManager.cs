using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aleyna;
public class LevelsManager : MonoBehaviour
{
    public List<Button> LevelButtons = new List<Button>();

    public int Level;

    public Sprite sprite;

    public AudioSource audioSource;
    DataManager dataManager = new DataManager();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> languageDatasMainObject2 = new List<LanguageDatasMainObject>();
    public List<Text> texts = new List<Text>();
    public GameObject LoadingScene;
    public Slider LoadSceneSlider;
    void Start()
    {
        dataManager.LoadLang();
        languageDatasMainObject2 = dataManager.TakeListLang();
        languageDatasMainObjects.Add(languageDatasMainObject2[2]);
        checkLanguage();
        audioSource.volume = PlayerPrefs.GetFloat("MenuFx");
        levelControl();

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
    void levelControl()
    {
        int nowLevel = MemoryManager.GetData_Int("LastLevel") - 4;
        int Index = 1;
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (Index <= nowLevel)
            {
                LevelButtons[i].GetComponentInChildren<Text>().text = Index.ToString();
                int sceneIndex = Index + 4;
                LevelButtons[i].onClick.AddListener(delegate { loadScene(sceneIndex); });

            }
            else
            {
                LevelButtons[i].GetComponent<Image>().sprite = sprite;
                LevelButtons[i].GetComponent<Image>().color = new Color(0.0509804f, 0.9960785f, 0, 1);
                LevelButtons[i].enabled = false;
            }
            Index++;
        }
    }
    public void loadScene(int index)
    {
        audioSource.Play();
        StartCoroutine(LoadAsync(index));

    }
    public void backMainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }
}
