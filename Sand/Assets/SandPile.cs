using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SandPile : MonoBehaviour
{
    public float quantity = 100;
    public float decreaseAmount = 2;
    public float decreasePenalty = 1;
    private float lastButtonPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastButtonPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (quantity > 0)
        {
            if (Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.V))
            {
                quantity -= decreaseAmount - decreasePenalty;
                lastButtonPressed = 0;
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    if (lastButtonPressed == 2)
                    {
                        quantity -= decreaseAmount;
                    }
                    else
                    {
                        quantity -= decreaseAmount - decreasePenalty;
                    }
                    lastButtonPressed = 1;
                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (lastButtonPressed == 1)
                    {
                        quantity -= decreaseAmount;
                    }
                    else
                    {
                        quantity -= decreaseAmount - decreasePenalty;
                    }
                    lastButtonPressed = 2;
                }

            }
            transform.localScale = new Vector3(4, 1 * (quantity / 100), 4);
        }
        else
        {
            //Scenechange to victory
        }
    }

}
