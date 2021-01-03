using System;
using System.Collections;
using System.Collections.Generic;
using RV.Unit;
using RV.Party;
using UnityEngine;

namespace RV.Battle
{
    public class NormalBattleManager : AbstractBattleManager
    {
        private GameObject battle_sim_prefab = (GameObject)Resources.Load("Prefabs/Scripts/BattleSimulator");
        private GameObject battle_sim;
        private List<UnitBase> unit_list;

        private List<GameObject> battle_sim_list;

        void Start()
        {
            battle_sim_list = new List<GameObject>();
        }

        void Update()
        {

        }

        public override void Action()
        {

        }
        public override void SetPlayerParty(HeroParty party)
        {
            player_party = party;
        }

        public override void SetEnemyParty(EnemyParty party)
        {
            enemy_party = party;
        }
        public override void BattleStart()
        {
            Debug.Log("hero_party");
            if (unit_list == null)
            {
                unit_list = new List<UnitBase>();
            }

            unit_list.Clear();

            foreach (HeroUnit l_hero in player_party.unit_list)
            {
                unit_list.Add(l_hero);
                Debug.Log("battle_hero_unit:" + l_hero.unit_name);
            }
            foreach (EnemyUnit l_enemy in enemy_party.unit_list)
            {
                unit_list.Add(l_enemy);
                Debug.Log("battle_enemy_unit:" + l_enemy.unit_name);
            }

            battle_sim = Instantiate(battle_sim_prefab);
            battle_sim.GetComponent<BattleSimulator>().endBattleSimulator += BattleEnd;
            battle_sim.GetComponent<BattleSimulator>().Initialize(unit_list);
        }

        public override void BattleEnd(List<UnitBase> unit_list)
        {
            battle_sim.GetComponent<BattleSimulator>().endBattleSimulator -= BattleEnd;
			battle_sim.GetComponent<BattleSimulator>().DestroySimulator();
			
            Debug.Log("BattleEnd");
            foreach (UnitBase unit in unit_list)
            {
                Debug.Log("Unit:" + unit.unit_name + " Hp:" + unit.current.hp);
            }
        }

    }
}