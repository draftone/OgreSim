using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RV
{
    public class ResourceHubUI : MonoBehaviour
    {

        public Text gold_text;
        public Text worker_text;
        public Text food_text;
        // Use this for initialization
        void Start()
        {
            UpdateText();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            AttachGoldText();
            AttachWorkerText();
            AttachFoodText();
        }

        public void AttachGoldText()
        {
            FindText(ref gold_text, "Gold_Text");
            gold_text.text = PlayerResourceManager.instance.Gold.ToString();
        }
        public void AttachWorkerText()
        {
            FindText(ref worker_text, "Worker_Text");
            worker_text.text = PlayerResourceManager.instance.Worker.ToString();
        }

        public void AttachFoodText()
        {
            FindText(ref food_text, "Food_Text");
            food_text.text = PlayerResourceManager.instance.Food.ToString();
        }

        private void FindText(ref Text ref_text, string text_name)
        {
            if (ref_text == null)
            {
                Text[] text_a = gameObject.GetComponentsInChildren<Text>();
                foreach (Text text in text_a)
                {
                    if (text.name == text_name)
                    {
                        ref_text = text;
                        return;
                    }
                }
            }
        }
    }
}