using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UIWindow))]
public partial class UIWindowInputHandler : MonoBehaviour, IUIWindowInputHandler
{
    public KeyCode keyCode = KeyCode.None;
    public string ActionName = "";
    protected UIWindow window;
    protected virtual void Awake()
    {
        window = GetComponent<UIWindow>();
    }

    protected virtual void Update()
    {
        //if (Input.GetKeyDown(keyCode) || Input.GetButtonDown(ActionName))
        if (Input.GetKeyDown(keyCode))
        {
            window.Toggle();
        }
    }
}
