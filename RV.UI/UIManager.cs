using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RV;
using RV.Party;
using RV.Unit;
using RV.UI;
using GameDataEditor;
using UnityEngine.UI;

namespace RV.UI
{

    public class HeroPartyManager : AbstractUIManager
    {
        private HeroParty hero_party;
        public override void SetSelectInfo()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("HeroPartyButton"))
            {
                HeroPartyButton hero_party_button = obj.GetComponent<HeroPartyButton>();
                if (hero_party_button.IsSelect())
                {
                    if (!select_id.Contains(hero_party_button.hero_party.id.ToString()))
                    {
                        select_id.Add(hero_party_button.hero_party.id.ToString());
                        hero_party_button.hero_party.is_selected = true;
                        Debug.Log("Add selectid:" + hero_party_button.hero_party.id);
                    }
                }
            }
        }
        public override void SetSelectInfoOne()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("HeroPartyButton"))
            {
                HeroPartyButton hero_party_button = obj.GetComponent<HeroPartyButton>();
                if (hero_party_button.IsSelect())
                {
                    if (!select_id.Contains(hero_party_button.hero_party.id.ToString()))
                    {
                        select_id.Add(hero_party_button.hero_party.id.ToString());
                        hero_party_button.hero_party.is_selected = true;
                        Debug.Log("Select one Add selectid:" + hero_party_button.hero_party.id);
                        break;
                    }
                }
            }
        }
        public override void SetSelectUI()
        {
            HeroUnitListUIDisplay.hero_party = PlayerResourceManager.instance.GetParty(int.Parse(select_id[0]));
            PartyUnitListUIDisplay.hero_party = PlayerResourceManager.instance.GetParty(int.Parse(select_id[0]));
            Debug.Log("HeroParty:" + HeroUnitListUIDisplay.hero_party.id);
        }

        public override void SelectButton()
        {
            //TODO
            select_id.Clear();
        }

        public override void GetSelectResultList(string id)
        {
            int party_id = int.Parse(id);
            foreach (HeroParty l_hero_party in PlayerResourceManager.g_hero_party)
            {
                if (party_id.ToString() == l_hero_party.id.ToString())
                {
                    hero_party = l_hero_party;
                    break;
                }
            }
            foreach (HeroUnit l_hero_unit in hero_party.unit_list)
            {
                Debug.Log("unitid:" + l_hero_unit.id + " name:" + l_hero_unit.unit_name);
            }
        }
        public override void SelectAllClear()
        {
            foreach (HeroParty l_hero_party in PlayerResourceManager.g_hero_party)
            {
                l_hero_party.is_selected = false;
            }
            select_id.Clear();
        }
    }

    public class ShopManager : AbstractUIManager
    {
        private GDEItemData item_data;
        public override void SetSelectInfo()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ShopItemButton"))
            {
                ShopItemButton shop_item_button = obj.GetComponent<ShopItemButton>();
                if (shop_item_button.IsSelect())
                {
                    if (!select_id.Contains(shop_item_button.item.Key))
                        select_id.Add(shop_item_button.item.Key);
                    Debug.Log("Add selectid:" + shop_item_button.item.Key);
                }
            }
        }
        public override void SetSelectInfoOne()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ShopItemButton"))
            {
                ShopItemButton shop_item_button = obj.GetComponent<ShopItemButton>();
                if (shop_item_button.IsSelect())
                {
                    if (!select_id.Contains(shop_item_button.item.Key))
                    {
                        select_id.Add(shop_item_button.item.Key);
                        Debug.Log("Select one Add selectid:" + shop_item_button.item.Key);
                        break;
                    }
                }
            }
        }
        public override void SetSelectUI()
        {
            //HeroUnitListUIDisplay.hero_party = PlayerResourceManager.instance.GetParty(int.Parse(select_id[0]));
            //Debug.Log("HeroParty:" + HeroUnitListUIDisplay.hero_party.id);
        }

        public override void SelectButton()
        {
            //TODO
            select_id.Clear();
        }

        public override void GetSelectResultList(string id)
        {
            foreach (GDEItemData l_item in PlayerResourceManager.g_inventory_list)
            {
                if (id == l_item.Key)
                {
                    item_data = l_item;
                    PlayerResourceManager.instance.SellItem(l_item.Key, 1);
                    break;
                }
            }
        }
        public override void SelectAllClear()
        {

        }
    }

    public abstract class AbstractUIManager
    {
        public AbstractUIManager()
        {
            select_id = new List<string>();
        }
        public List<string> select_id;
        public abstract void SetSelectInfo();
        public abstract void SetSelectInfoOne();
        public abstract void SelectButton();
        public abstract void SetSelectUI();
        public abstract void GetSelectResultList(string id);
        public abstract void SelectAllClear();
    }

    public class UIManagerDirector
    {
        public static event Action setSelectUI;
        public static event Action selectClear;

        private AbstractUIManager abst_manager;
        public UIManagerDirector(AbstractUIManager abst_manager)
        {
            this.abst_manager = abst_manager;
            this.abst_manager.select_id = new List<string>();
        }
        public void GetSelect()
        {
            abst_manager.SetSelectInfo();
        }
        public void GetSelectOne()
        {
            abst_manager.SetSelectInfoOne();
        }
        public void SetSelectUI()
        {
            abst_manager.SetSelectUI();
            if (setSelectUI != null)
            {
                setSelectUI();
            }
        }

        public void GetSelectList()
        {
            foreach (var id in abst_manager.select_id)
            {
                Debug.Log("SelectID:" + id);
                abst_manager.GetSelectResultList(id);
            }
        }
        public void SelectAllClear()
        {
            abst_manager.SelectAllClear();
            if (selectClear != null)
            {
                selectClear();
            }
        }
    }
}