using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : BaseState
{
    public SlideState(PlayerMovement parameterController) : base(parameterController) { }
    AnimatorStateInfo stateInfo;
    public override void EnterState()
    {
        Debug.Log("Entro a deslizar");
        //controller.anim.CrossFade("Slide", 0.1f);
    }

    public override void FixedUpdateState()
    {

    }

    public override void UpdateState()
    {
        stateInfo = controller.anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 20f)
        {
            if (controller.isGrounded)
            {
                if (controller.horizontal == 0)
                {
                    ExitState(controller._idle);
                }
                else controller.ChangeState(controller._walk);
            }
            else if (controller.rigid.linearVelocity.y <= 0)
            {
                ExitState(controller._fall);
            }       
        }
        else if (Input.GetKeyDown(controller.jumpKey))
        {
            ExitState(controller._jump);
        }
    }

    public override void ExitState(BaseState nextState)
    {
        controller.ChangeState(nextState);
    }

}
