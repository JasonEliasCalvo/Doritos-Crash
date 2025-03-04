using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : BaseState
{
    public CrouchState(PlayerMovement parameterController) : base(parameterController) { }
    public override void EnterState()
    {
        Debug.Log("Entro a agacharse");
        //controller.anim.CrossFade("Crouch", 0.1f);
        controller.anim.SetBool("Crouch",true);      
    }

    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(controller.jumpKey))
            {
                ExitState(controller._jump);
            }
            else if (Input.GetKeyUp(controller.crouchKey))
            {
                ExitState(controller._idle);
            }
        }
        else if (controller.rigid.velocity.y <= 0)
        {
            ExitState(controller._fall);
        }
    }

    public override void ExitState(BaseState nextState)
    {
        Debug.Log("Salio de agacharse");
        controller.ChangeState(nextState);
    }
}
