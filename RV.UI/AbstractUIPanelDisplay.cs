using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace RV.UI
{
    /// <summary>
    /// UI生成用Interface
    /// </summary>
    public abstract class AbstractUIPanelDisplay : RVMonoBehaviour
    {
        public GameObject panel;
        public List<GameObject> Panels;

        public bool isGenerateUI;
        private bool isInit = false;

        public string prefab_panel_path;
        void Start()
        {
            //Init();
        }

        public void Init()
        {
            if (prefab_panel_path == "")
            {
                Debug.LogWarning("error:prefab_panel_path null");
            }
            Debug.Log(prefab_panel_path);
            panel = (GameObject)Resources.Load(prefab_panel_path);
            Panels = new List<GameObject>();
            isGenerateUI = false;
            isInit = true;
            //GetAllInfo();
        }

        public void UIClear()
        {
            foreach (GameObject obj in Panels)
            {
                Destroy(obj);
            }
            if (Panels != null)
                Panels.Clear();
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

                    Panels.Add((GameObject)Instantiate(panel));
                    Panels[i].transform.SetParent(gameObject.transform, false);
                    Panels[i].GetComponentInChildren<Text>().text = GetGDEDataName(i);
                    int n = i;
                    //Buttons[i].GetComponent<Button>().onClick.AddListener(() => ClickButtonAction(n));
                }
                //isGenerateUI = true;
            }
            //ReloadSprite();
        }

        public abstract int GetListCount();

        public void OpenUI()
        {
            GetAllInfo();
        }

        public void CloseUI()
        {
			UIClear();
        }

#if false
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
#endif
        /// <summary>
        /// @param index
        /// </summary>
        public abstract void ClickButtonAction(int index);
        public abstract string GetGDEDataName(int index);

    }
}