using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV.UI;
using RV.Party;
using RV;

public class HeroUnitListUIDisplay : AbstractUIDisplay
{
    public static HeroParty hero_party;

    void Awake()
    {
        prefab_button_path = "Prefabs/UI/GridHeroUnitButton";
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
    public override string GetIconPath(int index)
    {
        return null;
    }
}
