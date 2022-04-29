using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panteon.Managers;


namespace Panteon.UI
{
    public class ScoreUI : MonoBehaviour
    {
        public Text currentRankText;
        int count;
        float countdown = 13f;

        private void Update()
        {
            currentRankText.text = "Current Position = " + count.ToString();
                if (GameManager.Instance.finishGame)
                {
                   
                    if (GameManager.Instance.opponentWin)
                    {
                    currentRankText.text = " BETTER NEXT TIME ";
                    }
                    else
                    {
                    countdown -= Time.deltaTime;
                    if (countdown <= 10)
                    {
                        currentRankText.text = "Paint Time =  " + countdown.ToString();
                        if (countdown <= 0)
                        {
                            LevelManager.Instance.NextLevel();
                        }
                    }

                }
            }
        }

        public void CurrentRank(int value)
        {
            count = value;
        }

    }

}
