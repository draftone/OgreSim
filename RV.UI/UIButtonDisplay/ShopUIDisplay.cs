using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RV.Data;
using RV.Party;
using RV;
using UnityEngine.UI;
using UnityEngine;
using GameDataEditor;


namespace RV.UI
{
    public class ShopUIDisplay : AbstractUIDisplay
    {
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridShopItemButton";
        }

        void OnEnable()
        {
            PlayerResourceManager.updatePlayerInventory += UpdatePlayerInventoryList;
            UpdatePlayerInventoryList();
        }

        void OnDisable()
        {
            PlayerResourceManager.updatePlayerInventory -= UpdatePlayerInventoryList;
        }

        public void UpdatePlayerInventoryList()
        {
            base.UIClear();
            GetAllInfo();
        }

        /// <summary>
        /// @param index
        /// </summary>
        public override void ClickButtonAction(int index)
        {
            ShopItemButton button = Buttons[index].GetComponent<ShopItemButton>();
            button.ToggleSelect();
            button.SetButtonText();
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
            return PlayerResourceManager.g_inventory_list[index].Key.ToString();
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}