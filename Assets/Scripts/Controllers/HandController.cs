using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Controllers {

    [DisallowMultipleComponent]
    public class HandController : MonoBehaviour {

        [Header("HAND CONTROLLER REFERENCES")]
        [SerializeField, Tooltip("Hand animator")]
        private Animator animator = null;
        [SerializeField, Tooltip("Controller from which the value of the axes/grips will be read")]
        private ActionBasedController actionBasedControllers = null;

        [Header("HAND CONTROLLER DATA")]
        [SerializeField, Tooltip("Grip speed")]
        private float gripSpeed = 0f;

        private float gripTarget = 0f;
        private float currentGrip = 0f;
        private const string ANIM_GRIP_NAME = "Grip";


        private void Update() {
            AnimateHand();
        }
        private void AnimateHand() {

            gripTarget = actionBasedControllers.selectAction.action.ReadValue<float>();

            if (currentGrip != gripTarget) {
                currentGrip = Mathf.MoveTowards(currentGrip, gripTarget, gripSpeed);
                animator.SetFloat(ANIM_GRIP_NAME, currentGrip);
            }

        }

    }

}