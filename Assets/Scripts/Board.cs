using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    int boardSize = 5;

    public Piece[,,] positions;
    public Transform[] levels;


    void Start()
    {
        positions = new Piece[boardSize, boardSize, boardSize];

        DrawLevels();

        transform.position = new Vector3(-boardSize / 2f, -boardSize / 2f, -boardSize / 2f);        
    }

    private void DrawLevels()
    {
        levels = new Transform[boardSize];
        GameObject level;

        for (int y = 0; y < boardSize; y++)
        {
            level = new GameObject("Level " + y);
            levels[y] = level.transform;
            level.transform.position = new Vector3(0, y, 0);
            level.transform.SetParent(transform);

            for (int x = 0; x < boardSize; x++)
            {
                for (int z = 0; z < boardSize; z++)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
                    sphere.name = "(" + x + ", " + y + ", " + z + ")";
                    sphere.transform.SetParent(level.transform);
                }
            }
        }
    }
}
