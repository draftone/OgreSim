using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RV.UI;

namespace RV
{
    public class MainGameSceneLoad : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            LoadUIScene();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadUIScene()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);

            // SceneManager.MergeScenes(SceneManager.GetSceneAt(0), SceneManager.GetSceneAt(1));
        }
        
        void OnSceneLoaded(Scene scene, LoadSceneMode mode){
            Debug.Log(scene.name + "scene loaded");
        }
    }
}