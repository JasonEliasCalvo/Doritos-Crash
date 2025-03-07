using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyState : StateMachineBehaviour
{
    Enemycontroller Enemycontroller;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemycontroller = animator.GetComponent<Enemycontroller>();
        Enemycontroller.Agent.isStopped = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemycontroller.Agent.isStopped = false;
    }

}
