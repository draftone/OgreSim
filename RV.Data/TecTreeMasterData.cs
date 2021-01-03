using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class TecTreeMasterData : AbstractMasterData<GDETecTreeData>
    {

        void Start()
        {
            GetList();
        }

        public override List<GDETecTreeData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDETecTreeData>();
            return list_data;
        }

        /// <summary>
        /// /// @param technicalName
        /// </summary>
        public override GDETecTreeData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDETecTreeData tectree_data = new GDETecTreeData(technicalName);
            Debug.Log("TecTreeData:" + tectree_data.name);
            return tectree_data;
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

        public override GDETecTreeData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return null;
        }
    }
}
