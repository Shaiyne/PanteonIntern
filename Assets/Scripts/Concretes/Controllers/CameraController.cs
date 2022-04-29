using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Controllers
{
    public class CameraController : MonoBehaviour
    {
        Transform from;
        Transform to;
        private void Awake()
        {
            to = transform.GetChild(0).transform;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if (transform.localPosition.y >= 6.5f)
            {
                this.gameObject.transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 6, -13), Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation,to.rotation, Time.deltaTime);
            }
            
        }
    }

}
