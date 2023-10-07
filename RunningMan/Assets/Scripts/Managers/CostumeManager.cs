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
    public Text costumText;
    int costumeIndexx = -1;

    [Header("-----STICK-----")]
    public List<GameObject> Sticks = new List<GameObject>();
    public List<Button> StickButtons = new List<Button>();
    public Text stickText;
    int stickIndex = -1;

    [Header("-----HATS-----")]
    public Text hatText;
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
    void Start()
    {
        #region 
        nskinnedMeshRenderer = ninja.GetComponent<SkinnedMeshRenderer>();
        MemoryManager.SaveData_Int("ActiveHat", -1);
        MemoryManager.SaveData_Int("ActiveStick", -1);
        MemoryManager.SaveData_Int("ActiveCostume", -1);
       // MemoryManager.SaveData_Int("Point", 500);
        pointText.text = MemoryManager.GetData_Int("Point").ToString();
        #endregion
        //CostumeControl();
        //dataManager.Save(_itemsDatas);
        //HatsControl();
        dataManager.Load();
        _itemsDatas = dataManager.TakeList();
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
                        hatText.text = "No Hat";
                    }

                   

                }
                else
                {
                    hatIndex = MemoryManager.GetData_Int("ActiveHat");
                    Hats[hatIndex].SetActive(true);
                    hatText.text = _itemsDatas[hatIndex].ItemName;
                    if (_itemsDatas[hatIndex].BuyItem == false)
                        buyText.text = _itemsDatas[hatIndex].ItemPoint.ToString(); 
                    else
                        buyText.text = 0.ToString();

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
                    GeneralButtons[1].interactable = false;
                    GeneralButtons[2].interactable = false;
                    buyText.text = 0.ToString();
                    if (!process)
                    {
                        stickIndex = -1;
                        stickText.text = "No Stick";

                    }


                }
                else
                {
                    stickIndex = MemoryManager.GetData_Int("ActiveStick");
                    Sticks[stickIndex].SetActive(true);
                    stickText.text = _itemsDatas[stickIndex + 6].ItemName;
                    if (_itemsDatas[stickIndex + 6].BuyItem == false)
                        buyText.text = _itemsDatas[stickIndex + 6].ItemPoint.ToString();
                    else
                        buyText.text = 0.ToString();

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
                    GeneralButtons[2].interactable = false;
                    buyText.text = 0.ToString();
                    if (!process)
                    {
                        costumeIndexx = -1;
                        costumText.text = "Ninja";
                    }
                    else
                    {
                        Material[] mats = nskinnedMeshRenderer.materials;
                        mats[0] = Costumes[6];
                        nskinnedMeshRenderer.materials = mats;
                    }
                   


                }
                else
                {
                    costumeIndexx = MemoryManager.GetData_Int("ActiveCostume");
                    Material[] mats = nskinnedMeshRenderer.materials;
                    mats[0] = Costumes[costumeIndexx];
                    nskinnedMeshRenderer.materials = mats;
                    if (_itemsDatas[stickIndex + 6].BuyItem == false)
                        buyText.text = _itemsDatas[stickIndex + 6].ItemPoint.ToString();
                    else
                        buyText.text = 0.ToString();

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

        print(costumeIndexx);
    }
    
    #region  
    public void backForwardButton(bool bf)
    {
        if (bf == true)
        {


            if (hatIndex == -1)
            {

                hatIndex = 0;

                Hats[hatIndex].SetActive(true);
                hatText.text = _itemsDatas[hatIndex].ItemName;
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
                hatText.text = _itemsDatas[hatIndex].ItemName;
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
                    hatText.text = _itemsDatas[hatIndex].ItemName;
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
                    hatText.text = "No Hat";
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;




                }

            }
            else
            {
                HatsButtons[0].interactable = false;
                hatText.text = "No Hat";
                buyText.text = 0.ToString(); 
                GeneralButtons[1].interactable = false;

            }

            if (hatIndex == -1)
            {
                HatsButtons[0].interactable = false;

            }
            if (hatIndex != Hats.Count - 1)
                HatsButtons[1].interactable = true;
        }

    } 
    public void backForwardButtonStick(bool bf)
    {
        if (bf == true)
        {


            if (stickIndex == -1)
            {


                stickIndex = 0;

                Sticks[stickIndex].SetActive(true);
                stickText.text = _itemsDatas[stickIndex + 6].ItemName;
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
                stickText.text = _itemsDatas[stickIndex + 6].ItemName;
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
                    stickText.text = _itemsDatas[stickIndex + 6].ItemName;
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
                    stickText.text = "No Stick";
                    buyText.text = 0.ToString();
                    GeneralButtons[1].interactable = false;



                }

            }
            else
            {
                StickButtons[0].interactable = false;
                stickText.text = "No Stick";
                buyText.text = 0.ToString();
                GeneralButtons[1].interactable = false;

            }

            if (stickIndex == -1)
            {
                StickButtons[0].interactable = false;

            }
            if (stickIndex != Sticks.Count - 1)
                StickButtons[1].interactable = true;
        }

    }
    public void backForwardButtonCostum(bool bf)
    {
        if (bf == true)
        {


            if (costumeIndexx == -1)
            {

                costumeIndexx = 0;
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[costumeIndexx];
                nskinnedMeshRenderer.materials = mats;
                costumText.text = _itemsDatas[costumeIndexx + 12].ItemName;
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
                costumText.text = _itemsDatas[costumeIndexx + 12].ItemName;
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
                    costumText.text = _itemsDatas[costumeIndexx + 12].ItemName;
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
                    mats[0] = Costumes[6];
                    nskinnedMeshRenderer.materials = mats;
                    CostumeButtons[0].interactable = false;
                    costumText.text = "Ninja";
                    buyText.text = 0.ToString(); 
                    GeneralButtons[1].interactable = false;



                }

            }
            else
            {
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[6];
                nskinnedMeshRenderer.materials = mats;
                CostumeButtons[0].interactable = false;
                costumText.text = "Ninja";
                buyText.text = 0.ToString();
                GeneralButtons[1].interactable = false;
            }

            if (costumeIndexx == -1)
            {
                CostumeButtons[0].interactable = false;

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
    }
    public void OpenButtons()
    {

        buttonsPanel.gameObject.SetActive(true);
        openButton.gameObject.SetActive(false);
        Panels[activePanel].gameObject.SetActive(false);
        buyPanel.gameObject.SetActive(false);
        CostumesControl(activePanel,true);
        activePanel = -1;
        
    }
    public void BackMenu()
    {
        dataManager.Save(_itemsDatas);
        SceneManager.LoadScene(0);
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
                        _itemsDatas[hatIndex].BuyItem = true;
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") - _itemsDatas[hatIndex].ItemPoint);
                        buyText.text = 0.ToString();
                        pointText.text = MemoryManager.GetData_Int("Point").ToString();
                    }

                    break;
                case 1:
                    if (MemoryManager.GetData_Int("Point") >= _itemsDatas[stickIndex+6].ItemPoint)
                    {
                        _itemsDatas[stickIndex + 6].BuyItem = true;
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                        buyText.text = 0.ToString();
                        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") - _itemsDatas[stickIndex + 6].ItemPoint);
                        pointText.text = MemoryManager.GetData_Int("Point").ToString();
                    }

                    break;
                case 2:
                    if (MemoryManager.GetData_Int("Point") >= _itemsDatas[costumeIndexx + 12].ItemPoint)
                    {
                        _itemsDatas[costumeIndexx + 12].BuyItem = true;
                        GeneralButtons[1].interactable = false;
                        GeneralButtons[2].interactable = true;
                        buyText.text = 0.ToString();
                        MemoryManager.SaveData_Int("Point", MemoryManager.GetData_Int("Point") - _itemsDatas[costumeIndexx + 12].ItemPoint);
                        pointText.text = MemoryManager.GetData_Int("Point").ToString();
                    }
                    break;

            }
        }
    }

    public void Wear()
    {

    }
}
/* void StickControl()
    {
        if (MemoryManager.GetData_Int("ActiveStick") == -1)
        {
            foreach (var item in Sticks)
            {
                item.SetActive(false);
            }

            stickIndex = -1;
            stickText.text = "No Stick";
            

        }
        else
        {
            stickIndex = MemoryManager.GetData_Int("ActiveStick");
            Sticks[stickIndex].SetActive(true);
            stickText.text = _itemsDatas[stickIndex + 6].ItemName;
            
        }
        if (stickIndex == -1)
        {
            StickButtons[0].interactable = false;
            
        }
    }*/
/* void HatsControl()
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
           hatText.text = _itemsDatas[hatIndex].ItemName;

       }
       if (hatIndex == -1)
       {
           HatsButtons[0].interactable = false;

       }
   }*/
/* void CostumControl()
  {
      if (MemoryManager.GetData_Int("ActiveCostume") == -1)
      {
          Material[] mats = nskinnedMeshRenderer.materials;
          mats[0] = Costumes[6];
          nskinnedMeshRenderer.materials = mats;

          costumeIndexx = -1;
          costumText.text = "Ninja";


      }
      else
      {
          costumeIndexx = MemoryManager.GetData_Int("ActiveCostume");
          Material[] mats = nskinnedMeshRenderer.materials;
          mats[0] = Costumes[costumeIndexx];
          nskinnedMeshRenderer.materials = mats;

      }
      if (costumeIndexx == -1)
      {
          CostumeButtons[0].interactable = false;

      }
  }*/

