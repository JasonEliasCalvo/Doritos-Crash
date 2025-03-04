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
        controller.rigid.velocity += (Vector3.up * controller.jumpForce);
    }

    public override void FixedUpdateState()
    {
        controller.rigid.velocity = new Vector3(controller.horizontal * controller.speedMovement, controller.rigid.velocity.y, controller.rigid.velocity.z);
    }

    public override void UpdateState()
    {
        if (controller.rigid.velocity.y <= 0)
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
