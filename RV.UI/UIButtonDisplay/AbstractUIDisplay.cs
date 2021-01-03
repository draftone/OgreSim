using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;

namespace RV.UI
{
    /// <summary>
    /// UI生成用Interface
    /// </summary>
    public abstract class AbstractUIDisplay : RVMonoBehaviour
    {
        public GameObject button;
        public List<GameObject> Buttons;

        public bool isGenerateUI;
        private bool isInit = false;

        public string prefab_button_path;
        void Start()
        {
            //Init();
        }

        public void Init()
        {
            if (prefab_button_path == "")
            {
                Debug.LogWarning("error:prefab_button_path null");
            }
            Debug.Log(prefab_button_path);
            button = (GameObject)Resources.Load(prefab_button_path);
            Buttons = new List<GameObject>();
            isGenerateUI = false;
            isInit = true;
            //GetAllInfo();
        }

        public void UIClear()
        {
            foreach (GameObject obj in Buttons)
            {
                Destroy(obj);
            }
            if (Buttons != null)
                Buttons.Clear();
        }

        public void GetAllInfo()
        {
            if (!isGenerateUI)
            {
                //int index = 0;
                int list_count = GetListCount();
                for (int i = 0; i < list_count; i++)
                {

                    if (isInit == false)
                    {
                        Debug.Log("Init()");
                        Init();
                    }

                    Buttons.Add((GameObject)Instantiate(button));
                    Buttons[i].transform.SetParent(gameObject.transform, false);
                    //Buttons[i].GetComponentInChildren<Text>().text = allData[i].name;
                    Buttons[i].GetComponentInChildren<Text>().text = GetGDEDataName(i);
                    //MasterDataManager.instance.GetGDEDataName(data_type, i);
                    string icon_path = GetIconPath(i);
                    if (icon_path == "stub" || icon_path == null)
                    {

                    }
                    else
                    {
                        Buttons[i].GetComponent<Button>().image.sprite = Resources.Load<Sprite>(icon_path);
                    }

                    //string dbg_path = allBuildings[i].Template.RV_Prefab_Properties.Unity_icon_root_path + "Stone Wall"; // + _building_db.Rows[i]._NAME;
                    //string icon_path = allBuildings[i].Template.RV_Prefab_Properties.Unity_icon_root_path + allBuildings[i].DisplayName;
                    //Debug.Log(icon_path);
                    //if (allBuildings[i].Template.RV_Debug_Properties.isDebug == true)
                    //{
                    //buildingButtons[i].GetComponent<MaterialButton>().backgroundSprite = Resources.Load<Sprite>(dbg_path);
                    //}
                    //else
                    //{
                    //buildingButtons[i].GetComponent<MaterialButton>().backgroundSprite = Resources.Load<Sprite>(icon_path);
                    //}
                    int n = i;
                    Buttons[i].GetComponent<Button>().onClick.AddListener(() => ClickButtonAction(n));
                }
                //isGenerateUI = true;
            }
            //ReloadSprite();
        }

        public abstract int GetListCount();

        public void DestroyButton()
        {
            // TODO implement here
            GameObject[] buttons;
            buttons = GameObject.FindGameObjectsWithTag("EmployeeInfoButton");
            foreach (GameObject button in buttons)
            {
                Destroy(button);
            }
        }

        /// <summary>
        /// @param index
        /// </summary>
        public abstract void ClickButtonAction(int index);
        public abstract string GetGDEDataName(int index);
        public abstract string GetIconPath(int index);

    }
}