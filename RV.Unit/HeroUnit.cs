using System;
using System.Collections.Generic;
using GameDataEditor;
using RV.Data;
using RV;

namespace RV.Unit
{
    public class HeroUnit : UnitBase
    {
        public GDEUnitClassData unit_data;

        public HeroUnit()
        {
            is_player_unit = true;
        }

        public override void GetUnitClassData()
        {
            id = GameStatusManager.instance.GetNextHeroUnitId();
            unit_name = unit_data.class_name;
            unit_key = unit_data.Key;
            max = SetStatus(unit_data.base_hp, unit_data.base_attack, unit_data.base_defense, unit_data.base_speed);
            current = SetStatus(unit_data.base_hp, unit_data.base_attack, unit_data.base_defense, unit_data.base_speed);
        }

        public void DebugCreateUnit()
        {

        }
    }
}