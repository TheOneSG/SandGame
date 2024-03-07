using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using team26;
using UnityEngine.UI;
using TMPro;


namespace team26 { 

    public class PlayerController : MicrogameInputEvents
    {
        // Start is called before the first frame update

        public bool amPlayer1;
        public int score;
        public GameObject mySandcastle;
        private int lastButton; 
        public Animator animator;
        public GameObject otherPlayer;
        public GameObject winDecider;
        public GameObject mouthSand;
        public GameObject arm1Sand;
        public GameObject arm2Sand;
        public GameObject myBody;
        public GameObject sandSpeaker;
        //public GameObject dingSpeaker;

        private SandAudioManager sandManager;
        //private AudioSource dingSource;

        private float p2Score;
        
        
        void Start()
        {
            //dingSource = dingSpeaker.GetComponent<AudioSource>();
            sandManager = sandSpeaker.GetComponent<SandAudioManager>();
        }
        private void Update()
        {
            if (mySandcastle.GetComponent<Sandcastle>().sandLeft <= 0)
            {
                if (amPlayer1)
                {
                    p2Score = otherPlayer.GetComponent<PlayerController>().score;
                    winDecider.GetComponent<PlayerWinScreen>().setWinner(score, p2Score);
                }
                else
                {
                    p2Score = otherPlayer.GetComponent<PlayerController>().score;
                    winDecider.GetComponent<PlayerWinScreen>().setWinner(p2Score, score);
                }
            }
        }





        // Update is called once per frame



        protected override void OnButton1Pressed(InputAction.CallbackContext context) {


            sandManager.PlaySandEatingSound();
            if (mySandcastle.GetComponent<Sandcastle>().sandLeft > 0)
            {
                animator.SetTrigger("Left");
                mouthSand.GetComponent<ParticleSystem>().Play();
                arm1Sand.GetComponent<ParticleSystem>().Play();
                //Debug.Log("eat sand! button 1");
                if (lastButton == 2)
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(2);
                    score += 2;
                    CameraShaker.intensity += 1;
                }
                else
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(1);
                    score += 1;
                    CameraShaker.intensity += 0.5f;
                }
                lastButton = 1;
            }
            else
            {
                p2Score = otherPlayer.GetComponent<PlayerController>().score;
                winDecider.GetComponent<PlayerWinScreen>().setWinner(score, p2Score);
            }
        }

        protected override void OnButton2Pressed(InputAction.CallbackContext context)
        {
            if (mySandcastle.GetComponent<Sandcastle>().sandLeft > 0)
            {
                mouthSand.GetComponent<ParticleSystem>().Play();
                arm2Sand.GetComponent<ParticleSystem>().Play();
                animator.SetTrigger("Right");
                //Debug.Log("eat sand! button 2");
                if (lastButton == 1)
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(2);
                    score += 2;
                    CameraShaker.intensity += 1;
                }
                else
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(1);
                    score += 1;
                    CameraShaker.intensity += 0.5f;
                }


                lastButton = 2;
            }
            else 
            {
                p2Score = otherPlayer.GetComponent<PlayerController>().score;
                winDecider.GetComponent<PlayerWinScreen>().setWinner(score, p2Score);
            }
        }
        protected override void OnTimesUp()
        {
            if (amPlayer1)
            {
                p2Score = otherPlayer.GetComponent<PlayerController>().score;
                winDecider.GetComponent<PlayerWinScreen>().setWinner(score, p2Score);
            }
        }
            
    }
}
