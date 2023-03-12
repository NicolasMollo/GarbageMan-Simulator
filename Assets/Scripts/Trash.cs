using UnityEngine;
using CustomEnums;
using System;

namespace GameActors {

    [DisallowMultipleComponent]
    public class Trash : MonoBehaviour {

        [Header("TRASH DATA")]
        [SerializeField, Tooltip("Type of garbage")]
        private TrashType trashType = TrashType.Last;
        public TrashType TrashType {
            get { return trashType; }
        }
        private const string TAG = "Trash";
        private const string TAG_TO_COMPARE = "TrashBin";
        private int layer = 0;
        private const string LAYER_NAME = "Interactable";
        public Action<TrashType> OnDisableMe = null;


        private void Start() {
            VariablesAssignment();
        }

        private void VariablesAssignment() {
            if (tag != TAG) tag = TAG;
            layer = LayerMask.NameToLayer(LAYER_NAME);
            if (gameObject.layer != layer) gameObject.layer = layer;
        }


        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(TAG_TO_COMPARE) && trashType == other.gameObject.GetComponent<TrashBin>().TrashType) {
                DisableMe();
            }
        }

        private void DisableMe() {
            OnDisableMe?.Invoke(trashType);
            gameObject.SetActive(false);
        }

    }

}