using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    bool dropped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!dropped)
        {
            bool pickedUp = false;
            foreach (var touch in Input.touches)
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 worldPoint = new Vector2(world.x, world.y);
                transform.position = worldPoint;
                pickedUp = true;
            }
            if (!pickedUp)
            {
                dropped = true;
            }
        }
    }
}
