using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RV;
using RV.Data;
using RV.UI;

public class BarBehavior : AbstractBuildingBehavior
{
    void Awake(){
        open_window_id = "DebugUnitClassWindow";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAction();
    }

    public override void UpdateAction()
    {

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
