using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDataEditor;
using RV.Data;

namespace RV.UI
{
    public class ShopItemButton : AbstractUIButton
    {
        public GDEItemData item;
        // Use this for initialization
        void Start()
        {
            SearchPlayerInventory();
            SetButtonText();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SearchPlayerInventory()
        {
            Button button = gameObject.GetComponent<Button>();
            string string_key = button.GetComponentInChildren<Text>().text;
            Debug.Log("Button_text:" + string_key);
            foreach (var l_item in PlayerResourceManager.g_inventory_list)
            {
                    if (string_key == l_item.Key.ToString())
                    {
                        item = l_item;
                        break;
                    }
            }
            // foreach (HeroParty l_party in PlayerResourceManager.g_hero_party)
            // {
            //     if (string_key == l_party.id.ToString())
            //     {
            //         hero_party = l_party;
            //         break;
            //     }
            // }
        }

        public override void SetButtonText()
        {
            Button button = gameObject.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = "ID: " + item.Key + "\nisselcted: " + IsSelect();
        }
    }
}