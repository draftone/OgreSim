using System.Collections;
using System.Collections.Generic;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using RV;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace RV.Map
{
    public enum ObjectType
    {
        MapTile,
        Building,
    }

    public class MapObject : MonoBehaviour
    {

        public IsoTransform iso_transform;
        public string prefab_path;

        void Awake()
        {
            iso_transform = GetComponent<IsoTransform>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Init()
        {
            //iso_transform.Size = GameDefineManager.instance.g_prefab_unit_size;
        }
    }
}