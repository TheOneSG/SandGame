using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace team26
{
    public class PlayerWinScreen : MicrogameEvents
    {
        // Start is called before the first frame update

        //default p1 2.3, 1.6, -3
        //End -4.6, 1.6, -3
        public GameObject Crying;
        //default  - 2.66, -0.14, -2
        public GameObject RedFace;
        public GameObject BlueFace;
        public float winner = 0;
        public GameObject crySpeaker;
        public GameObject cheerSpeaker;


        private bool gamendreported;

        private bool moveEnd = false;

        public float timer = 0;
        public int speed = 4;
        public float defaultX = 3f;
        public float defaultX2 = 2.66f;

        private bool winnerDecided;

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
            if (RedFace == null)
            {
                //Debug.LogError("Empty Face");
            }

            if (Crying == null)
            {
               // Debug.LogError("Empty Crying");
            }

            winnerDecided = false;
            moveEnd = false;

            RedFace.SetActive(false);
            BlueFace.SetActive(false);
            Crying.SetActive(false);


        }

        // Update is called once per frame
        void Update()
        {
            //Checks if the winner has been decided
            if (winnerDecided == false)
            {
                //Sets default positions for win player 1
                if (winner == 1)
                {
                    CameraShaker.intensity = 0;
                    //Activates Faces
                    //Face.SetActive(true);
                    //Crying.SetActive(true);

                    //Places faces
                    BlueFace.transform.position = new Vector3(defaultX, 1.6f, -3);
                    Crying.transform.position = new Vector3(defaultX2, -0.14f, -2);


                    //Runs Victory animation
                    winnerDecided = true;
                }

                //Sets default positions for win player 2
                if (winner == 2)
                {
                    CameraShaker.intensity = 0;
                    //Activates faces
                    //Face.SetActive(true);
                    //Crying.SetActive(true);

                    //Places faces
                    RedFace.transform.position = new Vector3(-defaultX, 1.6f, -3);
                    Crying.transform.position = new Vector3(-defaultX2, -0.14f, -2);

                    //Runs victory animation
                    winnerDecided = true;
                }
            }

            //Runs this when winner has been decided
            else
            {
                if (!gamendreported) {
                    gamendreported = true;
                    crySpeaker.GetComponent<AudioSource>().Play();
                    cheerSpeaker.GetComponent<AudioSource>().Play();
                    ReportGameCompletedEarly();
                    CameraShaker.intensity = 0;
                }
                

                if (winner == 1)
                {
                    //Checks if it is past the proper location
                    if (BlueFace.transform.position.x > -defaultX)
                    {
                        //Moves at specified rate
                        BlueFace.transform.position += Vector3.left * Time.deltaTime * speed;
                    }
                    else
                    {
                        //Ends movement loop
                        moveEnd = true;
                        BlueFace.SetActive(true);
                        Crying.SetActive(true);
                    }

                    if (moveEnd == true)
                    {
                        //Switches faces at specific times then ends scene
                        timer += Time.deltaTime;
                        if (timer > 0.5)
                        {

                            //deactivate child Face.GetChild
                            BlueFace.transform.GetChild(0).gameObject.SetActive(false);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                        }

                        if (timer > 2)
                        {
                            //End Scene
                            //Debug.Log("Scene End");
                        }
                    }
                }

                //Same as winner 1 but the other direction
                else if (winner == 2)
                {
                    if (RedFace.transform.position.x < defaultX)
                    {
                        RedFace.transform.position += Vector3.right *Time.deltaTime *speed;
                    }
                    else
                    {
                        moveEnd = true;
                        RedFace.SetActive(true);
                        Crying.SetActive(true);
                    }

                    if (moveEnd == true)
                    {
                        timer += Time.deltaTime;
                        if (timer > 0.3)
                        {

                            //deactivate child Face.GetChild
                            RedFace.transform.GetChild(0).gameObject.SetActive(false);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                }
                
                
            }

        }
    }
}
