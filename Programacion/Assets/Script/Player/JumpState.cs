using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(PlayerMovement parameterController) : base(parameterController) { }
    public override void EnterState()
    {
        Debug.Log("Entro a saltar");
        //controller.anim.CrossFade("Jump", 0f);
        controller.anim.SetTrigger("Jump");
        controller.rigid.linearVelocity += (Vector3.up * controller.jumpForce);
    }

    public override void FixedUpdateState()
    {
        controller.rigid.linearVelocity = new Vector3(controller.horizontal * controller.speedMovement, controller.rigid.linearVelocity.y, controller.rigid.linearVelocity.z);
    }

    public override void UpdateState()
    {
        if (controller.rigid.linearVelocity.y <= 0)
        {
            if (controller.isGrounded)
            {
                if (controller.horizontal == 0)
                {
                    ExitState(controller._idle);
                }
                else ExitState(controller._walk);
            }
            else ExitState(controller._fall);
        }   
    }
    public override void ExitState(BaseState nextState)
    {
        controller.ChangeState(nextState);
    }

}
