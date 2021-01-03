using System.Collections;
using System.Collections.Generic;
using RV.Party;
using UnityEngine;

namespace RV.UI
{

    public class PartyUnitListUIDisplay : AbstractUIPanelDisplay
    {
        public static HeroParty hero_party;

        void Awake()
        {
            prefab_panel_path = "Prefabs/UI/UnitListPanel";
        }
        void OnEnable()
        {
            UIManagerDirector.setSelectUI += UpdateHeroUnitList;
            UpdateHeroUnitList();
        }

        void OnDisable()
        {
            UIManagerDirector.setSelectUI -= UpdateHeroUnitList;
        }

        void UpdateHeroUnitList()
        {
            Debug.Log("Call UpdateHeroUnitList().");
            base.UIClear();
            GetAllInfo();
        }

        public void SetHeroParty(HeroParty hero_party)
        {
            HeroUnitListUIDisplay.hero_party = hero_party;
        }

        public override void ClickButtonAction(int index)
        {
            //PlayerResourceManager.instance.RemoveHeroUnit(PlayerResourceManager.g_hero_list[index].id);
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }
        public override int GetListCount()
        {
            if (hero_party == null)
                return 0;
            Debug.Log("GetListCount():" + hero_party.unit_list.Count);
            return hero_party.unit_list.Count;
        }

        public override string GetGDEDataName(int index)
        {
            Debug.Log("GetGDEDataName()");
            if (hero_party == null)
                return "";
            return hero_party.unit_list[index].id.ToString();
        }
    }
}