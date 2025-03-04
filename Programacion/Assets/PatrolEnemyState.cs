using UnityEngine;

public class PatrolEnemyState : StateMachineBehaviour
{
    Enemycontroller Enemycontroller;
    private int currentIndex = 0;
    [SerializeField]float threshold = 0.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemycontroller = animator.GetComponent<Enemycontroller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Enemycontroller.Agent.remainingDistance < threshold)
        {
            currentIndex++;

            if (currentIndex > Enemycontroller.PatrolPositions.Count -1)
            {
                currentIndex = 0;
            }

            Enemycontroller.Agent.SetDestination(Enemycontroller.PatrolPositions[currentIndex].position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
