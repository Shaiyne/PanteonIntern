using Panteon.Controllers;
using Panteon.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panteon.UI;


namespace Panteon.Actions
{  
    public class OppoActions : MonoBehaviour
    {
        OpponentController opponentController;
        Animator anim;
        RotatorStickAction rotatorStick;
        AudioSource impactSound;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            impactSound = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "rotatingTag")
            {
                this.opponentController = GetComponent<OpponentController>();
                this.opponentController.OppoHorizontalMove(0.3f);
                this.transform.position = Vector3.MoveTowards(this.transform.position,new Vector3(transform.position.x, transform.position.y, 0),Time.deltaTime);
            }
            if (other.transform.tag == "finishtag")
            {
                GameManager.Instance.OpponentWinMethod(true);
                GameManager.Instance.FinishGameMethod(true);          
                anim.SetBool("OppoWin", true);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "HDonut" || collision.transform.tag == "obs" || collision.transform.tag=="Girl" || collision.transform.tag=="Player")
            {
                this.opponentController = GetComponent<OpponentController>();
                this.anim.SetBool("DeathBool", true);
                this.opponentController.OppoVerticalMove(0);
                StartCoroutine(deathWaiting());
                if(this.gameObject.transform.GetComponent<AudioSource>().enabled) this.impactSound.Play();
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
            yield return new WaitForSecondsRealtime(1f);
            this.gameObject.transform.GetComponent<AudioSource>().enabled = false;
            var place = Random.Range(0, 9);
            if (OpponentManager.Instance.transform.GetChild(place) != null)
            {
                this.gameObject.transform.position = OpponentManager.Instance.transform.GetChild(place).position;
                StartCoroutine(opponentController.secondEnum());
            }
            
            this.opponentController.OppoVerticalMove(1);
        }
    }
    
}
