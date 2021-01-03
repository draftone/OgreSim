using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataEditor;

namespace RV
{
    public class MasterDataManager : RVSingleton<MasterDataManager>
    {
        public MasterDataManager() : base(false, false)
        {
        }

        public List<GDEBuildingData> all_building_data;
        public List<GDESoundData> all_sound_data;
        public List<GDEItemData> all_item_data;
        public List<GDEItemData> inventory_item_data;
        public List<GDEUnitClassData> unit_class_data;

        // Use this for initialization
        void Start()
        {
            GDEDataManager.Init("gde_data");
            all_building_data = GDEDataManager.GetAllItems<GDEBuildingData>();
            all_sound_data = GDEDataManager.GetAllItems<GDESoundData>();
            all_item_data = GDEDataManager.GetAllItems<GDEItemData>();
            inventory_item_data = GDEDataManager.GetAllItems<GDEItemData>();
            unit_class_data = GDEDataManager.GetAllItems<GDEUnitClassData>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public GDEBuildingData GetBuildingData(string TechnicalName)
        {
            GDEDataManager.Init("gde_data");
            GDEBuildingData building_data = new GDEBuildingData(TechnicalName);
            Debug.Log("BuildingData:" + building_data.name);
            return building_data;
        }

        public GDEUnitClassData GetUnitClassData(string TechnicalName)
        {
            GDEDataManager.Init("gde_data");
            Debug.Log("Tecname:" + TechnicalName);
            GDEUnitClassData data = new GDEUnitClassData(TechnicalName);
            Debug.Log("UnitClassData:" + data.class_name);
            return data;
        }

        public void GetInventoryList()
        {
            if (inventory_item_data != null)
            {
                inventory_item_data.Clear();
            }
            inventory_item_data = PlayerResourceManager.instance.GetInventoryList();
        }

        public int GetListCount(string data_type)
        {
            switch (data_type)
            {
                case "building":
                    return all_building_data.Count;
                case "sound":
                    return all_sound_data.Count;
                case "item":
                    return all_item_data.Count;
                case "inventory_item":
                    Debug.Log("inv_item_count:" + inventory_item_data.Count);
                    return inventory_item_data.Count;
            }
            return 0;
        }

        public string GetGDEDataName(string data_type, int index)
        {
            switch (data_type)
            {
                case "building":
                    return all_building_data[index].name;
                case "sound":
                    return all_sound_data[index].name;
                case "item":
                    return all_item_data[index].item_name;
                case "inventory_item":
                    return inventory_item_data[index].item_name;
            }
            return null;
        }
        public string GetGDEDataKey(string data_type, int index)
        {
            switch (data_type)
            {
                case "building":
                    return all_building_data[index].Key;
                case "sound":
                    return all_sound_data[index].Key;
                case "item":
                    return all_item_data[index].Key;
                case "inventory_item":
                    return inventory_item_data[index].Key;
            }
            return null;
        }

    }
}