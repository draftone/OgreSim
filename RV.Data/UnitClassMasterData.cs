using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class UnitClassMasterData : AbstractMasterData<GDEUnitClassData>
    {

        void Start()
        {
            GetList();
        }

        public override List<GDEUnitClassData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDEUnitClassData>();
            return list_data;
        }

        /// <summary>
        /// @param technicalName
        /// </summary>
        public override GDEUnitClassData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDEUnitClassData data = new GDEUnitClassData(technicalName);
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
            return list_data[index].class_name;
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override string GetGDEDataKey(int index)
        {
            return list_data[index].Key;
        }

        public override GDEUnitClassData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return null;
        }
    }
}