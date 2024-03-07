 using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace team26
{
    public class PlayerWinScreen : MicrogameInputEvents
    {
        // Start is called before the first frame update

        //Face Winner
        //Slide left by transform position -2.2
        //Rotate other face 180 and same will work

        //Crying Face
        //Start at x = 0, y = -0.47, scale x =  0.6, y = 0.6
        //Slide right by transform position 2.1

        public GameObject Crying;
        public GameObject RedFace;
        public GameObject BlueFace;

        public float winner = 0;

        private bool moveEnd = false;

        public float timer = 0;
        public int speed = 8;

        public float faceShift = -2.2f;
        public float cryShift = 2.1f;

        private bool winnerDecided;
        private bool GameCompletedEarlyCheck;

        public void setWinner(float player1Score, float player2Score){
            if(player1Score > player2Score)
            {
                winner = 1;
            }
            else
            {
                winner = 2;
            }
        }

        void Start()
        {
            winnerDecided = false;
            moveEnd = false;
            GameCompletedEarlyCheck = false;

            RedFace.SetActive(false);
            BlueFace.SetActive(false);
            Crying.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //Runs this when winner has been decided


            if (winner == 1)
            {
                timer += Time.deltaTime;
                CameraShaker.intensity = 0;
                //GameCompleteCheck
                if (!GameCompletedEarlyCheck)
                {
                    ReportGameCompletedEarly();
                    GameCompletedEarlyCheck = true;
                }


                if (timer > 0.3)
                {
                    //Put Camera flash here

                    //Sets blue face to be active and sets correct face
                    BlueFace.SetActive(true);
                    BlueFace.transform.GetChild(0).gameObject.SetActive(true);
                    BlueFace.transform.GetChild(1).gameObject.SetActive(false);

                    Crying.SetActive(true);
                    Crying.transform.GetChild(0).gameObject.SetActive(true);
                    Crying.transform.GetChild(1).gameObject.SetActive(false);

                    //Checks if it is past the proper location
                    if (BlueFace.transform.position.x > faceShift)
                    {
                        //Moves at specified rate
                        BlueFace.transform.position += Vector3.left * Time.deltaTime;
                        Crying.transform.position += Vector3.right * Time.deltaTime;
                    }
                    else
                    {
                        //Ends movement loop
                        moveEnd = true;
                    }

                    if (moveEnd == true)
                    {
                        //Switches faces at specific times then ends scene
                        if (timer > 1)
                        {

                            //deactivate child Face.GetChild
                            BlueFace.transform.GetChild(0).gameObject.SetActive(false);
                            BlueFace.transform.GetChild(1).gameObject.SetActive(true);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                            Crying.transform.GetChild(1).gameObject.SetActive(true);
                        }
                    }
                }
            }

            //Same as winner 1 but the other direction
            else if (winner == 2)
            {
                timer += Time.deltaTime;
                CameraShaker.intensity = 0;
                //GameCompleteCheck
                if (!GameCompletedEarlyCheck)
                {
                    ReportGameCompletedEarly();
                    GameCompletedEarlyCheck = true;
                }



                if (timer > 0.3)
                {
                    //Put Camera flash here

                    //Sets blue face to be active and sets correct face
                    RedFace.SetActive(true);
                    RedFace.transform.GetChild(0).gameObject.SetActive(true);
                    RedFace.transform.GetChild(1).gameObject.SetActive(false);
                    RedFace.transform.Rotate(0, 180, 0);

                    Crying.SetActive(true);
                    Crying.transform.GetChild(0).gameObject.SetActive(true);
                    Crying.transform.GetChild(1).gameObject.SetActive(false);
                    Crying.transform.Rotate(0, 180, 0);

                    //Checks if it is past the proper location
                    if (RedFace.transform.position.x > faceShift)
                    {
                        //Moves at specified rate
                        RedFace.transform.position += Vector3.left * Time.deltaTime;
                        Crying.transform.position += Vector3.right * Time.deltaTime;
                    }
                    else
                    {
                        //Ends movement loop
                        moveEnd = true;
                    }

                    if (moveEnd == true)
                    {
                        //Switches faces at specific times then ends scene
                        if (timer > 1)
                        {

                            //deactivate child Face.GetChild
                            RedFace.transform.GetChild(0).gameObject.SetActive(false);
                            RedFace.transform.GetChild(1).gameObject.SetActive(true);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                            Crying.transform.GetChild(1).gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
