using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.StateMachine;
using RV.Party;
using RV.Unit;

namespace RV.Battle
{
    public enum BattleState
    {
        Start,
        SetActionOrder,
        Attack,
        End,
    }

    public class BattleSimulator : StatefulObjectBase<BattleSimulator, BattleState>
    {
        public event Action<List<UnitBase>> endBattleSimulator;
        public List<UnitBase> unit_list;
        private Queue<int> action_queue;
        private int battle_time;

        void Start()
        {

        }

        public BattleSimulator()
        {
            Debug.Log("Start BattleSimulator");

        }

        private void SetDefaultActionTime(List<UnitBase> unit_list)
        {
            foreach (UnitBase l_unit in unit_list)
            {
                l_unit.SetDefaultActionTime();
            }
        }

        private void UpdateActionTime(List<UnitBase> unit_list)
        {
            foreach (var l_unit in unit_list.Select((v, i) => new { v, i }))
            {
                if (l_unit.v.is_dead)
                    continue;
                l_unit.v.UpdateActionTime();
                if (l_unit.v.is_action)
                {
                    action_queue.Enqueue(l_unit.i);
                }
            }
        }

        private void Attack(UnitBase attacker, UnitBase target)
        {
            attacker.Attack(target);
        }

        public void Initialize(List<UnitBase> unit_list)
        {
            action_queue = new Queue<int>();
            this.unit_list = new List<UnitBase>();
            this.unit_list = unit_list;

            battle_time = 200;
            // ステートマシンの初期設定
            stateList.Add(new StateStart(this));
            stateList.Add(new StateSetActionOrder(this));
            stateList.Add(new StateAttack(this));
            stateList.Add(new StateEnd(this));
            stateMachine = new StateMachine<BattleSimulator>();
            Debug.Log("Initialize():State");
            ChangeState(BattleState.Start);
        }

        public void EndEventCall()
        {
            Debug.Log("Finalized");
            if (endBattleSimulator != null)
            {
                endBattleSimulator(unit_list);
            }
        }

        public void DestroySimulator()
        {
            Destroy(gameObject);
        }

        #region States

        private class StateStart : State<BattleSimulator>
        {
            public StateStart(BattleSimulator owner) : base(owner) { }

            public override void Enter()
            {
                Debug.Log("StateStart");
                owner.SetDefaultActionTime(owner.unit_list);
                owner.ChangeState(BattleState.SetActionOrder);
            }

            public override void Execute()
            {
                Debug.Log("StateStart:Exec");
            }

            public override void Exit()
            {
                Debug.Log("StateStart:Exit");
            }

        }

        private class StateSetActionOrder : State<BattleSimulator>
        {
            public StateSetActionOrder(BattleSimulator owner) : base(owner) { }

            public override void Enter()
            {
            }

            public override void Execute()
            {
                owner.UpdateActionTime(owner.unit_list);
                if (owner.action_queue.Count() > 0)
                {
                    owner.ChangeState(BattleState.Attack);
                }
                owner.battle_time--;
                Debug.Log("Time:" + owner.battle_time);
                if (owner.battle_time < 1)
                {
                    owner.ChangeState(BattleState.End);
                }
            }

            public override void Exit()
            {
                Debug.Log("StateSetActionOrder:Exit");
            }

        }

        private class StateAttack : State<BattleSimulator>
        {
            public StateAttack(BattleSimulator owner) : base(owner) { }

            public override void Enter()
            {
                //                owner.ChangeState(BattleState.End);
            }

            public override void Execute()
            {
                int index = owner.action_queue.Dequeue();
                UnitBase unit = owner.unit_list[index];
                unit.is_action = false;
                Debug.Log("AttackUnit:" + unit.unit_name + " attack:" + unit.current.attack);
                if (unit.is_player_unit)
                {
                    foreach (UnitBase enemy_unit in owner.unit_list)
                    {
                        if (enemy_unit.is_dead)
                            continue;
                        if (!enemy_unit.is_player_unit)
                        {
                            unit.Attack(enemy_unit);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (UnitBase player_unit in owner.unit_list)
                    {
                        if (player_unit.is_dead)
                            continue;
                        if (player_unit.is_player_unit)
                        {
                            unit.Attack(player_unit);
                            break;
                        }
                    }
                }

                if (owner.action_queue.Count < 1)
                {
                    owner.ChangeState(BattleState.SetActionOrder);
                }
            }

            public override void Exit()
            {
                Debug.Log("StateAttack");
            }
        }

        private class StateEnd : State<BattleSimulator>
        {
            public StateEnd(BattleSimulator owner) : base(owner) { }

            public override void Enter()
            {
                Debug.Log("StateEnd:BattleEnd.");
                // foreach (UnitBase unit in owner.unit_list)
                // {
                // Debug.Log("Unit:" + unit.unit_name + " Hp:" + unit.current.hp);
                // }


                owner.EndEventCall();
                this.Exit();
            }

            public override void Execute()
            {

            }

            public override void Exit()
            {
            }

        }
        #endregion
    }
}
