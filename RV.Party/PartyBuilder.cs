using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.Data;

namespace RV.Party
{
    public interface IPartyBuilder
    {
        void CreateParty();
    }

    public class PartyDirector
    {
        private IPartyBuilder builder;
        public PartyDirector(IPartyBuilder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.CreateParty();
        }
    }

    public class HeroPartyBuilder : IPartyBuilder
    {
        private HeroParty hero_party = new HeroParty();
        public void CreateParty()
        {
            hero_party.id = GameStatusManager.instance.GetNextHeroPartyId();
            //hero_unit.unit_data = UnitClassMasterData.instance.GetData(unit_key);
            //hero_unit.GetUnitClassData();
        }
        public HeroParty GetResult()
        {
            return hero_party;
        }
    }
    public class EnemyPartyBuilder : IPartyBuilder
    {
        private EnemyParty enemy_party = new EnemyParty();
        public void CreateParty()
        {
            enemy_party.id = GameStatusManager.instance.GetNextEnemyPartyId();
        }
        public EnemyParty GetResult()
        {
            return enemy_party;
        }
    }
}