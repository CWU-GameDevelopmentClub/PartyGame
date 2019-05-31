using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bring_Pain : StateMachineBehaviour {
   private float timer = 0;
   public float activate;
   public bool repeat;
   public GameObject hurtBox;
   public float duration;
   public float damage;
   public float knockback;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      timer = 0;    
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      timer += Time.deltaTime;
      if (timer >= activate) {
         GameObject working = Instantiate(hurtBox, animator.transform.position + animator.transform.forward + animator.transform.up * .5f, animator.transform.rotation);
         Hurtbox_Fighter also = working.GetComponent<Hurtbox_Fighter>();
         also.damage = damage;
         also.duration = duration;
         also.knockback = knockback;
         if (repeat) {
            timer = 0;
         } else {
            timer = -99;
         }
      }
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //    
   //}

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
