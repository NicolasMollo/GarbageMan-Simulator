using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {

    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour {

        public static GameManager Instance {
            get;
            private set;
        } = null;


        // Add here the managers references


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
        }

    }

}