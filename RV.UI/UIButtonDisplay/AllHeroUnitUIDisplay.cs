using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RV.Data;
using RV;
using GameDataEditor;

namespace RV.UI
{
    public class AllHeroUnitUIDisplay : AbstractUIDisplay
    {
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridHeroUnitButton";
        }

        void OnEnable()
        {
            PlayerResourceManager.updateHeroUnitList += UpdateAllHeroUnitList;
            UpdateAllHeroUnitList();
        }

        void OnDisable()
        {
            PlayerResourceManager.updateHeroUnitList -= UpdateAllHeroUnitList;
        }

        public virtual void UpdateAllHeroUnitList()
        {
            Debug.Log("Call UpdateAllHeroUnitList().");
            base.UIClear();
            GetAllInfo();
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override void ClickButtonAction(int index)
        {
            PlayerResourceManager.instance.RemoveHeroUnit(PlayerResourceManager.g_hero_list[index].id);
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }
        public override int GetListCount()
        {
            return PlayerResourceManager.g_hero_list.Count();
        }

        public override string GetGDEDataName(int index)
        {
            return PlayerResourceManager.g_hero_list[index].id.ToString();
        }

        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}