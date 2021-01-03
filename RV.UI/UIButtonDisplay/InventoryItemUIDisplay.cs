using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RV.Data;
using GameDataEditor;

namespace RV.UI
{
    public class InventoryItemUIDisplay : AbstractUIDisplay
    {
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridButton";
        }

        void OnEnable()
        {
            PlayerResourceManager.updatePlayerInventory += UpdateInventory;
            UpdateInventory();
        }

        void OnDisable()
        {
            PlayerResourceManager.updatePlayerInventory -= UpdateInventory;
        }

        void UpdateInventory()
        {
            base.UIClear();
            GetAllInfo();
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override void ClickButtonAction(int index)
        {
            //PlayerResourceManager.instance.AddItem(ItemMasterData.instance.GetGDEDataKey(index), 1);
            PlayerResourceManager.instance.UseItem(PlayerResourceManager.g_inventory_list[index].Key, 1);
            SoundManager.instance.PlaySound("UI_Button_Click1");
        }
        public override int GetListCount()
        {
            PlayerResourceManager.instance.GetInventoryList();
            Debug.Log("list_count:" + PlayerResourceManager.g_inventory_list.Count());
            return PlayerResourceManager.g_inventory.Count();
        }

        public override string GetGDEDataName(int index)
        {
            PlayerResourceManager.instance.GetInventoryList();
            Debug.Log("GDEDataName:" + PlayerResourceManager.g_inventory_list[index].item_name);
            return PlayerResourceManager.g_inventory_list[index].item_name;
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}