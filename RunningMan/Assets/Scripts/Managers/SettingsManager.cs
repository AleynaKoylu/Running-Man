using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aleyna;

public class SettingsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<Slider> sliders = new List<Slider>();

    public List<Button> buttons = new List<Button>();
    int langIndex = 0;
    public List<Text> langTexts = new List<Text>();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>();
    List<LanguageDatasMainObject> languageDatasMainObject2 = new List<LanguageDatasMainObject>();
    public List<Text> texts = new List<Text>();
    DataManager dataManager = new DataManager();


    void Start()
    {
        changeLanguageResult();
        dataManager.LoadLang();
        languageDatasMainObject2 = dataManager.TakeListLang();
        languageDatasMainObjects.Add(languageDatasMainObject2[4]);
        checkLanguage();
        sliderValue();
        
    }
    void checkLanguage()
    {
        switch (MemoryManager.GetData_String("Language"))
        {

            case "EN":
                langIndex = 0;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_EN[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }

                activeButton(false, true);
                break;
            case "TR":
                langIndex = 1;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_TR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                activeButton(true, true);

                break;
            case "AZ":
                langIndex = 2;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_AZ[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                activeButton(true, true);
                break;
            case "KR":
                langIndex = 3;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_KR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                activeButton(true, true);
                break;
            case "JP":

                langIndex = 4;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_JP[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                activeButton(true, true);
                break;
            case "GR":

                langIndex = 5;
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_GR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                activeButton(true, false);
                break;

        }
    }

    private void Update()
    {
       
    }
    void sliderValue()
    {
        sliders[0].value = MemoryManager.GetData_Float("MenuSound");
        sliders[1].value = MemoryManager.GetData_Float("MenuFx");
        sliders[2].value = MemoryManager.GetData_Float("GameSound");
    }
    public void SettingSliders(int index)
    {
        switch (index)
        {
            case 0:

                MemoryManager.SaveData_Float("MenuSound", sliders[0].value);
                break;
            case 1:

                MemoryManager.SaveData_Float("MenuFx", sliders[1].value);
                break;
            case 2:

                MemoryManager.SaveData_Float("GameSound", sliders[2].value);
                break;
        }
    }

    public void changeLanguage(bool bf)
    {
        if (bf == true)
        {
            langIndex++;
            switch (langIndex)
            {
                case 0:
                    MemoryManager.SaveData_String("Language", "EN");
                        for (int i = 0; i < texts.Count; i++)
                        {
                            texts[i].text = languageDatasMainObjects[0].languageDatas_EN[i].text;
                            texts[i].fontStyle = FontStyle.Normal;
                        }
                    
                    activeButton(false, true);
                    break;
                case 1:
                    MemoryManager.SaveData_String("Language", "TR");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_TR[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);

                    break;
                case 2:
                    MemoryManager.SaveData_String("Language", "AZ");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_AZ[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);
                    break;
                case 3:
                    MemoryManager.SaveData_String("Language", "KR");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_KR[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);
                    break;
                case 4:

                    MemoryManager.SaveData_String("Language", "JP");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_JP[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);
                    break;
                case 5:

                    
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_GR[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, false);
                    break;
            }
        }
        else
        {

            langIndex--;

            switch (langIndex)
            {
                case 0:
                    MemoryManager.SaveData_String("Language", "EN");
                 
                        for (int i = 0; i < texts.Count; i++)
                        {
                            texts[i].text = languageDatasMainObjects[0].languageDatas_EN[i].text;
                            texts[i].fontStyle = FontStyle.Normal;
                        }
                    activeButton(false, true);

                    break;
                case 1:
                    MemoryManager.SaveData_String("Language", "TR");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_TR[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);

                    break;
                case 2:
                    MemoryManager.SaveData_String("Language", "AZ");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_AZ[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
                    activeButton(true, true);
                    break;
                case 3:
                    MemoryManager.SaveData_String("Language", "KR");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_KR[i].text;
                        texts[i].fontStyle = FontStyle.Bold;
                    }
                    activeButton(true, true);
                    break;
                case 4:

                    MemoryManager.SaveData_String("Language", "JP");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_JP[i].text;
                        texts[i].fontStyle = FontStyle.Bold;
                    }
                    activeButton(true, true);
                    break;
                case 5:

                    MemoryManager.SaveData_String("Language", "GR");
                    for (int i = 0; i < texts.Count; i++)
                    {
                        texts[i].text = languageDatasMainObjects[0].languageDatas_GR[i].text;
                        texts[i].fontStyle = FontStyle.Normal;
                    }
           
                    activeButton(true, false);
                    break;
            
        }

        }
    }

    void activeButton(bool buttonActive0, bool buttonActive1)
    {
        buttons[0].interactable = buttonActive0; 
        buttons[1].interactable = buttonActive1;
    }
        void changeLanguageResult()
        {
            switch (MemoryManager.GetData_String("Language"))
            {
                case "EN":
                    langIndex = 0;
                    buttons[0].interactable = false;
                    buttons[1].interactable = true;
                    break;
                case "TR":
                    langIndex = 1;
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    break;
                case "AZ":
                    langIndex = 2;
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    break;
                case "KR":
                    langIndex = 3;
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    break;
                case "JP":
                    langIndex = 4;
                    buttons[0].interactable = true;
                    buttons[1].interactable = true;
                    break;
                case "GR":
                    langIndex = 5;
                    buttons[1].interactable = false;
                    buttons[0].interactable = true;
                    break;

            }
        }
        public void AudioControl()
        {
            audioSource.Play();
        }
        public void BackMenu()
        {
            SceneManager.LoadScene(0);
        }
    } 
