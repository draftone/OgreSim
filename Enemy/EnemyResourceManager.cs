using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.Party;
using RV.Unit;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using Assets.UltimateIsometricToolkit.Scripts.physics;
using Assets.UltimateIsometricToolkit.Scripts.Utils;

namespace RV
{
    public class EnemyResourceManager : RVSingleton<EnemyResourceManager>
    {
        public EnemyResourceManager() : base(false, false)
        {
        }

        public static List<EnemyUnit> g_enemy_list;
        public static List<EnemyParty> g_enemy_party;

        // Use this for initialization
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init()
        {
            g_enemy_list = new List<EnemyUnit>();
            g_enemy_party = new List<EnemyParty>();
        }
        public EnemyParty CreateParty()
        {
            EnemyPartyBuilder enemy_party_builder = new EnemyPartyBuilder();
            PartyDirector director = new PartyDirector(enemy_party_builder);
            director.Construct();
            EnemyParty party = enemy_party_builder.GetResult();
            g_enemy_party.Add(party);
            Debug.Log("create_party:" + party.id);
            // if (updateHeroPartyList != null)
            // {
            // updateHeroPartyList();
            // }
            return party;
        }

        public void DeleteParty(int id)
        {
            foreach (EnemyParty l_party in EnemyResourceManager.g_enemy_party)
            {
                if (id.ToString() == l_party.id.ToString())
                {
                    g_enemy_party.Remove(l_party);
                    break;
                }
            }
            // if (updateHeroPartyList != null)
            // {
            // updateHeroPartyList();
            // }
        }

        public EnemyParty GetParty(int id)
        {
            foreach (EnemyParty l_party in EnemyResourceManager.g_enemy_party)
            {
                if (id.ToString() == l_party.id.ToString())
                {
                    return l_party;
                }
            }
            return null;
        }
        public EnemyUnit AddEnemyUnit(string enemy_key)
        {
            EnemyUnitBuilder enemy_unit_builder = new EnemyUnitBuilder();
            UnitDirector director = new UnitDirector(enemy_unit_builder);
            director.Construct(enemy_key);
            EnemyUnit unit = enemy_unit_builder.GetResult();
            g_enemy_list.Add(unit);
            Debug.Log("add_enemy:" + unit.unit_name + ",hp:" + unit.max.hp);
            // if (updateHeroUnitList != null)
            // {
            // updateHeroUnitList();
            // }
            return unit;
        }

        public EnemyUnit AddRandomEnemyUnit()
        {
            EnemyUnitBuilder enemy_unit_builder = new EnemyUnitBuilder();
            UnitDirector director = new UnitDirector(enemy_unit_builder);
            director.RandomUnitConstruct();
            EnemyUnit unit = enemy_unit_builder.GetResult();
            g_enemy_list.Add(unit);
            Debug.Log("add_enemy:" + unit.unit_name + ",hp:" + unit.max.hp);
            // if (updateHeroUnitList != null)
            // {
            // updateHeroUnitList();
            // }
            return unit;
        }

        public void RemoveEnemyUnit(int id)
        {
            foreach (EnemyUnit l_unit in EnemyResourceManager.g_enemy_list)
            {
                if (id.ToString() == l_unit.id.ToString())
                {
                    g_enemy_list.Remove(l_unit);
                    break;
                }
            }
            // if (updateHeroUnitList != null)
            // {
            // updateHeroUnitList();
            // }
        }

        public IsoTransform enemy_prefab;
        public void SetFieldParty(int id)
        {
            //enemy_prefab = (IsoTransform)Resources.Load("Prefabs/Building/" + build_data.prefab_path, typeof(IsoTransform));
            enemy_prefab = (IsoTransform)Resources.Load("Prefabs/Unit/Monster", typeof(IsoTransform));
            var copy = Instantiate(enemy_prefab);
            copy.GetComponent<PartyControl>().enemy_party = GetParty(id);
            copy.Position = new Vector3(10.0f, 0.6f, 10.0f);
            copy.GetComponent<PartyControl>().DebugLogPartyInfo();
            //copy.name = build_data.name;
        }
    }
}