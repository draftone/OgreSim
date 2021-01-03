using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RV
{
    public class GameStatusManager : RVSingleton<GameStatusManager>
    {
        public GameStatusManager() : base(false, false)
        {
        }

        public int enemy_unit_id;
        public int enemy_party_id;
        public int hero_unit_id;
        public int hero_party_id;

        public int GetCurrentHeroUnitId()
        {
            return hero_unit_id;
        }
        public int GetNextHeroUnitId()
        {
            hero_unit_id++;
            return hero_unit_id;
        }

        public int GetCurrentHeroPartyId()
        {
            return hero_party_id;
        }
        public int GetNextHeroPartyId()
        {
            hero_party_id++;
            return hero_party_id;
        }

        public int GetCurrentEnemyUnitId()
        {
            return enemy_unit_id;
        }
        public int GetNextEnemyUnitId()
        {
            enemy_unit_id++;
            return enemy_unit_id;
        }

        public int GetCurrentEnemyPartyId()
        {
            return enemy_party_id;
        }
        public int GetNextEnemyPartyId()
        {
            enemy_party_id++;
            return enemy_party_id;
        }

    }
}
