using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Party;
using RV.Unit;
using UnityEngine;

namespace RV.Battle
{
    public abstract class AbstractBattleManager : MonoBehaviour
    {
        public AbstractBattleManager()
        {
        }

        public HeroParty player_party;

        public EnemyParty enemy_party;

        public int time;

        private void DecideTarget()
        {
            // TODO implement here
        }

        public void UpdateActionOrder()
        {
            // TODO implement here
        }

        public abstract void Action();
        public abstract void BattleStart();
        public abstract void BattleEnd(List<UnitBase> unit_list);
        public abstract void SetPlayerParty(HeroParty party);
        public abstract void SetEnemyParty(EnemyParty party);
    }

    public class BattleManagerDirector
    {
        //public static event Action setSelectPartyForUI;
        private AbstractBattleManager abst_manager;
        public BattleManagerDirector(AbstractBattleManager abst_manager)
        {
            this.abst_manager = abst_manager;
        }
        public void SetPlayerParty(HeroParty party)
        {
            abst_manager.SetPlayerParty(party);
        }
        public void SetEnemyParty(EnemyParty party)
        {
            abst_manager.SetEnemyParty(party);
        }
        public void EncountEnemy(HeroParty h_party, EnemyParty e_party)
        {
            abst_manager.SetPlayerParty(h_party);
            abst_manager.SetEnemyParty(e_party);
            abst_manager.BattleStart();
        }
    }
}