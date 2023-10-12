using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Aleyna
{
    public class Library
    {
        static Vector3 trs = new Vector3(0, 0, .2f);

        public static void Multiplication(List<GameObject> Chars, int nmbr, Transform trsf, List<GameObject> bEffect)
        {
            int cycleCount = (GameManager.noInstantCharacters * nmbr) - GameManager.noInstantCharacters;
            int number = 0;
            foreach (var ai in Chars)
            {
                if (number < cycleCount)
                {
                    if (!ai.activeInHierarchy)
                    {
                        foreach (var item in bEffect)
                        {
                            if (!item.activeInHierarchy)
                            {

                                item.SetActive(true);
                                item.transform.position = trsf.position - trs;
                                item.GetComponent<ParticleSystem>().Play();
                                item.GetComponent<AudioSource>().Play();

                                break;
                            }
                        }
                        ai.transform.position = trsf.position - trs;
                        ai.SetActive(true);
                        number++;

                    }
                }
                else
                {
                    number = 0;
                    break;
                }

            }
            GameManager.noInstantCharacters *= nmbr;
        }
        public static void Addition(List<GameObject> Chars, int nmbr, Transform trsf, List<GameObject> bEffect)
        {
            int number2 = 0;
            foreach (var ai in Chars)
            {
                if (number2 < nmbr)
                {
                    if (!ai.activeInHierarchy)
                    {
                        foreach (var item in bEffect)
                        {
                            if (!item.activeInHierarchy)
                            {

                                item.SetActive(true);
                                item.transform.position = trsf.position - trs;
                                item.GetComponent<ParticleSystem>().Play();
                                item.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        ai.transform.position = trsf.position - trs;
                        ai.SetActive(true);
                        number2++;

                    }
                }
                else
                {
                    number2 = 0;
                    break;
                }

            }



            GameManager.noInstantCharacters += nmbr;
        }
        public static void Subtraction(List<GameObject> Chars, int nmbr, List<GameObject> eEffects)
        {
            if (GameManager.noInstantCharacters < nmbr)
            {
                foreach (var ai in Chars)
                {
                    foreach (var item in eEffects)
                    {
                        if (!item.activeInHierarchy)
                        {
                            Vector3 effectsPos = new Vector3(ai.transform.position.x, 1, ai.transform.position.z);
                            item.SetActive(true);
                            item.transform.position = effectsPos;
                            item.GetComponent<ParticleSystem>().Play();
                            item.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }

                    ai.transform.position = Vector3.zero;
                    ai.SetActive(false);
                }
                GameManager.noInstantCharacters = 1;
            }

            else
            {
                int number3 = 0;
                foreach (var ai in Chars)
                {
                    if (number3 != nmbr)
                    {
                        if (ai.activeInHierarchy)
                        {
                            foreach (var item in eEffects)
                            {
                                if (!item.activeInHierarchy)
                                {
                                    Vector3 effectsPos = new Vector3(ai.transform.position.x, 1, ai.transform.position.z);
                                    item.SetActive(true);
                                    item.transform.position = effectsPos;
                                    item.GetComponent<ParticleSystem>().Play();
                                    item.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }
                            ai.transform.position = Vector3.zero;
                            ai.SetActive(false);
                            number3++;

                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }

                }



                GameManager.noInstantCharacters -= nmbr;
            }
        }
        public static void Division(List<GameObject> Chars, int nmbr, List<GameObject> eEffects)
        {
            if (GameManager.noInstantCharacters <= nmbr)
            {
                foreach (var item in Chars)
                {
                    foreach (var item2 in eEffects)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 effectsPos = new Vector3(item.transform.position.x, 1, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = effectsPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;

                    item.SetActive(false);


                }
                GameManager.noInstantCharacters = 1;
            }
            else
            {
                int number4 = GameManager.noInstantCharacters / nmbr;
                int number5 = 0;
                foreach (var ai in Chars)
                {
                    if (number5 != number4)
                    {

                        foreach (var item2 in eEffects)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                Vector3 effectsPos = new Vector3(ai.transform.position.x, 1, ai.transform.position.z);
                                item2.SetActive(true);
                                item2.transform.position = effectsPos;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        if (ai.activeInHierarchy)
                        {
                            ai.transform.position = Vector3.zero;
                            ai.SetActive(false);
                            number5++;

                        }
                    }
                    else
                    {
                        number5 = 0;
                        break;
                    }
                }

                if (GameManager.noInstantCharacters % nmbr == 0)
                {
                    GameManager.noInstantCharacters /= nmbr;
                }
                else if (GameManager.noInstantCharacters % nmbr == 1)
                {
                    GameManager.noInstantCharacters /= nmbr;
                    GameManager.noInstantCharacters++;
                }
                else if (GameManager.noInstantCharacters % nmbr == 2)
                {
                    GameManager.noInstantCharacters /= nmbr;
                    GameManager.noInstantCharacters += 2;
                }

            }
        }
    }

    public class MemoryManager
    {
        public static void SaveData_Int(string intKey, int intValue)
        {
            PlayerPrefs.SetInt(intKey, intValue);
            PlayerPrefs.Save();
        }
        public static void SaveData_String(string stringKey, string stringValue)
        {
            PlayerPrefs.SetString(stringKey, stringValue);
            PlayerPrefs.Save();
        }
        public static void SaveData_Float(string floatKey, float floatValue)
        {
            PlayerPrefs.SetFloat(floatKey, floatValue);
            PlayerPrefs.Save();
        }

        public static int GetData_Int(string intKey)
        {
            return PlayerPrefs.GetInt(intKey);

        }
        public static float GetData_Float(string floatKey)
        {
            return PlayerPrefs.GetFloat(floatKey);

        }
        public static string GetData_String(string stringKey)
        {
            return PlayerPrefs.GetString(stringKey);

        }

        public static void KeyControl()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 5);
                PlayerPrefs.SetInt("Point", 0);
                PlayerPrefs.SetInt("ActiveHat", -1);
                PlayerPrefs.SetInt("ActiveStick", -1);
                PlayerPrefs.SetInt("ActiveCostume", -1);
                PlayerPrefs.SetFloat("MenuSound", .5f);
                PlayerPrefs.SetFloat("MenuFx", .5f);
                PlayerPrefs.SetFloat("GameSound", .5f);
                PlayerPrefs.SetString("Language", "EN");
                PlayerPrefs.SetInt("LanguageIndex", 0);


            }
        }


    }

    [Serializable]
    public class ItemsDatas
    {
        public string GroupName;
        public int ItemIndex;
        public string ItemName;
        public int ItemPoint;
        public bool BuyItem;

    }

    public class DataManager
    {
        List<ItemsDatas> _itemsDatas2;
        List<LanguageDatasMainObject> _itemsDatasLang2;
        public void Save(List<ItemsDatas> _itemsDatas)
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemDatas.gd");
            bf.Serialize(file, _itemsDatas);
            file.Close();
        }
        public void firstSave(List<ItemsDatas> _itemsDatas, List<LanguageDatasMainObject> langDatas)
        {
            if (!File.Exists(Application.persistentDataPath + "/ItemDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemDatas.gd");
                bf.Serialize(file, _itemsDatas);
                file.Close();
            }
            if (!File.Exists(Application.persistentDataPath + "/LanguageDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/LanguageDatas.gd");
                bf.Serialize(file, langDatas);
                file.Close();
            }

        }
 
        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemDatas.gd", FileMode.Open);
                _itemsDatas2 = (List<ItemsDatas>)bf.Deserialize(file);
                file.Close();

            }
        }
        public List<ItemsDatas> TakeList()
        {
            return _itemsDatas2;

        }
        public void LoadLang()
        {
            if (File.Exists(Application.persistentDataPath + "/LanguageDatas.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/LanguageDatas.gd", FileMode.Open);
                _itemsDatasLang2 = (List<LanguageDatasMainObject>)bf.Deserialize(file);
                file.Close();

            }
        }
        public List<LanguageDatasMainObject> TakeListLang()
        {
            return _itemsDatasLang2;

        }

    }
   
    [Serializable]
    public class LanguageDatasMainObject
    {
       
        public List<LanguageDatas_EN> languageDatas_EN = new List<LanguageDatas_EN>();
        public List<LanguageDatas_EN> languageDatas_TR = new List<LanguageDatas_EN>();
        public List<LanguageDatas_EN> languageDatas_AZ = new List<LanguageDatas_EN>();
        public List<LanguageDatas_EN> languageDatas_KR = new List<LanguageDatas_EN>();
        public List<LanguageDatas_EN> languageDatas_JP = new List<LanguageDatas_EN>();
        public List<LanguageDatas_EN> languageDatas_GR = new List<LanguageDatas_EN>();




    }
    [Serializable]
    public class LanguageDatas_EN
    {
        public string text;

    }
   
}

