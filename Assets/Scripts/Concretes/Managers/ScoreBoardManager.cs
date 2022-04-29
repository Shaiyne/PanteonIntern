using Panteon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Managers
{
    public class ScoreBoardManager : Singleton<ScoreBoardManager> //Monobeh
    {
        public int count;
        [SerializeField] ScoreUI scoreUI;
  
        public void scoreMethod(GameObject[] oppo, GameObject player)
        {
            if (GameManager.Instance.finishGame == true)
            {
                count = oppo.Length + 1;
            }
            count = oppo.Length + 1;
            if (GameManager.Instance.finishGame != true) 
            {
                for (int i = 0; i < oppo.Length; i++)
                {
                    if (oppo[i].transform.position.x < player.transform.position.x)
                    {
                        count--;
                    }
                }
                scoreUI.CurrentRank(count);
            }
            
        }

    }

}
