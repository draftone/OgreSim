using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using Assets.UltimateIsometricToolkit.Scripts.physics;
using Assets.UltimateIsometricToolkit.Scripts.Utils;
using Assets.UltimateIsometricToolkit.Scripts.Pathfinding;
using RV.Building;
using RV.Map;
using RV.UI;

namespace RV
{
    /// <summary>
    /// Cameraコンポーネントクラス
    /// </summary>
    public class CameraComponent : MonoBehaviour
    {
        public Camera _main_camera;
        private Vector3 camera_pos;
        public Image _info_image;
        public Text _info_text;
        // public GeneralStatus _status;
        // public EnergyBar _hp_bar;
        // public EnergyBar _stamina_bar;
        public GameObject _selectObject;
        static public string _select_object_name;
        static public GameObject _select_object;
        public IsoTransform building_prefab;
        public AstarAgent AstarAgent;

        // Use this for initialization
        void Start()
        {
            camera_pos = transform.localPosition;
        }

        // Update is called once per frame
        void Update()
        {
            Raycast();
        }

        private void Raycast()
        {
            if (ReflectionUIManager.instance.is_ui_open)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                //カメラ位置からマウス方向への光線
                var isoRay = Isometric.MouseToIsoRay();
                IsoRaycastHit isoRaycastHit;
                if (IsoPhysics.Raycast(isoRay, out isoRaycastHit))
                {
                    try
                    {
                        isoRaycastHit.IsoTransform.gameObject.GetComponent<AbstractBuildingBehavior>().ClickAction();
                    }
                    catch
                    {

                    }
                }
                if (IsoPhysics.Raycast(isoRay, out isoRaycastHit))
                {
                    Vector2 select_vec = ConvertVector.instance.Vec3ToIndexIsoXZ(isoRaycastHit.Point);
                    StartCoroutine(Blink(isoRaycastHit.IsoTransform.GetComponent<SpriteRenderer>(), Color.red));
                    BuildingControl.instance.Building(select_vec);
                }

                if (IsoPhysics.Raycast(isoRay, out isoRaycastHit))
                {
                    Debug.Log("Moving to " + isoRaycastHit.Point);
                    Debug.Log("Isotransform: " + isoRaycastHit.IsoTransform.Position);
                    AstarAgent.MoveTo(isoRaycastHit.Point);
                }

                //Destroy(isoRaycastHit.IsoTransform.gameObject);

                //MapManager.instance.MapDown(isoRaycastHit.IsoTransform);
            }
            if (Input.GetMouseButtonDown(1))
            {
                //カメラ位置からマウス方向への光線
                var isoRay = Isometric.MouseToIsoRay();
                IsoRaycastHit isoRaycastHit;
                if (IsoPhysics.Raycast(isoRay, out isoRaycastHit))
                {
                    Vector2 select_vec = ConvertVector.instance.Vec3ToIndexIsoXZ(isoRaycastHit.Point);
                    Destroy(isoRaycastHit.IsoTransform.gameObject);
                }
            }
        }

        private IEnumerator Blink(SpriteRenderer renderer, Color color, float duration = 0.01f)
        {
            float timePassed = 0;
            renderer.color = Color.white;
            while (timePassed < duration)
            {
                timePassed += Time.deltaTime;

                renderer.color = Color.Lerp(Color.white, color, timePassed / duration);
                yield return null;
            }
            renderer.color = Color.white;

        }

        private void Mouse0KeyDownAction(RaycastHit2D hit)
        {
            // switch (GameState.instance._gameStateFlag)
            // {
            //     case GameState.GameStateFlag.BuildingFlag:
            //         BuildingControl.instance.Building(hit.collider.gameObject.transform.localPosition);
            //         Debug.Log("Building");
            //         break;
            //     default:
            //         BuildingControl.instance.CancelBuilding();
            //         if(hit.collider.gameObject.tag == "MineTarget"){
            //             MapObjectProvider.instance.ToggleMineTarget(hit.collider.gameObject.transform.localPosition);
            //         }
            //         break;
            // }
        }

        private void Mouse1KeyDownAction(RaycastHit2D hit)
        {
            // switch (GameState.instance._gameStateFlag)
            // {
            //     case GameState.GameStateFlag.BuildingFlag:
            //         BuildingControl.instance.CancelBuilding();
            //         break;
            //     default:
            //         BuildingControl.instance.CancelBuilding();
            //         BuildingControl.instance.DestroyBuilding(hit.collider.gameObject);
            //         break;
            // }
        }

        private void RaycastAction(GameObject hitobj)
        {
            GameObject game_obj = hitobj;
            // ObjectBase _object_base = game_obj.GetComponent<ObjectBase>();
            // if (_object_base == null)
            // {
            //     if (_selectObject != null)
            //     {
            //         _selectObject.GetComponent<ObjectBase>().isRaycollider = false;
            //     }
            // }
            // else
            // {
            //     if (_selectObject == null)
            //     {
            //         _selectObject = hitobj;
            //     }
            //     if (_selectObject.GetComponent<ObjectBase>() != null)
            //     {
            //         _selectObject.GetComponent<ObjectBase>().isRaycollider = false;
            //         _object_base.isRaycollider = true;
            //         _selectObject = game_obj;
            //     }
            // }

            // {
            //     _status = game_obj.GetComponent<GeneralStatus>();
            //     if (_status != null)
            //     {
            //         ShowUIInfo();
            //     }
            //     else
            //     {
            //         //_info_image.enabled = false;
            //         _info_text.enabled = false;
            //     }
            //     // game_obj.GetComponent<Renderer>().material.color = color;
            // }
        }

        public void ShowUIInfo()
        {
            // _hp_bar.valueMax = 100;
            // _hp_bar.valueMin = 0;
            // _hp_bar.valueCurrent = _status._hp;
            // _stamina_bar.valueMax = 100;
            // _stamina_bar.valueMin = 0;
            // _stamina_bar.valueCurrent = _status._stamina;

            // _info_image.enabled = true;
            // _info_text.enabled = true;
            // _info_text.text = "hp:" + _status._hp + "\n"
            // + "stamina:" + _status._stamina;
        }

    }
}