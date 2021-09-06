using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;


public class CreatingField : MonoBehaviour
{
    [SerializeField] private GameObject[] imageField; // first for 3d
    [SerializeField] private GameObject[] gameParent; // first for 3d
    [HideInInspector] public GameObject[] selectCell;
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private GridLayoutGroup[] gridLayout;
    [SerializeField] private GameObject canvas;
    [HideInInspector] public int cellsCount;
    private const float _ScaleGrid = 10f;
    private int numberObject;

    
    public  void CreateField(int mapSize)
    {
        cellsCount = mapSize * mapSize;
        selectCell = new GameObject[cellsCount];

        GameMechanic.SizeSide = mapSize;
        gameMechanic.SetMarkedCell();
        
        if (gameMechanic.is3D == true)
        {
            numberObject = 0;
            gridLayout[numberObject].enabled = true;
            gridLayout[numberObject].constraintCount = mapSize;
            gridLayout[numberObject].transform.localScale = Vector3.one  / mapSize * _ScaleGrid;
            canvas.SetActive(false);
            for (int i = 0; i < cellsCount; i++)
            {
                selectCell[i] = Instantiate(imageField[numberObject], gameParent[numberObject].transform);
                selectCell[i].transform.localScale = new Vector3(30f, 30f, 30f);
                selectCell[i].GetComponent<CellIndicator>().numberCell = i;
                int indexCache = i;
                selectCell[i].GetComponent<Button>().onClick.AddListener(() => gameMechanic.ChangeImage(indexCache));
            }
        }

        else
        {
            numberObject = 1;
            gridLayout[numberObject].enabled = true;
            gridLayout[numberObject].constraintCount = mapSize;
            gridLayout[numberObject].transform.localScale = Vector3.one  / mapSize * _ScaleGrid;
            for (int i = 0; i < cellsCount; i++)
            {
                selectCell[i] = Instantiate(imageField[numberObject], gameParent[numberObject].transform);
                selectCell[i].GetComponent<CellIndicator>().numberCell = i;
                int indexCache = i;
                selectCell[i].GetComponent<Button>().onClick.AddListener(() => gameMechanic.ChangeImage(indexCache));
            }
        }

        StartCoroutine(WaitFor1Frame());
        
        IEnumerator WaitFor1Frame()
        {
            yield return new WaitForEndOfFrame();
            gridLayout[numberObject].enabled = false;
        }
    }
    
    
    
}