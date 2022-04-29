using Panteon.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.Abstracts.Controllers;


namespace Panteon.Movements
{
    public class HorizontalMove 
    {
        float maxHSpeed = 1.5f;
        IEntityController entity;

        public HorizontalMove(IEntityController entityController)
        {
            entity = entityController;
        }
        public virtual void TickFixed(float horizontal , float moveSpeed)
        {
            if (horizontal == 0f) return;

            horizontal = Mathf.Clamp(horizontal,-maxHSpeed, maxHSpeed);

            entity.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);
        }

        public float characterXClamp(float position,float value)
        {
            position = Mathf.Clamp(position, -value, value);
            return position;
        }

    }

}
