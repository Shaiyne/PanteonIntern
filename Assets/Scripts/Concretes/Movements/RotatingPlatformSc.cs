using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Movements
{
    public class RotatingPlatformSc : MonoBehaviour
    {
        Material mat;
        float speed = 0.5f;

        private void Awake()
        {
            mat = GetComponent<MeshRenderer>().material;
        }

        private void Update()
        {
            mat.mainTextureOffset += Vector2.left * Time.deltaTime *speed ;
        }
    }

}
