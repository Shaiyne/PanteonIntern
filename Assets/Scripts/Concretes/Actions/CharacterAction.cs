using Panteon.Abstracts.Controllers;
using Panteon.Actions;
using Panteon.Controllers;
using Panteon.Managers;
using Panteon.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panteon.Actions
{
    public class CharacterAction : MonoBehaviour
    {
        Animator anim;
        RotatorStickAction rotatorStick;
        PlayerController playerController;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (GameManager.Instance.opponentWin)
            {
                anim.SetBool("OppoWin", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.tag == "finishtag")
            {
                playerController = GetComponent<PlayerController>();
                anim.SetBool("FinishBool", true);
                GameManager.Instance.FinishGameMethod(true);
                InputManager.Instance.OnStartTouch -= playerController.Move;
                transform.GetChild(0).transform.GetComponent<CameraController>().enabled = true;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "HDonut" || collision.transform.tag == "obs" || collision.transform.tag=="sobs")
            {
                playerController = GetComponent<PlayerController>();
                anim.SetBool("DeathBool", true);
                InputManager.Instance.OnStartTouch -= playerController.Move;
                playerController.VerticalMovement(0);
                StartCoroutine(deathWaiting());
            }

        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.transform.tag == "Rotator")
            {
                rotatorStick = collision.transform.GetComponent<RotatorStickAction>();
                anim.SetTrigger("RotatorParam");
                anim.SetBool("RotatorBool", true);
                rotatorStick.StickRotationMethod(90);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.tag == "Rotator")
            {
                anim.SetBool("RotatorBool", false);
                rotatorStick = collision.transform.GetComponent<RotatorStickAction>();
                rotatorStick.StickRotationMethod(0);
            }
        }
        IEnumerator deathWaiting()
        {
            yield return new WaitForSecondsRealtime(2f);
            LevelManager.Instance.RestartLevel();
        }
    }
}

