using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aleyna;
using UnityEngine.SceneManagement;

public class CostumeManager : MonoBehaviour
{
    [Header("-----COSTUME-----")]
    public List<Material> Costumes = new List<Material>();
    public List<Button> CostumeButtons = new List<Button>();
   // public Text texts[4];
    int costumeIndexx = -1;
    public Material defaultNinja;
    
    [Header("-----STICK-----")]
    public List<GameObject> Sticks = new List<GameObject>();
    public List<Button> StickButtons = new List<Button>();
     int stickIndex = -1;
    // public Text texts[5];
    [Header("-----HATS-----")]
   // public Text texts[6];
    public List<GameObject> Hats = new List<GameObject>();
    public List<Button> HatsButtons = new List<Button>();
    int hatIndex = -1;


    [Header("-----PANELS BUTTONS-----")]
    public List<Image> Panels = new List<Image>();
    public Button openButton;
    public int activePanel=-1;
    public Image buttonsPanel;
    public Image buyPanel;


    [Header("-----OTHERS-----")]
    public Text pointText;
    public List<ItemsDatas> _itemsDatas = new List<ItemsDatas>();
    DataManager dataManager = new DataManager();
    public List<Button> GeneralButtons = new List<Button>();
    public Text buyText;
    public GameObject charr;
    public GameObject ninja;
    SkinnedMeshRenderer nskinnedMeshRenderer;
    public List<AudioSource> audioSources = new List<AudioSource>();
    public List<LanguageDatasMainObject> languageDatasMainObjects = new List<LanguageDatasMainObject>(); 
     List<LanguageDatasMainObject> languageDatasMainObject2 = new List<LanguageDatasMainObject>();
    public List<Text> texts = new List<Text>();

    string hatTxt;
    string costumeTxt;
    string stickTxt;
    void Start()
    {
        nskinnedMeshRenderer = ninja.GetComponent<SkinnedMeshRenderer>();
        pointText.text = MemoryManager.GetData_Int("Point").ToString();


        CostumesControl(0, true);
        CostumesControl(1, true);
        CostumesControl(2, true);
        dataManager.Load();
        _itemsDatas = dataManager.TakeList();
       
        dataManager.LoadLang();
        languageDatasMainObject2 = dataManager.TakeListLang();
        languageDatasMainObjects.Add(languageDatasMainObject2[1]);
        checkLanguage();
        
        foreach (var item in audioSources)
        {
            item.volume=PlayerPrefs.GetFloat("MenuFx");
        }
        
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
                hatTxt = languageDatasMainObjects[0].languageDatas_TR[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_TR[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_TR[4].text;
                break;
            case "AZ":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_AZ[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                hatTxt = languageDatasMainObjects[0].languageDatas_AZ[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_AZ[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_AZ[4].text;
                break;
            case "EN":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_EN[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                hatTxt = languageDatasMainObjects[0].languageDatas_EN[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_EN[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_EN[4].text;
                break;
            case "KR":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_KR[i].text;
                    texts[i].fontStyle = FontStyle.Bold;
                }
                hatTxt = languageDatasMainObjects[0].languageDatas_KR[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_KR[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_KR[4].text;
                break;
            case "GR":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_GR[i].text;
                    texts[i].fontStyle = FontStyle.Normal;
                }
                hatTxt = languageDatasMainObjects[0].languageDatas_GR[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_GR[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_GR[4].text;
                break;
            case "JP":
                for (int i = 0; i < texts.Count; i++)
                {
                    texts[i].text = languageDatasMainObjects[0].languageDatas_JP[i].text;
                    texts[i].fontStyle = FontStyle.Bold;
                }
                hatTxt = languageDatasMainObjects[0].languageDatas_JP[6].text;
                stickTxt = languageDatasMainObjects[0].languageDatas_JP[5].text;
                costumeTxt = languageDatasMainObjects[0].languageDatas_JP[4].text;
                break;

        }
    }
    public void CostumesControl(int index, bool process=false)
    {
        switch (index)
        {
            case 0:
                #region
                if (MemoryManager.GetData_Int("ActiveHat") == -1)
                {
                    foreach (var item in Hats)
                    {
                        item.SetActive(false);
                    }
                  
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = false;
                    buyText.text = 0.ToString();
                    if (!process)
                    {
                        hatIndex = -1;
                        texts[6].text = hatTxt;
                    }

                   

                }
                else
                {
                    foreach (var item in Hats)
                    {
                        item.SetActive(false);
                    }
                  
                    hatIndex = MemoryManager.GetData_Int("ActiveHat");
                    Hats[hatIndex].SetActive(true);
                    texts[6].text = _itemsDatas[hatIndex].ItemName;
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    if (hatIndex == Hats.Count - 1)
                        HatsButtons[1].interactable = false;
                    
                    else
                        HatsButtons[1].interactable = true;

                }
                if (hatIndex == -1)
                {
                    HatsButtons[0].interactable = false;

                }
                #endregion
                break;
            case 1:
                #region
                if (MemoryManager.GetData_Int("ActiveStick") == -1)
                {
                    foreach (var item in Sticks)
                    {
                        item.SetActive(false);
                    }
                    print("çalýþtý");
                    GeneralButtons[1].interactable = false;

                    buyText.text = 0.ToString();
                    if (!process)
                    {
                        stickIndex = -1;
                        texts[5].text = stickTxt;

                    }


                }
                else
                {
                    foreach (var item in Sticks)
                    {
                        item.SetActive(false);
                    }
                    print("çalýþmadý"+stickIndex);
                    stickIndex = MemoryManager.GetData_Int("ActiveStick");
                    Sticks[stickIndex].SetActive(true);
                    texts[5].text = _itemsDatas[stickIndex + 6].ItemName;
                    GeneralButtons[1].interactable = false;
                    if (stickIndex == Sticks.Count - 1)
                        StickButtons[1].interactable = false;

                    else
                        StickButtons[1].interactable = true;

                }
                if (stickIndex == -1)
                {
                    StickButtons[0].interactable = false;

                }
                #endregion
                break;
            case 2:
                #region
                if (MemoryManager.GetData_Int("ActiveCostume") == -1)
                {

                    GeneralButtons[1].interactable = false;
                   
                    buyText.text = 0.ToString();
                    if (!process)
                    {
                        costumeIndexx = -1;
                        texts[4].text = costumeTxt;
                    }
                    else
                    {
                        Material[] mats = nskinnedMeshRenderer.materials;
                        mats[0] = defaultNinja;
                        nskinnedMeshRenderer.materials = mats;
                    }
                   


                }
                else
                {
                    costumeIndexx = MemoryManager.GetData_Int("ActiveCostume");
                    Material[] mats = nskinnedMeshRenderer.materials;
                    mats[0] = Costumes[costumeIndexx];
                    nskinnedMeshRenderer.materials = mats;
                    texts[4].text = _itemsDatas[costumeIndexx + 12].ItemName;
                    GeneralButtons[1].interactable = false;
                    if (costumeIndexx == Costumes.Count - 1)
                        CostumeButtons[1].interactable = false;

                    else
                        CostumeButtons[1].interactable = true;
                }
                if (costumeIndexx == -1)
                {
                    CostumeButtons[0].interactable = false;

                }
                #endregion
                break;
        }
    }

    private void Update()
    {

 
        if (!buttonsPanel.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") > 0)
                {
                    charr.transform.Rotate(new Vector3(0, charr.transform.rotation.y - 10, 0) * Time.deltaTime * 30);
                }
                if (Input.GetAxis("Mouse X") < 0)
                {
                    charr.transform.Rotate(new Vector3(0, charr.transform.rotation.y + 10, 0) * Time.deltaTime * 30);
                }
            }
        }

        
    }
    
    #region  BackForwardButtons

    public void backForwardButton(bool bf)
    {
        audioSources[0].Play();
        if (bf == true)
        {


            if (hatIndex == -1)
            {

                hatIndex = 0;

                Hats[hatIndex].SetActive(true);
                texts[6].text = _itemsDatas[hatIndex].ItemName;
                if (_itemsDatas[hatIndex].BuyItem == false)
                {
                    buyText.text = _itemsDatas[hatIndex].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point")< _itemsDatas[hatIndex].ItemPoint)
                       GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;


                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }

            }

            else
            {
                Hats[hatIndex].SetActive(false);
                hatIndex++;
                Hats[hatIndex].SetActive(true);
                texts[6].text = _itemsDatas[hatIndex].ItemName;
                if (_itemsDatas[hatIndex].BuyItem == false)
                {
                    buyText.text = _itemsDatas[hatIndex].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point") < _itemsDatas[hatIndex].ItemPoint)
                        GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;
                    
                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }



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
                    texts[6].text = _itemsDatas[hatIndex].ItemName;
                    if (_itemsDatas[hatIndex].BuyItem == false)
                    {
                        buyText.text = _itemsDatas[hatIndex].ItemPoint.ToString();
                        GeneralButtons[2].interactable = false;
                        if (MemoryManager.GetData_Int("Point") < _itemsDatas[hatIndex].ItemPoint)
                            GeneralButtons[1].interactable = false;
                        else
                            GeneralButtons[1].interactable = true;
                    }
                    else
                    {
                        buyText.text = 0.ToString();
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                    }


                }
                else
                {
                    HatsButtons[0].interactable = false;
                    texts[6].text = hatTxt;
                    buyText.text = 0.ToString();
                    GeneralButtons[2].interactable = true;




                }

            }
            else
            {
                HatsButtons[0].interactable = false;
                texts[6].text = hatTxt;
                buyText.text = 0.ToString(); 
                GeneralButtons[1].interactable = false;

            }

        
            if (hatIndex != Hats.Count - 1)
                HatsButtons[1].interactable = true;
        }

    } 
    public void backForwardButtonStick(bool bf)
    {
        audioSources[0].Play();
        if (bf == true)
        {


            if (stickIndex == -1)
            {


                stickIndex = 0;

                Sticks[stickIndex].SetActive(true);
                texts[5].text = _itemsDatas[stickIndex + 6].ItemName;
                if (_itemsDatas[stickIndex+6].BuyItem == false)
                {
                    buyText.text = _itemsDatas[stickIndex+6].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point") < _itemsDatas[stickIndex + 6].ItemPoint)
                        GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;

                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }



            }

            else
            {
                Sticks[stickIndex].SetActive(false);
                stickIndex++;
                Sticks[stickIndex].SetActive(true);
                texts[5].text = _itemsDatas[stickIndex + 6].ItemName;
                if (_itemsDatas[stickIndex+6].BuyItem == false)
                {
                    buyText.text = _itemsDatas[stickIndex+6].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point") < _itemsDatas[stickIndex + 6].ItemPoint)
                        GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;


                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }


            }
            if (stickIndex == Sticks.Count - 1)
                StickButtons[1].interactable = false;
            else
                StickButtons[1].interactable = true;
            if (stickIndex != -1)
                StickButtons[0].interactable = true;


        }



        else
        {

            if (stickIndex != -1)
            {

                Sticks[stickIndex].SetActive(false);
                stickIndex--;

                if (stickIndex != -1)
                {
                   

                    Sticks[stickIndex].SetActive(true);
                    StickButtons[0].interactable = true;
                    texts[5].text = _itemsDatas[stickIndex + 6].ItemName;
                    if (_itemsDatas[stickIndex+6].BuyItem == false)
                    {
                        buyText.text = _itemsDatas[stickIndex + 6].ItemPoint.ToString();
                        GeneralButtons[2].interactable = false;
                        if (MemoryManager.GetData_Int("Point") < _itemsDatas[stickIndex + 6].ItemPoint)
                            GeneralButtons[1].interactable = false;
                        else
                            GeneralButtons[1].interactable = true;

                    }
                    else
                    {
                        buyText.text = 0.ToString();
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                    }

                }
                else
                {
                    StickButtons[0].interactable = false;
                    texts[5].text = stickTxt;
                    buyText.text = 0.ToString();
                    GeneralButtons[2].interactable = true;



                }

            }
            else
            {
                StickButtons[0].interactable = false;
                texts[5].text = stickTxt;
                buyText.text = 0.ToString();
                GeneralButtons[1].interactable = false;

            }

            if (stickIndex != Sticks.Count - 1)
                StickButtons[1].interactable = true;
        }

    }
    public void backForwardButtonCostum(bool bf)
    {
        audioSources[0].Play();
        if (bf == true)
        {


            if (costumeIndexx == -1)
            {

                costumeIndexx = 0;
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[costumeIndexx];
                nskinnedMeshRenderer.materials = mats;
                texts[4].text = _itemsDatas[costumeIndexx + 12].ItemName;
                if (_itemsDatas[costumeIndexx+12].BuyItem == false)
                {
                    buyText.text = _itemsDatas[costumeIndexx + 12].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point") < _itemsDatas[costumeIndexx + 12].ItemPoint)
                        GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;

                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }



            }

            else
            {

                costumeIndexx++;
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[costumeIndexx];
                nskinnedMeshRenderer.materials = mats;
                texts[4].text = _itemsDatas[costumeIndexx + 12].ItemName;
                if (_itemsDatas[costumeIndexx+12].BuyItem == false)
                {
                    buyText.text = _itemsDatas[costumeIndexx + 12].ItemPoint.ToString();
                    GeneralButtons[2].interactable = false;
                    if (MemoryManager.GetData_Int("Point") < _itemsDatas[costumeIndexx + 12].ItemPoint)
                        GeneralButtons[1].interactable = false;
                    else
                        GeneralButtons[1].interactable = true;
                }
                else
                {
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;
                }



            }
            if (costumeIndexx == Sticks.Count - 1)
                CostumeButtons[1].interactable = false;
            else
                CostumeButtons[1].interactable = true;
            if (costumeIndexx != -1)
                CostumeButtons[0].interactable = true;

        }



        else
        {

            if (costumeIndexx != -1)
            {


                costumeIndexx--;

                if (costumeIndexx != -1)
                {
                    Material[] mats = nskinnedMeshRenderer.materials;
                    mats[0] = Costumes[costumeIndexx];
                    nskinnedMeshRenderer.materials = mats;
                    CostumeButtons[0].interactable = true;
                    texts[4].text = _itemsDatas[costumeIndexx + 12].ItemName;
                    if (_itemsDatas[costumeIndexx+12].BuyItem == false)
                    {
                        buyText.text = _itemsDatas[costumeIndexx + 12].ItemPoint.ToString();
                        GeneralButtons[2].interactable = false;
                        if (MemoryManager.GetData_Int("Point") < _itemsDatas[costumeIndexx + 12].ItemPoint)
                            GeneralButtons[1].interactable = false;
                        else
                            GeneralButtons[1].interactable = true;
                    }
                    else
                    {
                        buyText.text = 0.ToString();
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                    }

                }
                else
                {
                    Material[] mats = nskinnedMeshRenderer.materials;
                    mats[0] =defaultNinja; ;
                    nskinnedMeshRenderer.materials = mats;
                    CostumeButtons[0].interactable = false;
                    texts[4].text = costumeTxt;
                    buyText.text = 0.ToString(); 
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = true;



                }

            }
            else
            {
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] =defaultNinja; ;
                nskinnedMeshRenderer.materials = mats;
                CostumeButtons[0].interactable = false;
                texts[4].text = costumeTxt;
                buyText.text = 0.ToString();
                GeneralButtons[2].interactable = true;
            }

            if (costumeIndexx != Costumes.Count - 1)
                CostumeButtons[1].interactable = true;
        }

    }
    #endregion 

    public void PanelsButton(int panel)
    {
        CostumesControl(panel);
        activePanel = panel;
        Panels[panel].gameObject.SetActive(true);
        buttonsPanel.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        buyPanel.gameObject.SetActive(true);
        audioSources[0].Play();
    }
    public void OpenButtons()
    {

        buttonsPanel.gameObject.SetActive(true);
        openButton.gameObject.SetActive(false);
        Panels[activePanel].gameObject.SetActive(false);
        buyPanel.gameObject.SetActive(false);
        CostumesControl(activePanel,true);
        activePanel = -1;
        audioSources[0].Play();
    }
    public void BackMenu()
    {
        dataManager.Save(_itemsDatas);
        SceneManager.LoadScene(0);
        audioSources[0].Play();

    }
     public void Wear()
    {
        if (activePanel != -1)
        {
            switch (activePanel)
            {
                case 0:
                    wearresult("ActiveHat", hatIndex);
                    break;
                case 1:
                    wearresult("ActiveStick", stickIndex);

                    break;
                case 2:
                    wearresult("ActiveCostume", costumeIndexx);
                    break;

            }
        }
        
    }
    public void Buy()
    {
        if (activePanel != -1)
        {
            switch (activePanel)
            {
                case 0:
                    if (MemoryManager.GetData_Int("Point") >= _itemsDatas[hatIndex].ItemPoint)
                    {
                        buyResult(hatIndex);
                    }

                    break;
                case 1:
                    if (MemoryManager.GetData_Int("Point") >= _itemsDatas[stickIndex+6].ItemPoint)
                    {
                        int index = stickIndex + 6;
                        buyResult( index);
                    }

                    break;
                case 2:
                    if (MemoryManager.GetData_Int("Point") >= _itemsDatas[costumeIndexx + 12].ItemPoint)
                    {
                        int index = costumeIndexx + 12;
                        buyResult(index);
                    }
                    break;

            }
        }
    }
   
    void buyResult(int index)
    {
        _itemsDatas[index].BuyItem = true;
        GeneralButtons[1].interactable = false;
        GeneralButtons[2].interactable = true;
        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") - _itemsDatas[index].ItemPoint);
        buyText.text = 0.ToString();
        pointText.text = MemoryManager.GetData_Int("Point").ToString();
        audioSources[1].Play();


    }
    void wearresult(string key,int index)
    {
        MemoryManager.SaveData_Int(key, index);
        GeneralButtons[2].interactable = false;
        audioSources[2].Play();


    }


}


