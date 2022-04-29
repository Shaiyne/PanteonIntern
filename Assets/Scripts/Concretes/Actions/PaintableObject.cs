using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.Managers;


namespace Panteon.Actions
{
    public class PaintableObject : MonoBehaviour
    {

        private void Update()
        {
            if (GameManager.Instance.finishGame)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}

