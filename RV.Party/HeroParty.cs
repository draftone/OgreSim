
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Unit;
using GameDataEditor;

namespace RV.Party
{
    public class HeroParty : Party<HeroUnit>
    {
        public override void RemoveUnit(HeroUnit unit)
        {
            foreach (HeroUnit l_unit in unit_list)
            {
                if (unit.id == l_unit.id)
                {
                    unit_list.Remove(l_unit);
                }
            }
        }

        public void DebugAddUnitToParty()
        {
            DebugAddUnit("Knight");
            DebugAddUnit("Gladiator");
            DebugAddUnit("Archer");

        }
        private void DebugAddUnit(string key)
        {
            HeroUnit unit = new HeroUnit();
            unit = PlayerResourceManager.instance.AddHeroUnit(key);
            unit_list.Add(unit);
        }
    }
}