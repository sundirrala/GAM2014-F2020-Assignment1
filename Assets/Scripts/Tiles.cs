using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public GridPoints GridPos { get; set; }

    public Vector2 worldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    private static float xMax;
    private static float yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(GridPoints gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPos = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
    }

    public static void tilesSpawn(Vector3 maxTiles)
    {
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));

        yMax = maxTiles.x - worldPos.x;
        yMax = maxTiles.y - worldPos.y;
    }
}
