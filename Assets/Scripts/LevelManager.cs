using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic; // helps using things like dictionaries

public class LevelManager : MonoBehaviour
{

    // ----------- variables --------------- //

    [SerializeField] // makes private variables, public in unity
    private GameObject[] tilesPrefab;

    [SerializeField]
    private GameObject bluePortalPrefab;

    [SerializeField]
    private GameObject redPortalPrefab;

    private GridPoints blueSpawn, redSpawn;

    [SerializeField]
    private Transform map;

    public Dictionary<GridPoints, Tiles> GridT { get; set; }



    // ------- makes a property for tile size, this helps make this ----- //
    // ---- variable reusable and it's safe because it only returns. ---- //
    public float TS
    {
        get { return tilesPrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; } // this is to get the width of the tile object/
    }

    // ------------- Start is called before the first frame update ------------ //
    void Start()

    {
        tilePlacement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tilePlacement()
    {
        GridT = new Dictionary<GridPoints, Tiles>(); // store tiles into grid points now.

        string[] tileMap = ReadTextFile();

        int mapX = tileMap[0].ToCharArray().Length;
        int mapY = tileMap.Length;

        Vector3 maxTiles = Vector3.zero;


        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(90.0f, Screen.height));

        // ----------- this is to place the tiles along the x-axis and the y-axis --------- //

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = tileMap[y].ToCharArray();

            for(int x = 0; x < mapX; x++)
            {
                Positioning(newTiles[x].ToString(), x, y, startPosition);
            }
        }
        maxTiles = GridT[new GridPoints(mapX - 1, mapY - 1)].transform.position;

        Tiles.tilesSpawn(new Vector3(maxTiles.x + TS, maxTiles.y - TS));

        portalSpawn();
    }

    private void Positioning(string tileType, int x, int y, Vector3 startPosition)
    {
        int tileIndex = int.Parse(tileType); // this convers string into an int.

        Tiles newTiles = Instantiate(tilesPrefab[tileIndex]).GetComponent<Tiles>(); // making a reference.

        newTiles.Setup(new GridPoints(x, y), new Vector3(startPosition.x + (TS * x), startPosition.y - (TS * y), 0), map);

        GridT.Add(new GridPoints(x, y), newTiles); // every single tile in the game is added to the tile dictionary.
    }

    private string[] ReadTextFile()
    {
        TextAsset data = Resources.Load("Level1") as TextAsset;
        string tmpData = data.text.Replace(Environment.NewLine, string.Empty);
        return tmpData.Split('-');
    }

    private void portalSpawn()
    {
        blueSpawn = new GridPoints(0, 1);
        Instantiate(bluePortalPrefab,
                    GridT[blueSpawn].GetComponent<Tiles>().worldPosition,
                    Quaternion.identity);

        redSpawn = new GridPoints(18, 7);
        Instantiate(redPortalPrefab, 
                    GridT[redSpawn].GetComponent<Tiles>().worldPosition, 
                    Quaternion.identity);

    }

    private void testDictonary()
    {
        Dictionary<string, int> test = new Dictionary<string, int>(); // remember to store memory allocated for the dictionary.
        test.Add("Age", 23);
        test.Add("Strength", 200);
        test.Add("Health", 100);

        Debug.Log("My Age is " + test["Age"]);
        Debug.Log("My Strength is " + test["Strength"]);
        Debug.Log("My Health is " + test["Health"]);
    }


}
