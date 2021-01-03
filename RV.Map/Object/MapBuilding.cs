using System.Collections;
using System.Collections.Generic;
using RV.Data;
using UnityEngine;

namespace RV.Map
{

    public class MapBuilding : MapObject
    {

        public string key;
		public BuildingMasterData.BuildingData building_data;
        // Use this for initialization
        void Start()
        {
			key = gameObject.name.Replace(" ","_");
			building_data = new BuildingMasterData.BuildingData(key);
			Debug.Log("building_data:" + building_data.unit_data.max.hp);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}