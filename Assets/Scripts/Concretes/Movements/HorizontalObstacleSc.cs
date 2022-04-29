using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panteon.Movements
{
    public class HorizontalObstacleSc : MonoBehaviour
    {
        float horizontalObstaceSpeed=0.3f;
        float destination = -0.75f;
        private void Update()
        {
  
            if (this.transform.position.z >= -0.72f && this.transform.position.z <= 0.72f)
            {
                  this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(this.transform.position.x, this.transform.position.y, destination), horizontalObstaceSpeed * Time.deltaTime);
                if(this.transform.position.z >= 0.71f)
                {
                    destination = -1 * destination;
                }
                else if (this.transform.position.z <= -0.71f)
                {
                    destination = -1 * destination;
                }
            }

        }

    }

}

