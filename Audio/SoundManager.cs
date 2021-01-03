using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameDataEditor;

namespace RV
{
    public class SoundManager : RVSingleton<SoundManager>
    {
        public SoundManager() : base(false, false)
        {
        }
        //public AudioListener _audio_listener;
        private string cueSheetName = "CueSheet_0";
        private CriAtomSource atomSourcetest;
        //private CriAtomSource 

        // Use this for initialization
        void Start()
        {
            atomSourcetest = gameObject.AddComponent<CriAtomSource>();
            atomSourcetest.cueSheet = cueSheetName;
        }

        public void PlaySound(string key)
        {
            GDESoundData data = new GDESoundData(key);
            cueSheetName = data.CUE_SHEET_NAME;
            atomSourcetest.volume = 1.0f;
            atomSourcetest.Play(data.CUE_NAME);
            //atomSourcetest.Play(cueName);
        }

        public void PlaySe(string cueName, float volume)
        {
            atomSourcetest.volume = volume;
            atomSourcetest.Play(cueName);
        }

    }
}