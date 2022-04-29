using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panteon.Movements
{
    public class DonutRotation : MonoBehaviour
    {
        int degree;

        private void Awake()
        {
            degree = Random.Range(45, 120);
        }

        private void Start()
        {
            if(this.gameObject.name== "Half_Donut_StickR")
            {
                degree = -1 * degree;
            }
        }
        private void Update()
        {
            transform.Rotate(new Vector3(0, degree, 0)*Time.deltaTime);
        }
    }

}

