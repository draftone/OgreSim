using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Unit;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class BuildingMasterData : AbstractMasterData<GDEBuildingData>
    {

        public class BuildingData
        {
            public BuildingData(string technicalName)
            {
                building_data = BuildingMasterData.instance.GetData(technicalName);
                unit_data = new UnitBase();
                unit_data.max = unit_data.SetStatus(building_data.hp, 0, 0, 0);
                unit_data.current = unit_data.SetStatus(building_data.hp, 0, 0, 0);
            }

            public UnitBase unit_data;
            public GDEBuildingData building_data;
        }

        void Start()
        {
            GetList();
        }

        public override List<GDEBuildingData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDEBuildingData>();
            return list_data;
        }

        /// <summary>
        /// /// @param technicalName
        /// </summary>
        public override GDEBuildingData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDEBuildingData building_data = new GDEBuildingData(technicalName);
            Debug.Log("BuildingData:" + building_data.name);
            return building_data;
        }

        public override int GetListCount()
        {
            return list_data.Count;
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override string GetGDEDataName(int index)
        {
            return list_data[index].name;
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override string GetGDEDataKey(int index)
        {
            return list_data[index].Key;
        }

        public override GDEBuildingData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return "icon/Building/" + list_data[index].ui_icon_path;
        }

    }
}