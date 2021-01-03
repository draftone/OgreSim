using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Data;

namespace RV.UI
{
    public class DebugItemUIDisplay : AbstractUIDisplay
    {
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridButton";
        }

        void Start()
        {
            Init();
            GetAllInfo();
        }
        /// <summary>
        /// @param index
        /// </summary>
        public override void ClickButtonAction(int index)
        {
            //PlayerResourceManager.instance.AddItem(ItemMasterData.instance.GetGDEDataKey(index), 1);
            PlayerResourceManager.instance.BuyItem(ItemMasterData.instance.GetGDEDataKey(index), 1);
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }

        public override int GetListCount()
        {
            return ItemMasterData.instance.GetListCount();
        }

        public override string GetGDEDataName(int index)
        {
            return ItemMasterData.instance.GetGDEDataName(index);
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}