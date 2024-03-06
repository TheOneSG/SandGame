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
        public TextMeshProUGUI myScore;
        private int lastButton; 
        Animator animator;
        public GameObject otherPlayer;
        public GameObject winDecider;

        private float p2Score;
        
        
        void Start()
    
        {
            score = 0; 
            animator = GetComponent<Animator>();
       
        }

        

    // Update is called once per frame
    
        void Update()    
        {
            myScore.text = "Score: " + score;
    
        }

        protected override void OnButton1Pressed(InputAction.CallbackContext context) {

            if (mySandcastle.GetComponent<Sandcastle>().sandLeft > 0)
            {
                animator.SetTrigger("Left");
                //Debug.Log("eat sand! button 1");
                if (lastButton == 2)
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(2);
                    score += 2;
                }
                else
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(1);
                    score += 1;
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
                animator.SetTrigger("Right");
                //Debug.Log("eat sand! button 2");
                if (lastButton == 1)
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(2);
                    score += 2;
                }
                else
                {
                    mySandcastle.GetComponent<Sandcastle>().eatSand(1);
                    score += 1;
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
