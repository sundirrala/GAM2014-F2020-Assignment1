using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{ 
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        if(tag == "arrow")
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
