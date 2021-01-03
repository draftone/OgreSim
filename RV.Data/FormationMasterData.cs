using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class FormationMasterData : AbstractMasterData<GDEFormationData>
    {
        void Start()
        {
            GetList();
        }

        public override List<GDEFormationData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDEFormationData>();
            return list_data;
        }

        /// <summary>
        /// @param technicalName
        /// </summary>
        public override GDEFormationData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDEFormationData data = new GDEFormationData(technicalName);
            return data;
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

        public override GDEFormationData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return null;
        }
    }
}
