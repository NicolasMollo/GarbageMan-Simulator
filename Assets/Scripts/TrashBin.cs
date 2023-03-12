using UnityEngine;
using CustomEnums;

namespace GameActors {

    [DisallowMultipleComponent]
    public class TrashBin : MonoBehaviour {

        [Header("TRASH BIN REFERENCES")]
        [SerializeField, Tooltip("Trash bin collider:\ninternal trash collider that will interact with trash.")]
        private Collider myCollider = null;

        [Header("TRASH BIN DATA")]
        [SerializeField, Tooltip("Type of trash that can be thrown into this trash bin.")]
        private TrashType trashType = TrashType.Last;
        public TrashType TrashType {
            get { return trashType; }
        }

        private const string TAG = "TrashBin";
        private int layer = 0;
        private const string LAYER_NAME = "Not Passable";



        private void Start() {

            VariablesAssignment();

        }
        private void VariablesAssignment() {

            if (!myCollider.isTrigger) {
                myCollider.isTrigger = !myCollider.isTrigger;
            }

            if (tag != TAG) {
                tag = TAG;
            }

            layer = LayerMask.NameToLayer(LAYER_NAME);
            if (gameObject.layer != layer) {
                gameObject.layer = layer;
            }

        }

    }

}