using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using GameDataEditor;
using Assets.UltimateIsometricToolkit.Scripts.Core;
using Assets.UltimateIsometricToolkit.Scripts.physics;
using Assets.UltimateIsometricToolkit.Scripts.Utils;
using RV.Unit;
using RV.Data;
using RV.Party;

namespace RV
{
    public class PlayerResourceManager : RVSingleton<PlayerResourceManager>
    {
        public PlayerResourceManager() : base(false, false)
        {
        }
        private int m_gold;
        public int Gold
        {
            get { return m_gold; }
            set { m_gold = value; }
        }
        private int m_food;
        public int Food
        {
            get { return m_food; }
            set { m_food = value; }
        }
        private int mana;
        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }
        private int worker;
        public int Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public static Dictionary<string, int> g_inventory;

        public static event Action updatePlayerInventory;
        public static event Action updateHeroUnitList;
        public static event Action updateHeroPartyList;
        public static List<GDEItemData> g_inventory_list;
        public static List<HeroUnit> g_hero_list;
        public static List<HeroParty> g_hero_party;

        // Use this for initialization
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void Init()
        {
            m_gold = 10000000;
            m_food = 0;
            mana = 0;
            worker = 0;
            g_inventory = new Dictionary<string, int>();
            g_hero_list = new List<HeroUnit>();
            g_hero_party = new List<HeroParty>();
        }

        public void AddItem(string item_key, int add_num)
        {
            if (g_inventory.ContainsKey(item_key))
            {
                g_inventory[item_key] = g_inventory[item_key] + add_num;
                Debug.Log("AddItem()key:" + item_key + " value:" + g_inventory[item_key]);
            }
            else
            {
                g_inventory.Add(item_key, add_num);
            }
            if (updatePlayerInventory != null)
            {
                updatePlayerInventory();
            }
        }

        private int RemoveItem(string item_key, int item_num)
        {
            if (g_inventory.ContainsKey(item_key))
            {
                if (g_inventory[item_key] < item_num)
                {
                    Debug.LogWarning("not enough inv item:" + item_key);
                    return -1;
                }
                else
                {
                    g_inventory[item_key] = g_inventory[item_key] - item_num;
                    if (g_inventory[item_key] <= 0)
                    {
                        if (g_inventory[item_key] < 0)
                        {
                            Debug.LogError("Item num is less than 0 :" + g_inventory[item_key]);
                        }
                        g_inventory.Remove(item_key);
                    }
                    if (updatePlayerInventory != null)
                    {
                        updatePlayerInventory();
                    }
                }
            }
            else
            {
                Debug.LogWarning("No required item:" + item_key);
                return -1;
            }
            return 0;
        }

        public int UseItem(string item_key, int use_item_num)
        {
            return RemoveItem(item_key, use_item_num);
        }

        public int SellItem(string item_key, int sell_item_num)
        {
            if (RemoveItem(item_key, sell_item_num) == 0)
            {
                m_gold += ItemMasterData.instance.GetData(item_key).sell_price * sell_item_num;
                return 0;
            }
            Debug.LogWarning("SellItem Failure.");
            return -1;
        }

        public int BuyItem(string item_key, int buy_item_num)
        {
            if (m_gold - ItemMasterData.instance.GetData(item_key).buy_price * buy_item_num < 0)
            {
                Debug.LogWarning("BuyItem Failure: not enough gold");
                return -1;
            }
            m_gold -= ItemMasterData.instance.GetData(item_key).buy_price * buy_item_num;
            AddItem(item_key, buy_item_num);
            return 0;
        }

        public List<GDEItemData> GetInventoryList()
        {
            if (g_inventory_list == null)
            {
                g_inventory_list = new List<GDEItemData>();
            }
            g_inventory_list.Clear();
            foreach (KeyValuePair<string, int> pair in g_inventory)
            {
                GDEItemData data = new GDEItemData(pair.Key);
                g_inventory_list.Add(data);
            }
            return g_inventory_list;
        }

        public HeroParty CreateParty()
        {
            HeroPartyBuilder hero_party_builder = new HeroPartyBuilder();
            PartyDirector director = new PartyDirector(hero_party_builder);
            director.Construct();
            HeroParty party = hero_party_builder.GetResult();
            g_hero_party.Add(party);
            Debug.Log("create_party:" + party.id);
            if (updateHeroPartyList != null)
            {
                updateHeroPartyList();
            }
            return party;
        }

        public void DeleteParty(int id)
        {
            foreach (HeroParty l_party in PlayerResourceManager.g_hero_party)
            {
                if (id.ToString() == l_party.id.ToString())
                {
                    g_hero_party.Remove(l_party);
                    break;
                }
            }
            if (updateHeroPartyList != null)
            {
                updateHeroPartyList();
            }
        }

        public HeroParty GetParty(int id)
        {
            foreach (HeroParty l_party in PlayerResourceManager.g_hero_party)
            {
                if (id.ToString() == l_party.id.ToString())
                {
                    return l_party;
                }
            }
            return null;
        }
        public HeroUnit AddHeroUnit(string hero_key)
        {
            HeroUnitBuilder hero_unit_builder = new HeroUnitBuilder();
            UnitDirector director = new UnitDirector(hero_unit_builder);
            director.Construct(hero_key);
            HeroUnit unit = hero_unit_builder.GetResult();
            g_hero_list.Add(unit);
            Debug.Log("add_hero:" + unit.unit_name + ",hp:" + unit.max.hp);
            if (updateHeroUnitList != null)
            {
                updateHeroUnitList();
            }
            return unit;
        }

        public void RemoveHeroUnit(int id)
        {
            foreach (HeroUnit l_unit in PlayerResourceManager.g_hero_list)
            {
                if (id.ToString() == l_unit.id.ToString())
                {
                    g_hero_list.Remove(l_unit);
                    break;
                }
            }
            if (updateHeroUnitList != null)
            {
                updateHeroUnitList();
            }
        }

        public bool UseGold(int gold)
        {
            if (m_gold < gold)
            {
                return false;
            }
            int debug_gold = m_gold;

            m_gold -= gold;
            Debug.Log("UseGold: preuse:" + debug_gold + " use:" + m_gold);
            return true;
        }

        public IsoTransform hero_prefab;
        public void SetFieldParty(int id)
        {
            hero_prefab = (IsoTransform)Resources.Load("Prefabs/Unit/Monster", typeof(IsoTransform));
            var copy = Instantiate(hero_prefab);
            copy.GetComponent<PartyControl>().hero_party = GetParty(id);
            copy.Position = new Vector3(12.0f, 0.6f, 12.0f);
            copy.GetComponent<PartyControl>().DebugLogPartyInfo();
        }
    }
}