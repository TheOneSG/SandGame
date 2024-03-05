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
    private float timer = 0;


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
            Face.transform.position = new Vector3(2.3f, 1.6f, -3);
            Crying.transform.position = new Vector3(-2.66f, -0.14f, -2);
        }

        if (winner == 1)
        {
            Face.transform.position = new Vector3(2.3f, 1.6f, -3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(winner == 1)
        {
            if (moveEnd == false)
            {
                Face.transform.position += Vector3.left * Time.deltaTime;   
            }
            else
            {
                moveEnd = true;
            }

            if(moveEnd == true)
            {
                timer += Time.deltaTime;
                if(timer > 1){
                    //deactivate child Face.GetChild
                    //Deactivate child crying.getchild
                }

                if(timer > 3)
                {
                    //End Scene
                }
            }
        }
        else if(winner == 2)
        {
            
        }

        
    }
}
