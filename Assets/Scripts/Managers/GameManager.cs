using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Managers {

    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour {

        public static GameManager Instance {
            get;
            private set;
        } = null;


        // Add here the managers references
        public TrashManager trashManager = null;


        // Add here the events
        public Action OnSetUp = null;


        private void Awake() {
            SetSingleton();
            SetUp();
        }

        private void SetSingleton() {
            if (Instance != null) {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void SetUp() {
            DontDestroyOnLoad(this);
            OnSetUp?.Invoke();
        }


    }

}