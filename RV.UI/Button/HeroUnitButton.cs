using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RV.Data;
using RV.Unit;
using GameDataEditor;

namespace RV.UI
{
    public class HeroUnitButton : AbstractUIButton
    {

        // Use this for initialization
        void Start()
        {
            SetButtonText();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void SetButtonText()
        {
            Button button = gameObject.GetComponent<Button>();
            string string_key = button.GetComponentInChildren<Text>().text;
            Debug.Log("Button_text:" + string_key);
            HeroUnit target_unit = new HeroUnit();
            foreach(HeroUnit l_unit in PlayerResourceManager.g_hero_list){
                if(string_key == l_unit.id.ToString()){
                    target_unit = l_unit;
                    break;
                }
            }
            
            button.GetComponentInChildren<Text>().text = "ID: " + target_unit.id + "\nname:" + target_unit.unit_data.class_name + "\nHP: " + target_unit.unit_data.base_hp + "\nAttack: " + target_unit.unit_data.base_attack + "\nDefense: " + target_unit.unit_data.base_defense;
        }
    }
}