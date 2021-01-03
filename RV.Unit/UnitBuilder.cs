using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.Data;

namespace RV.Unit
{
    public interface Builder
    {
        void CreateUnit(string unit_key);
        void CreateRandomUnit();
    }

    public class UnitDirector
    {
        private Builder builder;
        public UnitDirector(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct(string unit_key)
        {
            builder.CreateUnit(unit_key);
        }

        public void RandomUnitConstruct()
        {
            builder.CreateRandomUnit();
        }
    }

    public class HeroUnitBuilder : Builder
    {
        private HeroUnit hero_unit = new HeroUnit();
        public void CreateUnit(string unit_key)
        {
            hero_unit.unit_data = UnitClassMasterData.instance.GetData(unit_key);
            hero_unit.GetUnitClassData();
        }
        public void CreateRandomUnit()
        {
            hero_unit.unit_data = UnitClassMasterData.instance.GetRandomData();
            hero_unit.GetUnitClassData();
        }
        public HeroUnit GetResult()
        {
            return hero_unit;
        }
    }
    public class EnemyUnitBuilder : Builder
    {
        private EnemyUnit enemy_unit = new EnemyUnit();
        public void CreateUnit(string unit_key)
        {
            enemy_unit.unit_data = MonsterMasterData.instance.GetData(unit_key);
            enemy_unit.GetUnitClassData();
        }
        public void CreateRandomUnit()
        {
            enemy_unit.unit_data = MonsterMasterData.instance.GetRandomData();
            enemy_unit.GetUnitClassData();
        }
        public EnemyUnit GetResult()
        {
            return enemy_unit;
        }
    }
}