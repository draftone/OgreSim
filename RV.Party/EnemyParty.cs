using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Unit;
using GameDataEditor;

namespace RV.Party
{
    public class EnemyParty : Party<EnemyUnit>
    {
        public override void RemoveUnit(EnemyUnit unit)
        {
            foreach (EnemyUnit l_unit in unit_list)
            {
                if (unit.id == l_unit.id)
                {
                    unit_list.Remove(l_unit);
                }
            }
        }

        public void DebugAddUnitToParty()
        {
            for(int i=0; i < 3; i++)
                DebugAddUnit();
        }
        private void DebugAddUnit()
        {
            EnemyUnit unit = new EnemyUnit();
            unit = EnemyResourceManager.instance.AddRandomEnemyUnit();
            unit_list.Add(unit);
        }
    }
}