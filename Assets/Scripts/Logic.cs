using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic
{
    public bool whitesTurn = true;
    

    public void EndTurn()
    {
        whitesTurn = !whitesTurn;
    }

    public bool Check()
    {
        return false;
    }

    public bool CheckMate()
    {
        return false;
    }
}
