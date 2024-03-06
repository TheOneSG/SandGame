using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team26;

namespace team26
{
    public class Sandcastle : MicrogameInputEvents
    {
        public float scaleTimeFactor;
        private float scaleTarget;
        private float scaleDiff;
        public float sandLeft;

        public GameObject[] castleStateObjects;
        
        // Start is called before the first frame update
        void Start()
        {
        scaleTimeFactor = 4;
        scaleTarget = 1;
        scaleDiff = 0;
        sandLeft = 100;
        foreach (GameObject i in castleStateObjects){
                i.SetActive(false);
            } 
            
            castleStateObjects[0].SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            
            //if (gameObject.transform.localScale.x > scaleTarget.x)
            // {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + scaleDiff * Time.deltaTime * scaleTimeFactor, gameObject.transform.localScale.y + scaleDiff * Time.deltaTime * scaleTimeFactor, gameObject.transform.localScale.z + scaleDiff * Time.deltaTime * scaleTimeFactor);
            // }
            if (gameObject.transform.localScale.x <= scaleTarget)
            {
                scaleDiff = 0;
            }

            if (sandLeft < 0)
            {
                Debug.Log("castlechange5");
                castleStateObjects[4].SetActive(false);

            }
            else if (sandLeft < 20)
            {
                Debug.Log("castlechange4");
                castleStateObjects[3].SetActive(false);
                castleStateObjects[4].SetActive(true);
            }
            else if (sandLeft < 40)
            {
                Debug.Log("castlechange3");
                castleStateObjects[2].SetActive(false);
                castleStateObjects[3].SetActive(true);
            }
            else if (sandLeft < 60)
            {
                Debug.Log("castlechange2");
                castleStateObjects[1].SetActive(false);
                castleStateObjects[2].SetActive(true);

            }
            else if (sandLeft < 80)
            {
                Debug.Log("castlechange1");
                castleStateObjects[0].SetActive(false);
                castleStateObjects[1].SetActive(true);

            }
            

        }
        public void eatSand(float sandAmount)
        {
            scaleDiff = -sandAmount/50;
            scaleTarget = (gameObject.transform.localScale.x + scaleDiff);
            sandLeft -= sandAmount;
        }
    }
}
