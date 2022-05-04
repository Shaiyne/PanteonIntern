using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.Controllers;


namespace Panteon.Movements
{
    public class RotatingPlatformSc : MonoBehaviour
    {
        MeshRenderer[] meshs;
        float speed = 0.5f;

        private void Awake()
        {
            meshs = GetComponentsInChildren<MeshRenderer>();
        }

        private void Update()
        {
            for(int i = 0; i < meshs.Length; i++)
            {
                if (i % 2 == 0)
                {
                    meshs[i].material.mainTextureOffset += Vector2.left * Time.deltaTime * speed;
                }
                else
                {
                    meshs[i].material.mainTextureOffset += Vector2.right * Time.deltaTime * speed;
                }
                
            }
        }
    }

}
