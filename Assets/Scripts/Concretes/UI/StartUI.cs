using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panteon.UI
{
    public class StartUI : MonoBehaviour
    {

        public static bool GamePaused = true;

        public GameObject canvasMenu;
        public GameObject currentRank;
        private void Awake()
        {
            Pause();
        }

        public void StartButtonAction()
        {
            canvasMenu.SetActive(false);
            currentRank.SetActive(true);
            Time.timeScale = 1f;
            GamePaused = false;
        }

        public void Pause()
        {
            canvasMenu.SetActive(true);
            currentRank.SetActive(false);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }

}
