using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class LightBrakerNode : ActionNode
{
    public bool lightBreak;

    protected override void OnStart() {
        lightBreak = true;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
