using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;

namespace RV.Unit
{
    public class UnitBase
    {
        public int id;

        public int party_id;

        public string unit_name;

        public string unit_key;

        public int action_time;

        public bool is_action;

        public bool is_player_unit;

        public bool is_dead;

        public UnitStatus max;

        public UnitStatus current;

        public class UnitStatus
        {
            public int hp;

            public int attack;

            public int defense;

            public int speed;
        }
        public UnitStatus SetStatus(int l_hp, int l_attack, int l_defense, int l_speed)
        {
            UnitStatus status = new UnitStatus();
            status.hp = l_hp;
            status.attack = l_attack;
            status.defense = l_defense;
            status.speed = l_speed;
            return status;
        }

        public void Init()
        {
            // TODO implement here
        }

        public virtual void GetUnitClassData()
        {
            // TODO implement here
        }

        public void SetDefaultActionTime()
        {
            action_time = 100;
        }

        public void UpdateActionTime()
        {
            action_time = action_time - current.speed;
            if (action_time <= 0)
            {
                is_action = true;
                SetDefaultActionTime();
            }
        }

        public void Attack(UnitBase target_unit)
        {
            target_unit.current.hp -= this.current.attack;
            target_unit.Defense();
        }

        public void Defense()
        {
            if (this.current.hp <= 0)
            {
                is_dead = true;
                this.current.hp = 0;
            }
        }

    }
}