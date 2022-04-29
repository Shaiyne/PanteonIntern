using Panteon.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.Managers;
using Panteon.Controllers;

namespace Panteon.Managers
{
    public class OpponentManager : Singleton<OpponentManager>
    {
        [SerializeField] GameObject opponentChar;
        GameObject[] oppo = new GameObject[9];
        PlayerController _playerController;

        private void Awake()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            for (int i = 0; i < oppo.Length; i++)
            {

                oppo[i] = Instantiate(opponentChar, this.transform.GetChild(i)) as GameObject;
            }
        }
        private void Update()
        {
            GameManager.Instance.ScoreManager(oppo, _playerController.gameObject);
        }
    }

}
