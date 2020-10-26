using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Placing : MonoBehaviour
{
    [Header("CharacterType")]
    [SerializeField]
    GameObject player;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        foreach (var touch in Input.touches)
        {
            if (time >= 2.0f)
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 worldPoint = new Vector2(world.x, world.y);

                if (GetComponent<BoxCollider2D>().OverlapPoint(worldPoint))
                {
                    Instantiate(player, transform.position, quaternion.identity);
                }
                time = 0.0f;
            }
        }
    }
}
