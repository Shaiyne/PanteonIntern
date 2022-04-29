using Panteon.Abstracts.Controllers;
using Panteon.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Movements
{
    public class VerticalMove 
    {
        IEntityController entity;

        public VerticalMove(IEntityController entityController)
        {
            entity = entityController;
        }

        public void VerticalMoveMethod(float vertical)
        {
            entity.transform.Translate(Vector3.forward * Time.deltaTime * vertical);
        }

    }

}
