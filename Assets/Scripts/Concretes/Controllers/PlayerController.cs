using Panteon.Abstracts.Controllers;
using Panteon.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        HorizontalMove _horizontalMove;
        VerticalMove _verticalMove;

        [SerializeField] float _moveSpeed = 5f;
        float _horizontal;
        float positionZ;
        float _vertical = 1f;
        

        private void Awake()
        {
            _horizontalMove = new HorizontalMove(this);
            _verticalMove = new VerticalMove(this);
        }
        private void Update()
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
        }
        private void FixedUpdate()
        {
            _horizontalMove.TickFixed(_horizontal, _moveSpeed);
            _verticalMove.VerticalMoveMethod(_vertical);

        }

        private void OnEnable()
        {
            InputManager.Instance.OnStartTouch += Move;
        }

        public void Move(float value)
        {
            _horizontal = value;
            positionZ = _horizontalMove.characterXClamp(transform.position.z,0.7f);
        }

        public void VerticalMovement(float value)
        {
            _vertical = value;
        }

    }

}
