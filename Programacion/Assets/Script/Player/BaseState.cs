using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected PlayerMovement controller;
    public BaseState(PlayerMovement parameterController)
    {
        controller = parameterController;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState(BaseState nextState);
}
