using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Building;
using RV.Data;

namespace RV.UI
{
    public class BuildingInfoUIDisplay : AbstractUIDisplay
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
            BuildingControl.instance.SetBuildingType(BuildingMasterData.instance.GetGDEDataKey(index));
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }

        public override int GetListCount()
        {
            return BuildingMasterData.instance.GetListCount();
        }

        public override string GetGDEDataName(int index)
        {
            return BuildingMasterData.instance.GetGDEDataName(index);
        }
        public override string GetIconPath(int index)
        {
            return BuildingMasterData.instance.GetGDEIconPath(index);
        }
    }
}