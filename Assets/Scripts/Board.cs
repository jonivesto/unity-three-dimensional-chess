using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    int boardSize = 5;

    public Piece[,,] positions;
    public Transform[] levels;
    public GameObject selection;

    internal bool expanded = false;
    internal float camDistance;

    void Start()
    {
        positions = new Piece[boardSize, boardSize, boardSize];

        DrawLevels();

        transform.position = new Vector3(-boardSize / 2f, -boardSize / 2f, -boardSize / 2f);        
    }

    internal void Expand(bool expanded)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            float levelY;

            if(expanded)
            {
                levelY = i * 4f;
                camDistance = 13f;
            }
            else
            {
                levelY = i;
                camDistance = 16f;
            }

            levels[i].localPosition = new Vector3(0, Mathf.Lerp(levels[i].localPosition.y, levelY, Time.deltaTime * 10f), 0);
        }
    }

    void Update()
    {
        Expand(expanded);
    }

    internal void Click(Collider collider)
    {
        if (collider == null) // Click empty area
        {
            selection.SetActive(false);
        }
        else // Click piece
        {
            selection.SetActive(true);
            selection.transform.position = collider.transform.position;
        }
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
                    //Destroy(sphere.GetComponent<MeshFilter>());
                    //Destroy(sphere.GetComponent<MeshRenderer>());

                    sphere.transform.position = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
                    sphere.name = "(" + x + ", " + y + ", " + z + ")";
                    sphere.transform.SetParent(level.transform);
                }
            }
        }
    }

    
}
