using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;                                //List of Prefabs
    public float zSpawn = 0;                                        //Spawn Position (Basically, add tilelength (30 units) every time it spawns in 0,30,60,90, etc)
    public float tileLength = 30;                                   //Hard Coded cuz
    public int numberOfTiles = 5;                                   //Total Active Tiles, or How many tiles the trail is after they've spawned
    private List<GameObject> activeTiles = new List<GameObject>();  //TheEver Evolving List Of Currently Appearing Tiles

    public Transform playerTransform;                               //Where the Player At;

    void Start()
    {//Lay The Tiles Out, If it's the first lain tile, make it a Tile[0], else a random one from the tilePrefabs[];
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
            
    }
    void Update()
    {
        TileCheck();

    }

    private void TileCheck()
    {
        if (playerTransform.position.z - 30 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {

        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
