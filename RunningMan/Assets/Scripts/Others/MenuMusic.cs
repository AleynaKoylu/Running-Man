using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static GameObject instance;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
      //  audioSource.volume = PlayerPrefs.GetFloat("MenuAudio");
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

}
