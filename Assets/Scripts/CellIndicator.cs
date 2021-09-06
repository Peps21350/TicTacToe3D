using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellIndicator : MonoBehaviour
{
    public CellStatus statusCell;
    public int numberCell = 0;
    
}
public enum CellStatus
{
    None = 0,
    X = 1,
    O = 2
}



