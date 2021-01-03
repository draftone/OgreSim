using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataEditor;
using RV;
using RV.Data;
using RV.UI;

public abstract class AbstractBuildingBehavior : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (technical_name != null)
        {
            gde_building_data = BuildingMasterData.instance.GetData(technical_name);
            PlayerResourceManager.instance.Worker += gde_building_data.worker;
            PlayerResourceManager.instance.Food += gde_building_data.food;
        }

        PermanentEffect();
    }

    void OnDestroy()
    {
        CancelPermanentEffect();
        if (technical_name != null)
        {
            PlayerResourceManager.instance.Worker -= gde_building_data.worker;
            PlayerResourceManager.instance.Food -= gde_building_data.food;
        }
    }
    public string open_window_id;
    public string technical_name;

    public GDEBuildingData gde_building_data;

    public abstract void UpdateAction();
    public abstract void PermanentEffect();
    public abstract void CancelPermanentEffect();
    public abstract void EffectDay();

    public virtual void SelectAction()
    {

    }

    public virtual void ClickAction()
    {
        Debug.Log("building ui:" + open_window_id);
        ReflectionUIManager.instance.ShowUIWindow(open_window_id);
    }

}
