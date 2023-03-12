using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEnums;

namespace GameActors {

    [DisallowMultipleComponent]
    public class TrashBin : MonoBehaviour {

        [Header("TRASH BIN REFERENCES")]
        [SerializeField, Tooltip("Trash can collider reference")]
        private Collider myCollider = null;

        [Header("TRASH BIN DATA")]
        [SerializeField, Tooltip("Type of waste that I can throw in this basket")]
        private TrashType trashType = TrashType.Last;
        public TrashType TrashType {
            get { return trashType; }
        }

        private const string TAG = "TrashBin";


        private void Start() {
            VariablesAssignment();
        }
        private void VariablesAssignment() {
            if (!myCollider.isTrigger) myCollider.isTrigger = !myCollider.isTrigger;
            if (tag != TAG) tag = tag;
        }

    }

}