using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aleyna;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class CostumeManager : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    int hatIndex = -1;
    public List<ItemsDatas> _itemsDatas = new List<ItemsDatas>();

    [Header("COSTUME")]
    public List<Material> Costumes = new List<Material>();
   
    [Header("STICK")]
    public List<GameObject> Sticks = new List<GameObject>();
   
    [Header("HATS")]
    public TextMeshProUGUI hatText;
    public List<GameObject> Hats = new List<GameObject>();
    public List<Button> HatsButtons = new List<Button>();


    [Header("PANELS BUTTONS")]
    public List<Image> Panels = new List<Image>();


    
    void Start()
    {
        MemoryManager.SaveData_Int("ActiveHat", -1);
        HatsControl();
        print(hatIndex);
       
       Load();
       Save();
        Debug.Log(Application.persistentDataPath);
    }
    
    public void Save()
    {
        _itemsDatas[1].BuyItem = true;
        _itemsDatas.Add(new ItemsDatas());
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/ItemDatas.gd");
        bf.Serialize(file,_itemsDatas);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/ItemDatas.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ItemDatas.gd",FileMode.Open);
            _itemsDatas = (List<ItemsDatas>) bf.Deserialize(file);
            file.Close();
           
            Debug.Log(_itemsDatas[1].BuyItem);
            
        }
    }
    public void backForwardButton(bool bf)
    {
        if (bf == true)
        {


            if (hatIndex == -1)
            {

                hatIndex =0;

                 Hats[hatIndex].SetActive(true);

                 
            }

             else
             {
                 Hats[hatIndex].SetActive(false);
                 hatIndex++;
                 Hats[hatIndex].SetActive(true);


             }
             if (hatIndex == Hats.Count - 1)
                 HatsButtons[1].interactable = false;
             else
                 HatsButtons[1].interactable = true;
             if (hatIndex != -1)
                 HatsButtons[0].interactable = true;

        }



        else
        {
            
            if (hatIndex != -1)
            {

                Hats[hatIndex].SetActive(false);
                hatIndex--;

                if (hatIndex != -1)
                {
                    Hats[hatIndex].SetActive(true);
                    HatsButtons[0].interactable = true;

                }
                else
                {
                    HatsButtons[0].interactable = false;

                }

            }

            if(hatIndex==-1)
            {
                HatsButtons[0].interactable = false;

            }
            if (hatIndex != Hats.Count - 1)
                HatsButtons[1].interactable = true;
        }

    }

    void HatsControl()
    {
        if (MemoryManager.GetData_Int("ActiveHat") == -1)
        {
            foreach (var item in Hats)
            {
                item.SetActive(false);
            }

            hatIndex = -1;
            hatText.text = "No Hat";

        }
        else
        {
            hatIndex = MemoryManager.GetData_Int("ActiveHat");
            Hats[hatIndex].SetActive(true);
        }
        if (hatIndex == -1)
        {
            HatsButtons[0].interactable = false;
        }
    }
    public void PanelsButton(int panel)
    {
        foreach (var item in Panels)
        {
            item.gameObject.SetActive(false);

        }
        Panels[panel].gameObject.SetActive(true);
    }



}
