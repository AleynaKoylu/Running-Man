using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aleyna;

public class MainMenuManager : MonoBehaviour
{
    DataManager dataManager = new DataManager();
    public List<ItemsDatas> defaultItemDatas = new List<ItemsDatas>();
    public AudioSource buttonAudio;
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    public List<Text> texts = new List<Text>();
    public List<LanguageDatasMainObject> defaultLanguageData = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> languageReadDatas = new List<LanguageDatasMainObject>();
    public GameObject LoadingScene;
    public Slider LoadSceneSlider;
    private void Start()
    {
        MemoryManager.KeyControl();
     // dataManager.firstSave(defaultItemDatas,defaultLanguageData);
        buttonAudio.volume = PlayerPrefs.GetFloat("MenuFx");

 
        dataManager.LoadLang();
        languageReadDatas = dataManager.TakeListLang();
        languageDatasMainObjects.Add(languageReadDatas[0]);
        checkLanguage();
        
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

    public void sceneLoad(int sceneID)
    {
        buttonAudio.Play();
        SceneManager.LoadScene(sceneID);
    }
    public void quitGame()
    {
        buttonAudio.Play();
        Application.Quit();
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
    public void play()
    {
        buttonAudio.Play();
        StartCoroutine(LoadAsync(MemoryManager.GetData_Int("LastLevel")));
       
    }
   
}
