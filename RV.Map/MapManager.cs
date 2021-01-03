using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using UnityEngine;

namespace RV.Map
{
    public class MapManager : RVSingleton<MapManager>
    {
        public MapManager() : base(false, false)
        {
        }

        public List<MapObject> map_object_list;
        private MapGenerator map_generator;

        void Start()
        {
            map_object_list = new List<MapObject>();
            map_generator = GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<MapGenerator>();
        }

        public void MapDown(IsoTransform isoTransform)
        {
            Destroy(isoTransform.gameObject);
        }
        public void MapUp(IsoTransform isoTransform)
        {
            Destroy(isoTransform.gameObject);
        }

        public void GenerateMap()
        {
            map_generator.instantiate();
            GetMapObjects();
        }

        public void GetMapObjects()
        {
            map_object_list.Clear();
            foreach (var map_obj in map_generator.Map.map_objects.Select((v, i) => new { v, i }))
            {
                if (map_obj.v == null)
                {
                    map_object_list.Add(null);
                }
                else
                {
                    map_object_list.Add(map_obj.v);
                }
            }
        }
    }
}