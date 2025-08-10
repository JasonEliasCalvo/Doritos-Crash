using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : BaseState
{
    public FallState(PlayerMovement parameterController) : base(parameterController) { }
    public override void EnterState()
    {
        Debug.Log("Entro a caer");
        //controller.anim.CrossFade("Fall", 0.2f);
    }

    public override void FixedUpdateState()
    {
        controller.rigid.linearVelocity = new Vector3(controller.horizontal * controller.speedMovement, controller.rigid.linearVelocity.y, controller.rigid.linearVelocity.z);
    }

    public override void UpdateState()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(controller.crouchKey))
            {
                ExitState(controller._crouch);
            }
            else if (controller.horizontal == 0)
            {
                ExitState(controller._idle);
            }
            else ExitState(controller._walk);
        }
    }

    public override void ExitState(BaseState nextState)
    {
        controller.ChangeState(nextState);
    }
}
