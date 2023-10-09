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
    void Start()
    {


        sliders[0].value = MemoryManager.GetData_Float("MenuSound");
        sliders[1].value=MemoryManager.GetData_Float("MenuFx");
        sliders[2].value=MemoryManager.GetData_Float("GameSound");
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
    public void ChangeLanguage()
    {

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
