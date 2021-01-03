using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV;
using RV.Data;

public class CastleBehavior : AbstractBuildingBehavior
{
    void Awake()
    {
        //open_window_id = "DebugItemWindow";
        technical_name = "Castle";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAction();
    }

    public override void UpdateAction()
    {
        PlayerResourceManager.instance.Gold += 1;
    }
    public override void EffectDay()
    {

    }

    public override void PermanentEffect()
    {
    }

    public override void CancelPermanentEffect()
    {
    }
}
