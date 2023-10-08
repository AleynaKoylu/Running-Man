using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Aleyna;

public class MainMenuManager : MonoBehaviour
{
    DataManager dataManager = new DataManager();
    public List<ItemsDatas> _itemsDatas = new List<ItemsDatas>();
    public AudioSource buttonAudio;
    private void Start()
    {
        MemoryManager.KeyControl();
        dataManager.firstSave(_itemsDatas);
    }
    public void sceneLoad(int sceneID)
    {
        buttonAudio.Play();
        SceneManager.LoadScene(sceneID);
    }
    public void quitGame()
    {
        buttonAudio.Play();
        Debug.Log(1);
       // Application.Quit();
    }
    public void play()
    {
        buttonAudio.Play();
        SceneManager.LoadScene(MemoryManager.GetData_Int("LastLevel"));

       
    }
   
}
