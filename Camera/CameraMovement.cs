using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RV
{
    public class CameraMovement : MonoBehaviour
    {

        private Vector3 m_pos;
        public GameObject _target;
        public float _speed = 1.0f;

        // Use this for initialization
        void Start()
        {
            _target = GameObject.Find("PC2DPanTarget");
            m_pos = _target.transform.localPosition; //形状位置を保持
                                                     //main_camera = GameObject.FindGameObjectWithTag ("MainCamera");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //transform.localPosition = m_pos; //形状位置を更新
            m_pos.x += Input.GetAxis("Horizontal") * _speed;
            m_pos.y += Input.GetAxis("Vertical") * _speed;
            _target.transform.localPosition = m_pos;
        }

    }
}