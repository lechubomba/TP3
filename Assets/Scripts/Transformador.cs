using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformador : MonoBehaviour
{

    public GameObject character1;
    public GameObject character2;

    private bool isTransformed = false;
    private bool hasTransformed = false;
    public Transform characterTransform;
    void Start()
    {
        // Disable the second character at start
        character2.SetActive(false);
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T) && !hasTransformed)
        {
            if (!isTransformed)
            {
                // Enable the second character and disable the first one
                gameObject.SetActive(false);
                character2.SetActive(true);
                isTransformed = true;
            }
            else
            {
                // Enable the first character and disable the second one
                gameObject.SetActive(true);
                character2.SetActive(false);
                isTransformed = false;
            }
            hasTransformed = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && hasTransformed)
        {
            // Allow player to transform back if they have already transformed once
            if (isTransformed)
            {
                character1.SetActive(true);
                character2.SetActive(false);
                isTransformed = false;
            }
            else
            {
                character1.SetActive(false);
                character2.SetActive(true);
                isTransformed = true;
            }
        }

    }



}
