using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team26;
namespace team26
{
    public class SandAudioManager : MonoBehaviour
    {
        public AudioClip[] sandcrunches;
        public GameObject sandSpeaker;
        private float timer;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if(timer > .1f)
            {
                sandSpeaker.GetComponent<AudioSource>().Stop();

            }
        }

        public void PlaySandEatingSound()
        {
            timer = 0;
            if (!sandSpeaker.GetComponent<AudioSource>().isPlaying)
            {
                sandSpeaker.GetComponent<AudioSource>().clip = sandcrunches[Random.Range(0, sandcrunches.Length - 1)];
                sandSpeaker.GetComponent<AudioSource>().Play();
            }
        }


    }
}