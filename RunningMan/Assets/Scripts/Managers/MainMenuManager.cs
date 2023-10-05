using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Aleyna;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        MemoryManager.KeyControl();
    }
    public void sceneLoad(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void play()
    {
        SceneManager.LoadScene(MemoryManager.GetData_Int("LastLevel"));
       
    }
}
