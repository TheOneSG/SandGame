using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace team26
{
    public class PlayerWinScreen : MicrogameInputEvents
    {
        // Start is called before the first frame update

        public GameObject Face;
        //default p1 2.3, 1.6, -3
        //End -4.6, 1.6, -3
        public GameObject Crying;
        //default  - 2.66, -0.14, -2
        public float winner = 0;

        private bool moveEnd = false;

        public float timer = 0;
        public int speed = 8;
        public float defaultX = 3f;
        public float defaultX2 = 2.66f;

        private bool winnerDecided;


        void Start()
        {
            if (Face == null)
            {
                Debug.Log("empty Face");
            }

            if (Crying == null)
            {
                Debug.Log("empty Crying");
            }

            winnerDecided = false;
            moveEnd = false;

            Face.SetActive(false);
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
                    //Activates Faces
                    Face.SetActive(true);
                    Crying.SetActive(true);

                    //Places faces
                    Face.transform.position = new Vector3(defaultX, 1.6f, -3);
                    Crying.transform.position = new Vector3(defaultX2, -0.14f, -2);

                    //Runs Victory animation
                    winnerDecided = true;
                }

                //Sets default positions for win player 2
                if (winner == 2)
                {
                    //Activates faces
                    Face.SetActive(true);
                    Crying.SetActive(true);

                    //Places faces
                    Face.transform.position = new Vector3(-defaultX, 1.6f, -3);
                    Crying.transform.position = new Vector3(-defaultX2, -0.14f, -2);

                    //Runs victory animation
                    winnerDecided = true;
                }
            }

            //Runs this when winner has been decided
            else
            {
                if (winner == 1)
                {
                    //Checks if it is past the proper location
                    if (Face.transform.position.x > -defaultX)
                    {
                        //Moves at specified rate
                        Face.transform.position += Vector3.left * Time.deltaTime * speed;
                    }
                    else
                    {
                        //Ends movement loop
                        moveEnd = true;
                    }

                    if (moveEnd == true)
                    {
                        //Switches faces at specific times then ends scene
                        timer += Time.deltaTime;
                        if (timer > 0.5)
                        {

                            //deactivate child Face.GetChild
                            Face.transform.GetChild(0).gameObject.SetActive(false);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                        }

                        if (timer > 2)
                        {
                            //End Scene
                            Debug.Log("Scene End");
                        }
                    }
                }

                //Same as winner 1 but the other direction
                else if (winner == 2)
                {
                    if (Face.transform.position.x < defaultX)
                    {
                        Face.transform.position += Vector3.right * Time.deltaTime * speed;
                    }
                    else
                    {
                        moveEnd = true;
                    }

                    if (moveEnd == true)
                    {
                        timer += Time.deltaTime;
                        if (timer > 0.3)
                        {

                            //deactivate child Face.GetChild
                            Face.transform.GetChild(0).gameObject.SetActive(false);

                            //Deactivate child crying.getchild
                            Crying.transform.GetChild(0).gameObject.SetActive(false);
                        }

                        if (timer > 2)
                        {
                            //End Scene
                            ReportGameCompletedEarly();
                            Debug.Log("Scene End");
                        }
                    }
                }
            }

        }
    }
}
