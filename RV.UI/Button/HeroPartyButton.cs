using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RV.Data;
using RV.Party;
using RV.Unit;
using GameDataEditor;

namespace RV.UI
{
    public class HeroPartyButton : AbstractUIButton
    {
        public HeroParty hero_party;
        // Use this for initialization
        void Start()
        {
            SearchParty();
            SetButtonText();
            UIManagerDirector.selectClear += base.SelectClear;
            //party_manager_director.selectClear += UpdateHeroPartyList;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SearchParty()
        {
            Button button = gameObject.GetComponent<Button>();
            string string_key = button.GetComponentInChildren<Text>().text;
            Debug.Log("Button_text:" + string_key);
            foreach (HeroParty l_party in PlayerResourceManager.g_hero_party)
            {
                if (string_key == l_party.id.ToString())
                {
                    hero_party = l_party;
                    break;
                }
            }
        }

        public override void SetButtonText()
        {
            Button button = gameObject.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = "ID: " + hero_party.id + "\nisselcted: " + IsSelect();
        }
    }
}