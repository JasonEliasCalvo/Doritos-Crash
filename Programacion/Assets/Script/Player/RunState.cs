using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerMovement parameterController) : base(parameterController) { }

    public override void EnterState()
    {
        Debug.Log("Entro a correr");
        //controller.anim.CrossFade("Run", 0.1f);
    }

    public override void FixedUpdateState()
    {
        controller.rigid.velocity = new Vector3(controller.horizontal * (controller.speedMovement * 2), controller.rigid.velocity.y, controller.rigid.velocity.z);
    }

    public override void UpdateState()
    {
        if (controller.isGrounded)
        {
            if (controller.horizontal == 0)
            {
                ExitState(controller._idle);
            }
            else if (Input.GetKeyDown(controller.crouchKey))
            {
                ExitState(controller._slide);
            }
            else if (Input.GetKeyUp(controller.runKey))
            {
                ExitState(controller._walk);
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
