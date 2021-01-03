using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
using RV.Party;
using RV.Data;
using RV.Battle;
using RV.Map;
using UnityEngine.SceneManagement;

namespace RV.UI
{
    public class ReflectionUIManager : RVSingleton<ReflectionUIManager>
    {
        public ReflectionUIManager() : base(false, false)
        {

        }
        void Start()
        {
            //SetClickHandler();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SetClickHandler();
            SetUIWindows();
        }

        private Dictionary<string, UIWindow> dict_uiwindow = new Dictionary<string, UIWindow>();
        public bool is_ui_open;

        public void SetUIWindows()
        {
            GameObject[] obj_windows;
            obj_windows = GameObject.FindGameObjectsWithTag("UIWindow");
            foreach (GameObject obj in obj_windows)
            {
                dict_uiwindow.Add(obj.name, obj.GetComponent<UIWindow>());
                obj.GetComponent<UIWindow>().OnShow += SetUIOpen;
                obj.GetComponent<UIWindow>().OnHide += CheckUIOpen;
                Debug.Log(obj.name);
            }
        }

        public void SetUIOpen()
        {
            is_ui_open = true;
        }

        public void CheckUIOpen()
        {
            foreach (KeyValuePair<string, UIWindow> pair in dict_uiwindow)
            {
                if (pair.Value.isVisible)
                {
                    is_ui_open = true;
                    return;
                }
            }
            is_ui_open = false;
        }

        public void SetClickHandler()
        {
            Button[] buttonList = GameObject.FindObjectsOfType<Button>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            MethodInfo[] methodList = this.GetType().GetMethods(flags);

            // すべてのボタンにハンドラを登録するまで繰り返し
            foreach (Button curBtn in buttonList)
            {
                string searchMethodName = curBtn.name.ToUpper() + "_ONCLICK";
                // ボタンへイベントハンドラを登録する
                MethodInfo handlerMethod = null;
                foreach (MethodInfo curMethod in methodList)
                {
                    // ボタン名 + "_OnClick"の名前のメソッド以外はSkip
                    if (curMethod.Name.ToUpper() != searchMethodName)
                    {
                        continue;
                    }
                    // ボタンクリック時のハンドラを登録する
                    curBtn.onClick.AddListener(delegate
                                               { curMethod.Invoke(this, null); });
                    Debug.Log("クリックのイベントハンドラを登録しました name=" + curBtn.name);
                    break;
                }
            }
        }

        //! ボタンのイベントハンドラを削除する
        public void RemoveClickHandler()
        {
            Button[] buttonList = GameObject.FindObjectsOfType<Button>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            MethodInfo[] methodList = this.GetType().GetMethods(flags);

            // すべてのボタンのハンドラを削除するまで繰り返し
            foreach (Button curBtn in buttonList)
            {
                string searchMethodName = curBtn.name.ToUpper() + "_ONCLICK";
                // ボタンのイベントハンドラを削除する
                MethodInfo handlerMethod = null;
                foreach (MethodInfo curMethod in methodList)
                {
                    // ボタン名 + "_OnClick"の名前のメソッド以外はSkip
                    if (curMethod.Name.ToUpper() != searchMethodName)
                    {
                        continue;
                    }
                    // ボタンクリック時のハンドラを削除する
                    curBtn.onClick.RemoveAllListeners();
                    Debug.Log("クリックのイベントハンドラを削除しました name=" + curBtn.name);
                    break;
                }
            }
        }

        public void ShowUIWindow(string window_name)
        {
            if (!dict_uiwindow.ContainsKey(window_name))
            {
                Debug.LogError("No Contain key.");
            }
            dict_uiwindow[window_name].Show();
        }

        public void ToggleUIWindow(string window_name)
        {
            if (!dict_uiwindow.ContainsKey(window_name))
            {
                Debug.LogError("No Contain key.");
            }
            if (dict_uiwindow[window_name].isVisible)
            {
                dict_uiwindow[window_name].Hide();
            }
            else
            {
                dict_uiwindow[window_name].Show();
            }

        }

        public void HideUIWindow(string window_name)
        {
            if (!dict_uiwindow.ContainsKey(window_name))
            {
                Debug.LogError("No Contain key.");
            }
            dict_uiwindow[window_name].Hide();
        }

        private void CommonUIButtonFunction(string sound_id, string log)
        {
            SoundManager.instance.PlaySound(sound_id);
            Debug.Log(log);
        }

        public void CreateParty_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "CreateParty_ONCLICK()");
            HeroParty hero_party = PlayerResourceManager.instance.CreateParty();
            hero_party.DebugAddUnitToParty();
            PlayerResourceManager.instance.SetFieldParty(hero_party.id);
        }

        public void CreateEnemyParty_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "CreateEnemyParty_ONCLICK()");
            EnemyParty enemy_party = EnemyResourceManager.instance.CreateParty();
            enemy_party.DebugAddUnitToParty();
            EnemyResourceManager.instance.SetFieldParty(enemy_party.id);
        }

        public void AddUnitToParty_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "AddUnitToParty_ONCLICK()");
            PlayerResourceManager.instance.AddHeroUnit(UnitClassMasterData.instance.GetGDEDataKey(1));
        }

        public void SelectPartyMode_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "AddUnitToParty_ONCLICK()");
            //PartyManagerDirector party_manager_director = new PartyManagerDirector(new HeroPartyManager());
            //party_manager_director.GetSelectParty();
            //party_manager_director.GetUnitList();
            UIManagerDirector party_manager_director = new UIManagerDirector(new HeroPartyManager());
            party_manager_director.GetSelect();
            party_manager_director.GetSelectList();
        }

        public void ShowUnitListOnParty_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "ShowUnitListOnParty_ONCLICK()");
            UIManagerDirector party_manager_director = new UIManagerDirector(new HeroPartyManager());
            party_manager_director.GetSelectOne();
            party_manager_director.SetSelectUI();

            ShowUIWindow("HeroUnitListWindow");
            HideUIWindow("DebugHeroPartyWindow");
        }

        public void ShowBattleUI_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "ShowBattleUI_ONCLICK()");
            ShowUIWindow("DebugBattleTestWindow");
            // HeroPartyManager hero_party_manager = new HeroPartyManager();
            // UIManagerDirector party_manager_director = new UIManagerDirector(hero_party_manager);
            // party_manager_director.GetSelectOne();
            // party_manager_director.SetSelectPartyForUI();
        }

        public void DebugSetParty_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "DebugSetParty_ONCLICK()");
            BattleManagerDirector battle_manager_director = new BattleManagerDirector(new NormalBattleManager());
            EnemyParty enemy_party = EnemyResourceManager.instance.CreateParty();
            enemy_party.DebugAddUnitToParty();
            battle_manager_director.EncountEnemy(PlayerResourceManager.g_hero_party[0], enemy_party);
        }

        public void GenerateMap_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "MapGenerate_ONCLICK()");
            MapManager.instance.GenerateMap();
        }
        public void SellSelectItem_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "SellSelectItem_ONCLICK()");
            UIManagerDirector manager_director = new UIManagerDirector(new ShopManager());
            manager_director.GetSelect();
            manager_director.GetSelectList();
        }
        public void ShowBuildingUI_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "ShowBuildingUI_ONCLICK");
            ToggleUIWindow("BuildingWindow");
        }

        public void GameExitUI_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "GameExitUI_ONCLICK");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }
        public void ShowTechnologyUI_ONCLICK()
        {
            CommonUIButtonFunction("UI_Button_Click1", "ShowTechnologyUI_ONCLICK");
            ToggleUIWindow("TechnologyWindow");
        }
    }
}
