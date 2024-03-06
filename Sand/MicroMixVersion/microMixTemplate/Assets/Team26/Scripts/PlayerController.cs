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
        public GameObject otherPlayer;
        public GameObject winDecider;

        private int lastButton;
        private float p2Score;
        
        
        void Start()
    
        {
            score = 0; 
       
        }

        

    // Update is called once per frame
    
        void Update()    
        {
            myScore.text = "Score: " + score;
    
        }

        protected override void OnButton1Pressed(InputAction.CallbackContext context) {
            //Debug.Log("eat sand! button 1");
            if (lastButton == 2)
            {
                mySandcastle.GetComponent<Sandcastle>().eatSand(20);
                score += 20;
            }
            else
            {
                mySandcastle.GetComponent<Sandcastle>().eatSand(10);
                score += 10;
            }
            lastButton = 1;
        }

        protected override void OnButton2Pressed(InputAction.CallbackContext context)
        {
            //Debug.Log("eat sand! button 2");
            if(lastButton == 1)
            {
                mySandcastle.GetComponent<Sandcastle>().eatSand(50);
                score += 20;
            }
            else
            {
                mySandcastle.GetComponent<Sandcastle>().eatSand(25);
                score += 10;
            }
            

            lastButton = 2;
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
