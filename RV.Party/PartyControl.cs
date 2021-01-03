using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.Party;
using RV.Unit;
using RV.UI;
using RV;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using Assets.UltimateIsometricToolkit.Scripts.physics;
using Assets.UltimateIsometricToolkit.Scripts.Utils;
using Assets.UltimateIsometricToolkit.Scripts.Pathfinding;

public class PartyControl : MonoBehaviour
{

    public HeroParty hero_party;
    public EnemyParty enemy_party;

    public int move_type;

    public AstarAgent AstarAgent;
    public CameraComponent Camera;

    // Use this for initialization
    void Start()
    {
        AstarAgent = GetComponent<AstarAgent>();
        UIManagerDirector.setSelectUI += CheckSelect;
        UIManagerDirector.selectClear += CheckSelect;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckSelect()
    {
        if (hero_party != null && hero_party.is_selected)
        {
            SetAstarAgent();
        }
    }

    public void SetAstarAgent()
    {
        AstarAgent.Graph = GameObject.FindGameObjectWithTag("GridGraph").GetComponent<GridGraph>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraComponent>();
        Camera.AstarAgent = AstarAgent;
    }

    public void DebugLogPartyInfo()
    {
        if (hero_party != null)
        {
            Debug.Log("hero_party_id:" + hero_party.id);
            foreach (HeroUnit unit in hero_party.unit_list)
            {
                Debug.Log("hero_party_unit:" + unit.unit_name);
            }
        }


        if (enemy_party != null)
        {
            Debug.Log("enemy_party_id:" + enemy_party.id);
            foreach (EnemyUnit unit in enemy_party.unit_list)
            {
                Debug.Log("enemy_party_unit:" + unit.unit_name);
            }
        }

    }
}
