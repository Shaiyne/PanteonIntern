using Panteon.Abstracts.Controllers;
using Panteon.Managers;
using Panteon.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Panteon.Controllers
{
    public class OpponentController : MonoBehaviour , IEntityController
    {
        VerticalMove _verticalMove;
        float _vertical = 1f;
        HorizontalMove _horizontalMove;
        int random;
        float positionZ;
        int random2;


        private void Awake()
        {
            _verticalMove = new VerticalMove(this);
            _horizontalMove = new HorizontalMove(this);
        }

        private void Update()
        {
            if (GameManager.Instance.finishGame != true)
            {
                OppoHorizontalMove(0.7f);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
            if (GameManager.Instance.finishGame == true)
            {
                OpponentMovementEnding();
                if (GameManager.Instance.opponentWin==false)
                {
                    Destroy(gameObject);
                }              
            }
        }

        private void FixedUpdate()
        {
            _verticalMove.VerticalMoveMethod(_vertical);
        }

        public void OppoVerticalMove(float value)
        {
            _vertical = value;
        }
        public void OppoHorizontalMove(float value)
        {
            this.random = Random.Range(0, 2);
            StartCoroutine(secondEnum());
            positionZ = _horizontalMove.characterXClamp(transform.position.z, value);      
        }

        public void OpponentMovementEnding()
        {
            OppoVerticalMove(0);
            OppoHorizontalMove(0);
        }
        public IEnumerator secondEnum()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            this.random2 = Random.Range(0, 5);
            if (random2 == 4)
            {
                if (random == 1)
                {
                    this.transform.Translate(Vector3.right * Time.deltaTime * 2.5f);
                }
                else if (random == 0)
                {
                    this.transform.Translate(Vector3.left * Time.deltaTime * 2.5f);
                }
            }
        }

    }

}
