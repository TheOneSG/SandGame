using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team26
{
    public class CamFocusShaker : MicrogameInputEvents
    {
        private float timer =0;
        private Vector3 startpos;
        private void Start()
        {
            startpos = transform.position;
        }
        // Start is called before the first frame update
        private void Update()
        {
            //Debug.Log(CameraShaker.intensity);
            
            if (CameraShaker.intensity > 0)
            {
                timer += Time.deltaTime;
                if (timer > Mathf.Clamp(2/CameraShaker.intensity,.01f,0.6f))
                {
                    if(CameraShaker.intensity > 0)
                    {
                        transform.position = new Vector3(Random.Range(startpos.x-.5f, startpos.x+ .5f), Random.Range(startpos.y -0.2f, startpos.y+.2f), startpos.z);
                    }
                    if (CameraShaker.intensity > 10)
                    {

                        transform.position = new Vector3(Random.Range(startpos.x - 1f, startpos.x+1f), Random.Range(startpos.y -0.4f, startpos.y+.4f), startpos.z);
                    }
                    if (CameraShaker.intensity > 40)
                    {
                        transform.position = new Vector3(Random.Range(startpos.x - 1.5f, startpos.x +1.5f), Random.Range(startpos.y- 0.6f, startpos.y +.6f), startpos.z);
                    }
                    if (CameraShaker.intensity > 80)
                    {
                        transform.position = new Vector3(Random.Range(startpos.x - 2f, startpos.x +2f), Random.Range(startpos.y- 0.8f, startpos.y+ .8f), startpos.z);
                    }
                    timer = 0;
                }
            }
            else
            {
                transform.position = startpos;
            }

        }
    }
}

