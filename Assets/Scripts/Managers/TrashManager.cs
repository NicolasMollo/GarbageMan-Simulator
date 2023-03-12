using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameActors;
using CustomEnums;
using System;

namespace Managers {

    [Serializable]
    public class TrashManagerData {

        [Tooltip("Number of trash to generate")]
        public int numberOfTrash = 0;
        [HideInInspector] public int plasticTrashes = 0;
        [HideInInspector] public int paperTrashes = 0;
        [HideInInspector] public int organicWetTrashes = 0;
        [HideInInspector] public int undifferentiatedTrashes = 0;

    }

    [DisallowMultipleComponent]
    public class TrashManager : MonoBehaviour {

        [Header("TRASH MANAGER REFERENCES")]
        [SerializeField, Tooltip("Transform within which the objects created by the manager will be inserted in the hierarchy")]
        private Transform trashParent = null;
        [SerializeField, Tooltip("Prefabs that will be used to create the trash objects in the scene")]
        private Trash[] trashPrefabs = new Trash[(int)TrashType.Last];
        [Header("TRASH MANAGER DATA")]
        [SerializeField, Tooltip("Trash Manager data")]
        private TrashManagerData data;

        private List<Trash> trashes = new List<Trash>();
        public Action<TrashManagerData> OnInitNumberOfTrashes = null;
        public Action<TrashManagerData> OnModifyNumbersOfTrashes = null;


        private void Start() {
            CreateTrashes();
            AddListeners();
        }

        private void CreateTrashes() {

            for (int i = 0; i < data.numberOfTrash; i++) {
                CreateTrash();
            }

            OnInitNumberOfTrashes?.Invoke(data);

        }
        private Trash CreateTrash() {

            int randomValue = UnityEngine.Random.Range((int)TrashType.Plastic, (int)TrashType.Last);
            Trash trash = Instantiate(trashPrefabs[randomValue], Vector3.zero, Quaternion.Euler(0, 0, 0), trashParent);
            IncreaseNumberOfTrash((TrashType)randomValue);
            trashes.Add(trash);
            return trash;

        }
        private void IncreaseNumberOfTrash(TrashType _type) {

            switch (_type) {
                case TrashType.Plastic:
                    data.plasticTrashes += 1;
                    break;
                case TrashType.Paper:
                    data.paperTrashes += 1;
                    break;
                case TrashType.OrganicWet:
                    data.organicWetTrashes += 1;
                    break;
                case TrashType.Undifferentiated:
                    data.undifferentiatedTrashes += 1;
                    break;
            }

        }

        private void AddListeners() {
            foreach (Trash trash in trashes) {
                trash.OnDisableMe += DecreaseNumberOfTrash;
            }
        }


        private void OnDestroy() {
            RemoveListeners();
        }
        private void RemoveListeners() {
            foreach (Trash trash in trashes) {
                trash.OnDisableMe -= DecreaseNumberOfTrash;
            }
        }

        

        private void DecreaseNumberOfTrash(TrashType _type) {

            data.numberOfTrash -= 1;

            switch (_type) {
                case TrashType.Plastic:
                    data.plasticTrashes -= 1;
                    break;
                case TrashType.Paper:
                    data.paperTrashes -= 1;
                    break;
                case TrashType.OrganicWet:
                    data.organicWetTrashes -= 1;
                    break;
                case TrashType.Undifferentiated:
                    data.undifferentiatedTrashes -= 1;
                    break;
            }

            OnModifyNumbersOfTrashes?.Invoke(data);

        }

        // For debug
        private void Update() {

            Debug.Log($"PLASTIC NUMBER {data.plasticTrashes}");
            Debug.Log($"PAPER NUMBER {data.paperTrashes}");
            Debug.Log($"ORGANICWET NUMBER {data.organicWetTrashes}");
            Debug.Log($"UNDIFFERENTIATED NUMBER {data.undifferentiatedTrashes}");
            Debug.Log($"TRASHES NUMBER {data.numberOfTrash}");
            Debug.Log($"Trashes count {trashes.Count}");

        }

    }

}