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
    void Start()
    {
        audioSource.volume=  PlayerPrefs.GetFloat("MenuFx");
        
        int nowLevel = MemoryManager.GetData_Int("LastLevel")-4;
        int Index = 1;
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (Index <= nowLevel)
            {
                LevelButtons[i].GetComponentInChildren<Text>().text = Index.ToString();
               int sceneIndex =Index+4;
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
