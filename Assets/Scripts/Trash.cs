using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

namespace GameActors {

    [DisallowMultipleComponent]
    public class Trash : MonoBehaviour {

        [Header("TRASH DATA")]
        [SerializeField, Tooltip("Type of garbage")]
        private TrashType trashType = TrashType.Last;
        private const string TAG_TO_COMPARE = "TrashCan";



        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(TAG_TO_COMPARE) && trashType == other.gameObject.GetComponent<TrashCan>().TrashType) {
                DisableMe();
            }
        }

        private void DisableMe() {
            if (gameObject.transform.parent != null) {
                gameObject.transform.parent.gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(false);
        }

    }

}