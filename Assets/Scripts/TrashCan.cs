using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

namespace GameActors {

    [DisallowMultipleComponent]
    public class TrashCan : MonoBehaviour {

        [Header("TRASH REFERENCE")]
        [SerializeField, Tooltip("Trash can collider reference")]
        private Collider myCollider = null;

        [Header("TRASH CAN DATA")]
        [SerializeField, Tooltip("Type of waste that I can throw in this basket")]
        private TrashType trashType = TrashType.Last;
        public TrashType TrashType {
            get { return trashType; }
        }


        private void Start() {
            VariablesAssignment();
        }
        private void VariablesAssignment() {
            if (!myCollider.isTrigger) myCollider.isTrigger = !myCollider.isTrigger;
        }

    }

}