using System.Collections;
using System.Collections.Generic;
using RV.UI;
using RV.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace RV.UI
{
    public class HeroUnitPanel : AbstractUIPanel
    {
        // Use this for initialization
        void Start()
        {
            SetNameText();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void SetNameText()
        {
            string string_key = gameObject.GetComponentInChildren<Text>().text;
            Debug.Log("Button_text:" + string_key);
            HeroUnit target_unit = new HeroUnit();
            foreach (HeroUnit l_unit in PlayerResourceManager.g_hero_list)
            {
                if (string_key == l_unit.id.ToString())
                {
                    target_unit = l_unit;
                    break;
                }
            }

            //gameObject.GetComponentInChildren<Text>().text = "ID: " + target_unit.id + "name:" + target_unit.unit_data.class_name + "HP: " + target_unit.unit_data.base_hp + "Attack: " + target_unit.unit_data.base_attack + "Defense: " + target_unit.unit_data.base_defense;
			gameObject.GetComponentInChildren<Text>().text = "ID: " + target_unit.id + "name:" + target_unit.unit_data.class_name;
        }
    }
}
