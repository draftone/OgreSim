using System.Collections;
using System.Collections.Generic;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using UnityEngine;

namespace RV.Map
{
    /// <summary>
    /// Generates procedual levels
    /// Level generator with ruffness, amplitude and seed value
    /// </summary>
    public class MapGenerator : MonoBehaviour
    {
        public Vector3 WorldSize = new Vector3(10, 8, 10);
        public int Seed = 1;
        public float Roughness = 1f;
        public float Amplitude = 1f;
        [SerializeField, HideInInspector] private GameObject _root;
        /// <summary>
        /// Datastructure to store the IsoObjects in
        /// </summary>
        [SerializeField]
        public GenericGridMap<IsoTransform> Map;

        //prefab to spawn
        public MapObject Prefab;

        private Vector3 prefab_size = new Vector3(1.0f, 0.6f, 1.0f);

        public void instantiate()
        {
            if (Map != null)
                Clear();
            if (_root == null)
                _root = new GameObject("Level");
            _root.tag = "Level";
            Map = new GenericGridMap<IsoTransform>(prefab_size, WorldSize);
            Map.applyFunctionToMap((x, y, z) => MapToTile(x, y, z));
            for (int i = 0; i < Map.tiles.Length; i++)
            {
                if (Map.map_objects[i] != null)
                    Map.map_objects[i].transform.parent = _root.transform;
                //if (Map.tiles[i] != null)
                //    Map.tiles[i].transform.parent = _root.transform;
            }
        }

        /// <summary>
        /// Wraps GenericGridMap<T>.clear() for the custom editor
        /// </summary>
        public void Clear()
        {
            Map.clear();
            Map = null;
            DestroyImmediate(_root);

        }

        /// <summary>
        /// Returns an instance of prefab or null at a given position (x,y,z)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public IsoTransform MapToTile(int x, int y, int z)
        {
            var vec = new Vector2(x, z) * Roughness + new Vector2(Seed, Seed);
            var height = Mathf.PerlinNoise(vec.x / WorldSize.x, vec.y / WorldSize.y);
            if (y <= height * Amplitude)
            {
                if (x >= Map.mapSize.x || y >= Map.mapSize.y || z >= Map.mapSize.z || x < 0 || y < 0 || z < 0)
                {
                    return null;
                }
                else
                {
                    //Map.tiles[(int)(x * Map.mapSize.y + y + z * Map.mapSize.x * Map.mapSize.y)] = Instantiate(Prefab);
                    Map.map_objects[(int)(x * Map.mapSize.y + y + z * Map.mapSize.x * Map.mapSize.y)] = Instantiate(Prefab);
                    //return Map.tiles[(int)(x * Map.mapSize.y + y + z * Map.mapSize.x * Map.mapSize.y)];
                    return Map.map_objects[(int)(x * Map.mapSize.y + y + z * Map.mapSize.x * Map.mapSize.y)].iso_transform;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
