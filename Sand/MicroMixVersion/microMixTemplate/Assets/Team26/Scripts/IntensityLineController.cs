using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team26
{
    public class IntensityLineController : MicrogameInputEvents
    {
        public float intensityBreakpoint;
        // Start is called before the first frame update
        public GameObject myParticleSys;
        void Start()
        {
            myParticleSys.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(CameraShaker.intensity > intensityBreakpoint)
            {
                myParticleSys.SetActive(true);
            }else
            if (CameraShaker.intensity < intensityBreakpoint)
            {
                myParticleSys.SetActive(false);
            }
        }
        protected override void OnTimesUp()
        {
            myParticleSys.SetActive(false);
        }
    }
}

