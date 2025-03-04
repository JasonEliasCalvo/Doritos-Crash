using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState
{
    public WalkState(PlayerMovement parameterController) : base(parameterController) { }

    public override void EnterState()
    {
        Debug.Log("Entro a caminar");
        //controller.anim.CrossFade("Walk", 0.1f);
    }

    public override void FixedUpdateState()
    {
        controller.rigid.velocity = new Vector3(controller.horizontal * controller.speedMovement,controller.rigid.velocity.y,controller.rigid.velocity.z);
    }

    public override void UpdateState()
    {
        if (controller.isGrounded)
        {
            if (controller.horizontal == 0)
            {
                ExitState(controller._idle);
            }
            else if (Input.GetKey(controller.runKey))
            {
                ExitState(controller._run);
            }
            else if (Input.GetKey(controller.crouchKey))
            {
                ExitState(controller._crouch);
            }
            else if (Input.GetKeyDown(controller.jumpKey))
            {
                ExitState(controller._jump);
            }
        }
        else
        {
            if (controller.rigid.velocity.y <= 0)
            {
                ExitState(controller._fall);
            }
        }
    }

    public override void ExitState(BaseState nextState)
    {
        controller.ChangeState(nextState);
    }
}
