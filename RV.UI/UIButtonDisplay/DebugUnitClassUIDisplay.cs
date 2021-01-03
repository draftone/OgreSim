using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Data;

namespace RV.UI
{
    public class DebugUnitClassUIDisplay : AbstractUIDisplay
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
            PlayerResourceManager.instance.AddHeroUnit(UnitClassMasterData.instance.GetGDEDataKey(index));
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }
        public override int GetListCount()
        {
            return UnitClassMasterData.instance.GetListCount();
        }

        public override string GetGDEDataName(int index)
        {
            return UnitClassMasterData.instance.GetGDEDataKey(index);
            //return UnitClassMasterData.instance.GetGDEDataName(index);
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}