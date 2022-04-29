using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Actions
{
    public class RotatorStickAction : MonoBehaviour
    {
        
        public void StickRotationMethod(int value)
        {
            if (this.transform.parent.transform.rotation.y <= 0)
            {
                this.transform.Rotate(new Vector3(0, value, 0) * Time.deltaTime);
            }
            else
            {
                this.transform.Rotate(new Vector3(0, -value, 0) * Time.deltaTime);
            }
            
        }
    }

}
