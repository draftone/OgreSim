using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RV.UI
{
    public abstract class AbstractUIButton : MonoBehaviour
    {
        private bool is_select;

        public abstract void SetButtonText();

        public bool IsSelect()
        {
            return is_select;
        }

        public virtual bool ToggleSelect()
        {
            if (is_select)
            {
                is_select = false;
            }
            else
            {
                is_select = true;
            }
            return is_select;
        }
        public virtual void SelectClear()
        {
            is_select = false;
        }
    }
}