using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKinematicDriver : MonoBehaviour
{
    // this script runs our ik
    [SerializeField] Transform rightHandTarget, leftHandTarget; // our hand targets

    // set and use animator
    Animator animator; private void Awake() => animator = GetComponent<Animator>();

    // run on animator ik
    private void OnAnimatorIK(int layerIndex)
    {
        // set hand positions & weights
        try
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

            // set hand rotations & weights
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        } catch { }
    }
}
