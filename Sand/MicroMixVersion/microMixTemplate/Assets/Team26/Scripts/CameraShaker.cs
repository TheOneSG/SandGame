using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team26 { 
    public class CameraShaker : MicrogameInputEvents
    {
        public static float intensity;
        public GameObject camfocus;
        private float differenceX;
        private float differenceY;
        
        
       // Start is called before the first frame update
         void Start()
         {
        
         }

    // Update is called once per frame
          void Update()
          {
            if(intensity > 0)
            {
                intensity -= Time.deltaTime*4;
            }
           
                differenceX = camfocus.transform.position.x - transform.position.x;
                differenceY = camfocus.transform.position.y - transform.position.y;
                transform.position = new Vector3(transform.position.x + differenceX * 6 * Time.deltaTime, transform.position.y + differenceY * 6 * Time.deltaTime, transform.position.z);
           
        
          }
    }       
}
