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
    public Text text;

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
                
                   text.text = languageDatasMainObjects[0].languageDatas_TR[0].text;
                    text.fontStyle = FontStyle.Normal;
               
                break;
            case "AZ":

                text.text = languageDatasMainObjects[0].languageDatas_AZ[0].text;
                text.fontStyle = FontStyle.Normal;
              
                break;
            case "EN":
                text.text = languageDatasMainObjects[0].languageDatas_EN[0].text;
                text.fontStyle = FontStyle.Normal;
                break;
            case "KR":
                text.text = languageDatasMainObjects[0].languageDatas_KR[0].text;
                text.fontStyle = FontStyle.Bold;
                break;
            case "GR":
                text.text = languageDatasMainObjects[0].languageDatas_GR[0].text;
                text.fontStyle = FontStyle.Normal;
                break;
            case "JP":
                text.text = languageDatasMainObjects[0].languageDatas_JP[0].text;
                text.fontStyle = FontStyle.Bold;
                break;

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
        SceneManager.LoadScene(index);

    }
    public void backMainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }
}
