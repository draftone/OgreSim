using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using Assets.UltimateIsometricToolkit.Scripts.physics;
using Assets.UltimateIsometricToolkit.Scripts.Utils;
using RV.Data;
using GameDataEditor;

namespace RV.Building
{
    public class BuildingControl : RVSingleton<BuildingControl>
    {
        public BuildingControl() : base(false, false)
        {
        }

        public string _building_id;
        public IsoTransform building_prefab;
        public GameObject building_prefab_obj;

        public void Building(Vector2 vector)
        {
            if (_building_id == "")
            {
                Debug.Log("Not Set building_id");
            }
            else
            {
                SetBuildingObject(vector, _building_id);
            }
        }

        public bool CheckResourceBuilding(string TechnicalName)
        {
            GDEBuildingData build_data = BuildingMasterData.instance.GetData(TechnicalName);
            if (PlayerResourceManager.instance.Gold < build_data.building_cost)
            {
                return false;
            }

            var material_str = build_data.material.Split(',');
            if (material_str[0] == "None")
            {
                return true;
            }
            foreach (var l_material in material_str)
            {
                var value = l_material.Split(':');
                Debug.Log("build resource value[0]:" + value[0] + " value[1]" + value[1]);
                if (PlayerResourceManager.g_inventory[value[0]] < int.Parse(value[1]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool UseResourceBuilding(string TechnicalName)
        {
            GDEBuildingData build_data = BuildingMasterData.instance.GetData(TechnicalName);
            var material_str = build_data.material.Split(',');
            if (material_str[0] == "None")
            {
                return PlayerResourceManager.instance.UseGold(build_data.building_cost);
            }

            PlayerResourceManager.instance.UseGold(build_data.building_cost);

            foreach (var l_material in material_str)
            {
                var value = l_material.Split(':');
                if (PlayerResourceManager.instance.UseItem(value[0], int.Parse(value[1])) != 0)
                {
                    Debug.LogError("Use Failure");
                    return false;
                }
            }
            return true;
        }

        public void CancelBuilding()
        {
            _building_id = "";
        }

#if false
    public void DestroyBuilding(GameObject obj)
    {
        MapObjectProvider.instance.DestroyMapObject(obj, false);
        PathfindingUtility.instance.PathfindingUpdate(obj);
    }

#endif
        private void SetBuildingObject(Vector2 vector2, string TechnicalName)
        {
            GDEBuildingData build_data = BuildingMasterData.instance.GetData(TechnicalName);
            if (!CheckResourceBuilding(TechnicalName))
            {
                return;
            }
            UseResourceBuilding(TechnicalName);
            building_prefab = (IsoTransform)Resources.Load("Prefabs/Building/" + build_data.prefab_path, typeof(IsoTransform));
            Debug.Log(build_data.prefab_path);
            var copy = Instantiate(building_prefab);
            copy.Position = new Vector3(vector2.x, 0.6f, vector2.y);
            copy.name = build_data.name;

            Debug.Log("Building");
            _building_id = "";
        }

        public void SetBuildingType(string buildingID)
        {
            _building_id = buildingID;
        }
    }
}