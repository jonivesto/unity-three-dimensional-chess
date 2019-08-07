using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Material boardBlack, boardWhite, pieceBlack, pieceWhite;
    public GameObject coordinateMarkerPrefab;
    public GameObject selection;

    internal CameraControls cameraControls;
    internal Piece[,,] positions;
    internal Transform[] levels;   
    internal Transform selectedLevel;
    internal ChessVariant layout;

    internal bool expanded = false;
    internal float camDistance;
    internal int boardSize, halfBoardSize;

    void Start()
    {
        cameraControls = Camera.main.gameObject.GetComponent<CameraControls>();

        // Init game 
        layout = new Raumschach();
        boardSize = layout.boardSize;
        halfBoardSize = boardSize / 2;
        positions = new Piece[boardSize, boardSize, boardSize];
        transform.position = new Vector3(-boardSize / 2f, -boardSize / 2f, -boardSize / 2f);

        DrawLevels();
        SetStartPositions();
    }

    public void MovePieceTo(int x, int y, int z)
    {

    }

    // Value null if out of bounds
    // Return FreeToCapture (Piece) if there is no piece
    public Piece GetPieceAt(int x, int y, int z)
    {
        Piece piece;

        try
        {           
            piece = positions[x, y, z];

            if (piece == null)
            {
                piece = new FreeToCapture();
            }
        }
        catch (IndexOutOfRangeException outOfBounds)
        {
            piece = null;
            throw outOfBounds;
        }

        return piece;
    }

    public void SetStartPositions()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                for (int k = 0; k < boardSize; k++)
                {
                    Piece p = layout.pieces[i, j, k];
                    if(p != null) SpawnPieceAt(p, i, j, k); 
                }
            }
        }
    }

    private void SpawnPieceAt(Piece piece, int x, int y, int z)
    {
        positions[x, y, z] = piece;

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        piece.instance = obj;
        obj.GetComponent<MeshRenderer>().material = (piece.color==Color.Black) ? pieceBlack : pieceWhite;
        obj.tag = "Piece";
        obj.transform.SetParent(levels[y]);
        obj.transform.localPosition = new Vector3(x + 0.5f, 1f, z + 0.5f);
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        obj.name = piece.color.ToString() + " " + piece.GetType().ToString();
        
    }

    internal void Expand(bool expanded)
    {
        selectedLevel = levels[Mathf.FloorToInt(halfBoardSize)];

        for (int i = 0; i < levels.Length; i++)
        {
            float levelY = i;

            if(expanded)
            {               
                if (i < halfBoardSize) levelY = -(boardSize - i * 3f); // Down
                else if (i > halfBoardSize) levelY = (i - 1) * 3f; // Up

                camDistance = boardSize * 2.4f;
            }
            else
            {
                camDistance = boardSize * 3.1f;
            }

            levels[i].localPosition = new Vector3(0, Mathf.Lerp(levels[i].localPosition.y, levelY, Time.deltaTime * 10f), 0);
        }
    }

    internal void Click(Collider collider)
    {
        if (collider == null) // Click empty area
        {
            // Clear all selections
            selection.SetActive(false);
        }
        else
        {
            // Click Piece
            if (collider.tag == "Piece")
            {
                
                // Piece clicked
                selection.SetActive(true);
                selection.transform.position = collider.transform.position;
                selection.transform.parent = collider.transform;
            }

            // Click Board
            else if(collider.tag == "Board"){

                string[] pos = collider.name.Split(',');

                int x = Convert.ToInt32(pos[0]);
                int y = Convert.ToInt32(pos[1]);
                int z = Convert.ToInt32(pos[2]);

                if (GetPieceAt(x, y, z) != null)
                {
                    // Slot with piece clicked
                    Piece clickedPiece = GetPieceAt(x, y, z);
                    print(Logic.Markup(x, y, z) + " " + clickedPiece.instance.name);
                    selection.SetActive(true);
                    selection.transform.position = clickedPiece.instance.transform.position;
                    selection.transform.parent = clickedPiece.instance.transform;
                }
                else
                {
                    // Empty slot clicked
                    print(Logic.Markup(x,y,z) + " No piece");
                }
            }

           
        }
    }

    private void DrawLevels()
    {
        levels = new Transform[boardSize];
        GameObject level;
        int slotCount = 1;

        for (int y = 0; y < boardSize; y++)
        {
            level = new GameObject("Level " + y);
            
            levels[y] = level.transform;
            level.transform.position = new Vector3(0, y, 0);
            level.transform.SetParent(transform);
            DrawLevelOutline(level);

            for (int x = 0; x < boardSize; x++)
            {

                for (int z = 0; z < boardSize; z++)
                {
                    slotCount++;
                    // Z coord markers
                    if (y == 0 && x == 0)
                    {
                        GameObject canvas = Instantiate(coordinateMarkerPrefab, level.transform);
                        canvas.tag = "Marker Z";
                        canvas.transform.localPosition = new Vector3(-0.5f, 0.5f, z + 0.5f);
                        canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Logic.ZIndexChar(z);
                        cameraControls.faceToCam.Add(canvas);
                    }

                    // X coord markers
                    if (y == 0 && z == 0)
                    {
                        GameObject canvas = Instantiate(coordinateMarkerPrefab, level.transform);
                        canvas.tag = "Marker X";
                        canvas.transform.localPosition = new Vector3(x + 0.5f, 0.5f, -0.5f);
                        canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Logic.XIndexChar(x);
                        cameraControls.faceToCam.Add(canvas);
                    }

                    // Board square object
                    GameObject slot = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    slot.tag = "Board";

                    slot.GetComponent<MeshRenderer>().material = (slotCount % 2 == 0)?boardBlack:boardWhite; 

                    slot.transform.localScale = new Vector3(0.1f,1f,0.1f);
                    slot.transform.position = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
                    slot.name = x + ", " + y + ", " + z;
                    slot.transform.SetParent(level.transform);
                }
            }
        }

        // Coord markers for levels
        for(int i = 0; i < levels.Length; i++)
        {
            GameObject canvas = Instantiate(coordinateMarkerPrefab, levels[i]);
            canvas.tag = "Marker Y";
            canvas.transform.localPosition = new Vector3(-0.5f, 0.5f, -0.5f);
            canvas.transform.GetChild(0).gameObject.GetComponent<Text>().text = ""+Logic.YIndexChar(i);
            cameraControls.faceToCam.Add(canvas);
        }

    }

    private void DrawLevelOutline(GameObject level)
    {
        LineRenderer line = level.AddComponent<LineRenderer>();
        //line.sortingLayerName = "OnTop";
        //line.sortingOrder = 5;
        line.positionCount = 4;
        Vector3 linePos =  new Vector3(0, 0.5f, 0);
        line.SetPosition(0, linePos);
        line.SetPosition(1, linePos + (Vector3.forward * boardSize));
        line.SetPosition(2, linePos + (Vector3.forward * boardSize) + (Vector3.right * boardSize));
        line.SetPosition(3, linePos + (Vector3.forward * boardSize) + (Vector3.right * boardSize) + (Vector3.back * boardSize));
        line.startWidth = 0.06f;
        line.endWidth = 0.06f;
        line.loop = true;
        line.useWorldSpace = false;
        line.material = pieceBlack;
        //line.numCornerVertices = 5;
    }

    public bool InBounds(int x)
    {
        if (x >= boardSize || x < 0) return false;

        return true;
    }
}
