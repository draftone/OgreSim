using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using RV.Data;
using RV;
using RV.Party;
using GameDataEditor;

namespace RV.UI
{
    public class HeroPartyUIDisplay : AbstractUIDisplay
    {

        public bool is_director_select = false;
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridHeroPartyButton";
        }

        void OnEnable()
        {
            PlayerResourceManager.updateHeroPartyList += UpdateHeroPartyList;
            UpdateHeroPartyList();
        }

        void OnDisable()
        {
            PlayerResourceManager.updateHeroPartyList -= UpdateHeroPartyList;
        }

        public void UpdateHeroPartyList()
        {
            base.UIClear();
            GetAllInfo();
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override void ClickButtonAction(int index)
        {
            if (!is_director_select)
            {
                HeroPartyButton button = Buttons[index].GetComponent<HeroPartyButton>();
                button.ToggleSelect();
                button.SetButtonText();
            }
            else
            {
                UIManagerDirector party_manager_director = new UIManagerDirector(new HeroPartyManager());
                HeroPartyButton button = Buttons[index].GetComponent<HeroPartyButton>();
                button.ToggleSelect();
                party_manager_director.GetSelectOne();
                party_manager_director.SetSelectUI();
                party_manager_director.SelectAllClear();
            }
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }
        public override int GetListCount()
        {
            return PlayerResourceManager.g_hero_party.Count();
        }

        public override string GetGDEDataName(int index)
        {
            return PlayerResourceManager.g_hero_party[index].id.ToString();
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}