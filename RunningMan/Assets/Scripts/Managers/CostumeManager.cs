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
    public int activePanel;
    public Image buttonsPanel;
    public Image buyPanel;


    [Header("-----OTHERS-----")]
    public Text pointText;
    public List<ItemsDatas> _itemsDatas = new List<ItemsDatas>();
    DataManager dataManager = new DataManager();
    public List<Button> GeneralButtons = new List<Button>();


    public GameObject charr;
    public GameObject ninja;
    SkinnedMeshRenderer nskinnedMeshRenderer;
    void Start()
    {
        nskinnedMeshRenderer = ninja.GetComponent<SkinnedMeshRenderer>();
        MemoryManager.SaveData_Int("ActiveHat", -1);
        MemoryManager.SaveData_Int("ActiveStick", -1);
        MemoryManager.SaveData_Int("ActiveCostume", -1);
        HatsControl();
        StickControl();
        CostumControl();
        //CostumeControl();
        //dataManager.Save(_itemsDatas);
       dataManager.Load();
        _itemsDatas = dataManager.TakeList();
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


            }

            else
            {
                
                costumeIndexx++;
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[costumeIndexx];
                nskinnedMeshRenderer.materials = mats;
                costumText.text = _itemsDatas[costumeIndexx + 12].ItemName;


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

                }
                else
                {
                    Material[] mats = nskinnedMeshRenderer.materials;
                    mats[0] = Costumes[6];
                    nskinnedMeshRenderer.materials = mats;
                    CostumeButtons[0].interactable = false;
                    costumText.text = "Ninja";

                }

            }
            else
            {
                Material[] mats = nskinnedMeshRenderer.materials;
                mats[0] = Costumes[6];
                nskinnedMeshRenderer.materials = mats;
                CostumeButtons[0].interactable = false;
                costumText.text = "Ninja";
            }

            if (costumeIndexx == -1)
            {
                CostumeButtons[0].interactable = false;

            }
            if (costumeIndexx != Sticks.Count - 1)
                CostumeButtons[1].interactable = true;
        }

    }
    void CostumControl()
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
    }


    
       public void backForwardButtonStick(bool bf)
       {
           if (bf == true)
           {


               if (stickIndex == -1)
               {

                    
                    stickIndex = 0;

                   Sticks[stickIndex].SetActive(true);
                  stickText.text = _itemsDatas[stickIndex+6].ItemName;


               }

               else
               {
                   Sticks[stickIndex].SetActive(false);
                   stickIndex++;
                   Sticks[stickIndex].SetActive(true);
                   stickText.text = _itemsDatas[stickIndex+6].ItemName;


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
                       stickText.text = _itemsDatas[stickIndex+6].ItemName;

                   }
                   else
                   {
                       StickButtons[0].interactable = false;
                       stickText.text = "No Stick";

                   }

               }
               else
               {
                   StickButtons[0].interactable = false;
                   stickText.text = "No Stick";
               }

               if (stickIndex == -1)
               {
                   StickButtons[0].interactable = false;

               }
               if (stickIndex != Sticks.Count - 1)
                   StickButtons[1].interactable = true;
           }

       }
       void StickControl()
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
           }
           if (stickIndex == -1)
           {
               StickButtons[0].interactable = false;
           }
       }


    public void backForwardButton(bool bf)
    {
        if (bf == true)
        {


            if (hatIndex == -1)
            {

                hatIndex = 0;

                Hats[hatIndex].SetActive(true);
                hatText.text = _itemsDatas[hatIndex].ItemName;


            }

            else
            {
                Hats[hatIndex].SetActive(false);
                hatIndex++;
                Hats[hatIndex].SetActive(true);
                hatText.text = _itemsDatas[hatIndex].ItemName;


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

                }
                else
                {
                    HatsButtons[0].interactable = false;
                    hatText.text = "No Hat";

                }

            }
            else
            {
                HatsButtons[0].interactable = false;
                hatText.text = "No Hat";
            }

            if (hatIndex == -1)
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
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }


}
