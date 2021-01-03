using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RV
{
    public class ConvertVector : RVSingleton<ConvertVector>
    {
        public ConvertVector() : base(false, false)
        {
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Vector2 Vec3ToIndexXZ(Vector3 vec)
        {
            Vector2 index_vec;
            index_vec.x = (int)vec.x;
            index_vec.y = (int)vec.z;
            //Debug.Log(index_vec);
            return index_vec;
        }

        public Vector2 Vec3ToIndexIsoXZ(Vector3 vec)
        {
            Vector2 index_vec;
            var tmp_x = (int)((vec.x + 0.5) / 1.0);
            var tmp_z = (int)((vec.z + 0.5) / 1.0);
            Debug.Log("Index x:" + tmp_x + " z:" + tmp_z);
            index_vec.x = tmp_x;
            index_vec.y = tmp_z;

            return index_vec;
        }

        public Vector3 IndexXZToVec2(int x, int y)
        {
            Vector3 vector3;
            vector3.x = (float)x;
            vector3.y = 0.0f;
            vector3.z = (float)y;
            return vector3;
        }
    }
}