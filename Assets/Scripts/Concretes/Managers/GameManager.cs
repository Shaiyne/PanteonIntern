using Panteon.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.Managers;
using UnityEngine.SceneManagement;

namespace Panteon.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        PlayerController _playerController;
        public bool finishGame = false;
        public bool opponentWin = false;
        private void Awake()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        public bool FinishGameMethod(bool value)
        {
            _playerController.VerticalMovement(0);
            finishGame = value;
            return finishGame;
        }

        public void ScoreManager(GameObject[] oppo,GameObject player)
        {
            ScoreBoardManager.Instance.scoreMethod(oppo,player);
        }


        public bool OpponentWinMethod(bool value)
        {
            opponentWin = value;
            return opponentWin;
        }


    }

}
