using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class ItemMasterData : AbstractMasterData<GDEItemData>
    {
        void Start()
        {
            GetList();
        }


        public override List<GDEItemData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDEItemData>();
            return list_data;
        }

        /// <summary>
        /// @param technicalName
        /// </summary>
        public override GDEItemData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDEItemData item_data = new GDEItemData(technicalName);
            return item_data;
        }

        public override int GetListCount()
        {
            // TODO implement here
            return list_data.Count;
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override string GetGDEDataName(int index)
        {
            // TODO implement here
            return list_data[index].item_name;
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override string GetGDEDataKey(int index)
        {
            // TODO implement here
            return list_data[index].Key;
        }

        public override GDEItemData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return null;
        }
    }
}