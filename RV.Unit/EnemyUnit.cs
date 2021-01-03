using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using RV.Data;
using RV;

namespace RV.Unit
{
    public class EnemyUnit : UnitBase
    {

        public GDEMonsterData unit_data;

        public EnemyUnit()
        {
            is_player_unit = false;
        }
        public override void GetUnitClassData()
        {
            //id = GameStatusManager.instance.GetNextHeroUnitId();
            unit_name = unit_data.name;
            unit_key = unit_data.Key;
            max = SetStatus(unit_data.hp, unit_data.attack, unit_data.defense, unit_data.speed);
            current = SetStatus(unit_data.hp, unit_data.attack, unit_data.defense, unit_data.speed);
        }
    }
}