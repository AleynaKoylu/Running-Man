using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Aleyna;

public class MainMenuManager : MonoBehaviour
{
    DataManager dataManager = new DataManager();
    public List<ItemsDatas> _itemsDatas = new List<ItemsDatas>();
    private void Start()
    {
        MemoryManager.KeyControl();
        dataManager.firstSave(_itemsDatas);
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
