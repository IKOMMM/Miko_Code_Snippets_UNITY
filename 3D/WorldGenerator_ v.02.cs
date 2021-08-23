using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    #region Variables
    //[Header("Setup Rectangular Edges Coordinates")]  
    //Setup Rectangular Value
    public static int xMin = -5, xMax = 5, zMin = -5, zMax = 5; 
    int coordinateX, coordinateZ; //Coordinates to spawn
    int xMinEdge = xMin - 1; int xMaxEdge = xMax + 1; int zMinEdge = zMin - 1; int zMaxEdge = zMax + 1; //Edge coordinates

    //Generate values
    GameObject tileToSpawn;
    Vector3 generatedPosition;//Vector to generate elements
    //Spawnpoint Tile
    public List<GameObject> tilesSpawnPointSpawnPool;
    public List<GameObject> tilesCavesPointSpawnPool;
    public List<GameObject> tilesOasisPointSpawnPool;
    //Fill Tiles
    public List<GameObject> tilesInsideRectangleSpawnPool;
    //Edges Tiles
    public List<GameObject> tilesTopEdgeSpawnPool;
    public List<GameObject> tilesBottomEdgeSpawnPool;
    public List<GameObject> tilesRightEdgeSpawnPool;
    public List<GameObject> tilesLeftEdgeSpawnPool;
    //Corner Tiles
    public List<GameObject> leftTopCornerSpawnPool;
    public List<GameObject> rightTopCornerSpawnPool;
    public List<GameObject> leftBottomCornerSpawnPool;
    public List<GameObject> rightBottomCornerSpawnPool;
    public Transform tilesStartMapSpawnLocation;//Place to spawn start map tiles  
    int randomTile;
    #endregion

    public void Awake()
    {
        MediumMapGenerator();
    }   

    #region WorldGenerator
    //================== Generator ==================

    public void MediumMapGenerator()
    {
        FillRectangle();
        GenerateEdgeCorners();
        GenerateRectangleEdge();
    }

    //TODO: Fill works only with spawn point, needs to upgrade
    public void FillRectangle()
    {
        for (coordinateZ = zMin; coordinateZ <= zMax; coordinateZ++)
        {
            //Full fill
            for (coordinateX = xMin; coordinateX <= xMax; coordinateX++)
            {
                if (coordinateX == 0 & coordinateZ == 0)
                {
                    
                    generatedPosition = new Vector3(coordinateX * 10, 0, coordinateZ * 10);                   
                    randomTile = Random.Range(0, tilesSpawnPointSpawnPool.Count);
                    tileToSpawn = tilesSpawnPointSpawnPool[randomTile];
                    TilesInstantiation();
                }
                else if (coordinateX == 2 & coordinateZ == 2)
                {
                    generatedPosition = new Vector3(coordinateX * 10, 0, coordinateZ * 10);
                    randomTile = Random.Range(0, tilesSpawnPointSpawnPool.Count);
                    tileToSpawn = tilesOasisPointSpawnPool[randomTile];
                    TilesInstantiation();
                }
                else if (coordinateX == -2 & coordinateZ == -2)
                {
                    generatedPosition = new Vector3(coordinateX * 10, 0, coordinateZ * 10);
                    randomTile = Random.Range(0, tilesSpawnPointSpawnPool.Count);
                    tileToSpawn = tilesCavesPointSpawnPool[randomTile];
                    TilesInstantiation();
                }
                else
                {
                    TilesSpawner();
                }                
            }
        }  
    }

    public void GenerateRectangleEdge()
    {        
        //TopEdge
        for (coordinateX = zMin; coordinateX <= xMax; coordinateX++)
        {
            //Take random coordinates to spawn
            generatedPosition = new Vector3(coordinateX * 10, 0, zMaxEdge * 10);
            //Random prefab to generate
            randomTile = Random.Range(0, tilesTopEdgeSpawnPool.Count);
            tileToSpawn = tilesTopEdgeSpawnPool[randomTile];
            TilesInstantiation();
        }      
        
        //BottomEdge
        for (coordinateX = zMin; coordinateX <= xMax; coordinateX++)
        {
            //Take random coordinates to spawn
            generatedPosition = new Vector3(coordinateX * 10, 0, zMinEdge * 10);
            //Random prefab to generate
            randomTile = Random.Range(0, tilesBottomEdgeSpawnPool.Count);
            tileToSpawn = tilesBottomEdgeSpawnPool[randomTile];
            TilesInstantiation();
        }
        
        //RightEdge
        for (coordinateZ = xMin; coordinateZ <= zMax; coordinateZ++)
        {
            //Take random coordinates to spawn
            generatedPosition = new Vector3(xMaxEdge * 10, 0, coordinateZ * 10);
            //Random prefab to generate
            randomTile = Random.Range(0, tilesRightEdgeSpawnPool.Count);
            tileToSpawn = tilesRightEdgeSpawnPool[randomTile];
            TilesInstantiation(); 
        }
        
        //LeftEdge
        for (coordinateZ = xMin; coordinateZ <= zMax; coordinateZ++)
        {
            //Take random coordinates to spawn
            generatedPosition = new Vector3(xMinEdge * 10, 0, coordinateZ * 10);
            //Random prefab to generate
            randomTile = Random.Range(0, tilesLeftEdgeSpawnPool.Count);
            tileToSpawn = tilesLeftEdgeSpawnPool[randomTile];
            TilesInstantiation();
        }     
    }

    public void GenerateEdgeCorners()
    {
        //Top-Left Corner
        generatedPosition = new Vector3(xMaxEdge * 10, 0, zMinEdge * 10);
        randomTile = Random.Range(0, leftTopCornerSpawnPool.Count);
        tileToSpawn = leftTopCornerSpawnPool[randomTile];
        TilesInstantiation();

        //Top-Right
        generatedPosition = new Vector3(xMaxEdge * 10, 0, zMaxEdge * 10);
        randomTile = Random.Range(0, rightTopCornerSpawnPool.Count);
        tileToSpawn = rightTopCornerSpawnPool[randomTile];
        TilesInstantiation();

        //Bottom-Left        
        generatedPosition = new Vector3(xMinEdge * 10, 0, zMinEdge * 10);
        randomTile = Random.Range(0, leftBottomCornerSpawnPool.Count);
        tileToSpawn = leftBottomCornerSpawnPool[randomTile];
        TilesInstantiation();

        //Bottom-Right
        generatedPosition = new Vector3(xMinEdge * 10, 0, zMaxEdge * 10);
        randomTile = Random.Range(0, rightBottomCornerSpawnPool.Count);
        tileToSpawn = rightBottomCornerSpawnPool[randomTile];
        TilesInstantiation();        
    }

    void TilesSpawner()
    {
        //Take random coordinates to spawn
        generatedPosition = new Vector3(coordinateX * 10, 0, coordinateZ * 10);
        //Random prefab to generate
        randomTile = Random.Range(0, tilesInsideRectangleSpawnPool.Count);
        tileToSpawn = tilesInsideRectangleSpawnPool[randomTile];
        TilesInstantiation();
    }

    void TilesInstantiation()
    {
        //Instantiate prefabs from pool
        GameObject parent = Instantiate(tileToSpawn, generatedPosition, tileToSpawn.transform.rotation);
        parent.transform.parent = tilesStartMapSpawnLocation;
    }
    #endregion
}
