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
        
        // Start is called before the first frame update
        void Start()
        {
        scaleTimeFactor = 4;
        scaleTarget = 1;
        scaleDiff = 0;
        sandLeft = 1000;
    }

        // Update is called once per frame
        void Update()
        {
            //if (gameObject.transform.localScale.x > scaleTarget.x)
           // {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + scaleDiff*Time.deltaTime*scaleTimeFactor, gameObject.transform.localScale.y + scaleDiff * Time.deltaTime*scaleTimeFactor, gameObject.transform.localScale.z + scaleDiff * Time.deltaTime * scaleTimeFactor);
           // }
           if(gameObject.transform.localScale.x <= scaleTarget)
            {
                scaleDiff = 0;
            }
        }
        public void eatSand(float sandAmount)
        {
             scaleDiff = -sandAmount/1000;
            scaleTarget = (gameObject.transform.localScale.x + scaleDiff);
        }
    }
}
