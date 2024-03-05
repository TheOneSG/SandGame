using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerWinScreen : MonoBehaviour
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

    public float defaultX = 3f;
    public float defaultX2 = 2.66f;


    void Start()
    {
        if(Face == null)
        {
            Debug.Log("empty Face");
        }

        if(Crying == null)
        {
            Debug.Log("empty Crying");
        }

        

        moveEnd = false;

        if(winner == 1)
        {
            Face.transform.position = new Vector3(defaultX, 1.6f, -3);
            Crying.transform.position = new Vector3(defaultX2, -0.14f, -2);
        }

        if (winner == 2)
        {
            Face.transform.position = new Vector3(-defaultX, 1.6f, -3);
            Crying.transform.position = new Vector3(-defaultX2, -0.14f, -2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(winner == 1)
        {
            if (Face.transform.position.x > -defaultX)
            {
                Face.transform.position += Vector3.left * Time.deltaTime * 5;   
            }
            else
            {
                moveEnd = true;
            }

            if(moveEnd == true)
            {
                timer += Time.deltaTime;
                if(timer > 0.5){

                    //deactivate child Face.GetChild
                    Face.transform.GetChild(0).gameObject.SetActive(false);

                    //Deactivate child crying.getchild
                    Crying.transform.GetChild(0).gameObject.SetActive(false);
                }

                if(timer > 2)
                {
                    //End Scene
                    Debug.Log("Scene End");
                }
            }
        }
        else if(winner == 2)
        {
            
        }

        
    }
}
