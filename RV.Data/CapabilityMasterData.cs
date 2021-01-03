using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public class CapabilityMasterData : AbstractMasterData<GDECapabilityData>
    {
        public Dictionary<string, CapabilityData> capability_dict;

        public class CapabilityData
        {
            private string capability_key;
            private bool valid;

            public int GetCapability(string key)
            {
                if (valid == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            public void SetCapability(GDECapabilityData gde_capa)
            {
                capability_key = gde_capa.Key;
                valid = gde_capa.enable;
            }

            public void EnableCapability(string key)
            {
                if (key != capability_key)
                {
                    Debug.LogWarning("Different key");
                    return;
                }
                valid = true;
            }

            public void DisableCapability(string key)
            {
                if (key != capability_key)
                {
                    Debug.LogWarning("Different key");
                    return;
                }
                valid = false;
            }
        }

        void Start()
        {
            capability_dict = new Dictionary<string, CapabilityData>();
            List<GDECapabilityData> list = GetList();
            foreach (var l_capa in list)
            {
                CapabilityData capa_data = new CapabilityData();
                capa_data.SetCapability(l_capa);
                capability_dict.Add(l_capa.Key, capa_data);
            }
        }

        public override List<GDECapabilityData> GetList()
        {
            GDEDataManager.Init("gde_data");
            list_data = GDEDataManager.GetAllItems<GDECapabilityData>();
            return list_data;
        }

        /// <summary>
        /// /// @param technicalName
        /// </summary>
        public override GDECapabilityData GetData(string technicalName)
        {
            GDEDataManager.Init("gde_data");
            GDECapabilityData capa_data = new GDECapabilityData(technicalName);
            Debug.Log("CapaData:" + capa_data.name);
            return capa_data;
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

        public override GDECapabilityData GetRandomData()
        {
            return list_data[UnityEngine.Random.Range(0, list_data.Count)];
        }
        public override string GetGDEIconPath(int index)
        {
            return null;
        }
    }
}