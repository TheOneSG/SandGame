using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team26 { 
    public class CameraShaker : MicrogameInputEvents
    {
        public static float intensity;
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
            
          }
    }       
}
