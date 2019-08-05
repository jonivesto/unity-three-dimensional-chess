using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    int boardSize = 5;

    public GameObject coordinateMarkerPrefab;
    public GameObject selection;

    internal CameraControls cameraControls;
    internal Piece[,,] positions;
    internal Transform[] levels;   
    internal Transform selectedLevel;

    internal bool expanded = false;
    internal float camDistance;
    internal int half;

    void Start()
    {
        cameraControls = Camera.main.gameObject.GetComponent<CameraControls>();
        half = boardSize / 2;
        positions = new Piece[boardSize, boardSize, boardSize];
        DrawLevels();
        transform.position = new Vector3(-boardSize / 2f, -boardSize / 2f, -boardSize / 2f);        
    }

    public void SpawnPieceAt()
    {

    }

    public void MovePieceTo(int x, int y, int z)
    {

    }

    // Value null if there is no piece
    public Piece GetPieceAt()
    {
        return null;
    }

    public void SetStartPositions()
    {

    }

    internal void Expand(bool expanded)
    {
        selectedLevel = levels[Mathf.FloorToInt(half)];

        for (int i = 0; i < levels.Length; i++)
        {
            float levelY = i;

            if(expanded)
            {               
                if (i < half) levelY = -(boardSize - i * 3f); // Down
                else if (i > half) levelY = (i - 1) * 3f; // Up

                camDistance = boardSize * 2.1f;
            }
            else
            {
                camDistance = boardSize * 2.7f;
            }

            levels[i].localPosition = new Vector3(0, Mathf.Lerp(levels[i].localPosition.y, levelY, Time.deltaTime * 10f), 0);
        }
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
            selection.transform.parent = collider.transform;
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

                    // Z coord markers
                    if (y == 0 && x == 0)
                    {
                        GameObject canvas = Instantiate(coordinateMarkerPrefab, level.transform);
                        canvas.transform.localPosition = new Vector3(-0.5f, 0.5f, z + 0.5f);
                        canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Logic.ZIndexChar(z);
                        cameraControls.faceToCam.Add(canvas);
                    }

                    // X coord markers
                    if (y == 0 && z == 0)
                    {
                        GameObject canvas = Instantiate(coordinateMarkerPrefab, level.transform);
                        canvas.transform.localPosition = new Vector3(x + 0.5f, 0.5f, -0.5f);
                        canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Logic.XIndexChar(x);
                        cameraControls.faceToCam.Add(canvas);
                    }

                    GameObject slot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    //Destroy(slot.GetComponent<MeshFilter>());
                    //Destroy(slot.GetComponent<MeshRenderer>());

                    slot.transform.position = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
                    slot.name = "(" + x + ", " + y + ", " + z + ")";
                    slot.transform.SetParent(level.transform);
                }
            }
        }

        // Coord markers for levels
        for(int i = 0; i < levels.Length; i++)
        {
            GameObject canvas = Instantiate(coordinateMarkerPrefab, levels[i]);
            canvas.transform.localPosition = new Vector3(-0.5f, 0.5f, -0.5f);
            canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = ""+Logic.YIndexChar(i);
            cameraControls.faceToCam.Add(canvas);
        }

    }

}
