using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Data;

namespace RV.UI
{
    public class DebugSoundUIDisplay : AbstractUIDisplay
    {
        void Awake()
        {
            prefab_button_path = "Prefabs/UI/GridButton";
        }

        void Start()
        {
            Init();
            GetAllInfo();
        }
        public override void ClickButtonAction(int index)
        {
            SoundManager.instance.PlaySound(SoundMasterData.instance.GetGDEDataKey(index));
        }
        public override int GetListCount()
        {
            return SoundMasterData.instance.GetListCount();
        }

        public override string GetGDEDataName(int index)
        {
            return SoundMasterData.instance.GetGDEDataName(index);
        }
        public override string GetIconPath(int index)
        {
            return null;
        }
    }
}