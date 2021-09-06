using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameMechanic : MonoBehaviour
{
    [HideInInspector] public int player;
    [HideInInspector] public int pc;
    [SerializeField] private CreatingField creatingField;
    [SerializeField] private Sprite[] spritesObjects;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject rawImageForGame;
    [SerializeField] private GameObject rawCubeFor3DGame;
    [SerializeField] private GameUI gameUI;
    [HideInInspector] public bool is3D = false;
    private bool _gameOver = false;
    
    public bool playerTurn = true;
    [HideInInspector] public int numberSprite;
    public static int SizeSide;

    public CellStatus[,] MarkedCellMass;
    private CellStatus _whoMarkedCell;

    private bool _playerWin = false;
    private bool _pcWin = false;
    [HideInInspector] public bool isDraw = false;
    
    private int _stateWinPC = 0;
    private int _stateWinPlayer = 0;
    private int _draw = 0;

    private void Start()
    {
        player = 1;
        pc = 1;
    }

    
    public void SetMarkedCell()
    {
        MarkedCellMass = new CellStatus[SizeSide, SizeSide];
        
        for (int i = 0; i < SizeSide; i++)
        {
            for (int j = 0; j < SizeSide; j++)
            {
                MarkedCellMass[i, j] = CellStatus.None;
            }
        }
    }

    
    public void ChangeImage(int numberCell)
    {
        int firstIndex = 0;
        int secondIndex = 0;
        

        if (creatingField.selectCell[numberCell].GetComponent<CellIndicator>().statusCell == CellStatus.None)
        {
            numberSprite = playerTurn == true ? player : pc;
            _whoMarkedCell = numberSprite == player && player == 1 ? CellStatus.O : CellStatus.X;

            if (is3D == true)
            {
                creatingField.selectCell[numberCell].SetActive(false);
                Vector3 positionField = creatingField.selectCell[numberCell].transform.position;
                GameObject newObject = Instantiate(prefabs[numberSprite], creatingField.transform);
                newObject.transform.position = positionField;
                newObject.transform.localScale = new Vector3(20f, 20f, 20f);
            }
            else
            {
                creatingField.selectCell[numberCell].GetComponent<Image>().sprite = spritesObjects[numberSprite];
            }
            
            creatingField.selectCell[numberCell].GetComponent<CellIndicator>().statusCell =
                numberSprite == 1 ? CellStatus.O : CellStatus.X;
            creatingField.selectCell[numberCell].GetComponent<Button>().interactable = false;
            playerTurn = numberSprite != player;

            firstIndex = numberCell / SizeSide;
            secondIndex = numberCell % SizeSide;

            MarkedCellMass[firstIndex,secondIndex] = creatingField.selectCell[numberCell].GetComponent<CellIndicator>().statusCell;
           
            CheckWin();
        }
    }
    
    /*public void ChangeImage3D(int numberCell)
    {
        int firstIndex = 0;
        int secondIndex = 0;
        

        if (creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell == CellStatus.None)
        {
            NumberSprite = playerTurn == true ? Player : PC;
            _whoMarkedCell = NumberSprite == Player && Player == 1 ? CellStatus.O : CellStatus.X;
            
            creatingField.SelectCell[numberCell].SetActive(false);
            Vector3 positionField = creatingField.SelectCell[numberCell].transform.position;
            GameObject newObject = Instantiate(prefabs[NumberSprite], creatingField.transform);
            newObject.transform.position = positionField;
            newObject.transform.localScale = new Vector3(20f, 20f, 20f);
            
            creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell =
                NumberSprite == 1 ? CellStatus.O : CellStatus.X;
            creatingField.SelectCell[numberCell].GetComponent<Button>().interactable = false;
            playerTurn = NumberSprite != Player;

            firstIndex = numberCell / SizeSide;
            secondIndex = numberCell % SizeSide;

            MarkedCellMass[firstIndex,secondIndex] = creatingField.SelectCell[numberCell].GetComponent<CellIndicator>().statusCell;
           
            CheckWin();
        }
    }*/



    private void CheckArea(int index1, int index2)
    {
        if (MarkedCellMass[index1,index2] == _whoMarkedCell  &&  numberSprite == pc)
        {
            _stateWinPC += 1;
        }
        if (MarkedCellMass[index1,index2] == _whoMarkedCell && numberSprite == player)
        {
            _stateWinPlayer += 1;
        }

        if (MarkedCellMass[index1, index2] != CellStatus.None)
            _draw += 1;
        
        if (_stateWinPC == SizeSide)
        {
            Debug.Log("Pc win");
            gameUI.OpenGUI(false);
            rawImageForGame.SetActive(true);
            rawCubeFor3DGame.SetActive(true);
            _gameOver = true;
        }
        if (_stateWinPlayer == SizeSide)
        {
            Debug.Log("Player win");
            gameUI.OpenGUI(true);
            rawImageForGame.SetActive(true);
            rawCubeFor3DGame.SetActive(true);
            _gameOver = true;
        }
        if (_draw == SizeSide * SizeSide && _gameOver != true)
        {
            Debug.Log("Draw");
            rawImageForGame.SetActive(true);
            rawCubeFor3DGame.SetActive(true);
            isDraw = true;
            gameUI.OpenGUI(false);
            _gameOver = true;
        }
    }
    

    private void CheckWin()
    {
        if (_gameOver != true)
        {
            for (int i = 0; i < SizeSide; i++)
            {
                for (int j = 0; j < SizeSide; j++)
                {
                    CheckArea(i,j);
                }
                _stateWinPlayer = 0;
                _stateWinPC = 0;
            }

            _draw = 0;
            
            for (int i = 0; i < SizeSide; i++)
            {
                for (int j = 0; j < SizeSide; j++)
                {
                    CheckArea(j,i);
                }
                _stateWinPlayer = 0;
                _stateWinPC = 0;
            }

            _draw = 0;
            
            for (int i = 0; i < SizeSide; i++)
            {
                CheckArea(i,i);
            }
            _stateWinPlayer = 0;
            _stateWinPC = 0;
            _draw = 0;
        
        
            for (int i = 0; i < SizeSide; i++)
            {
                CheckArea(i,SizeSide - i- 1);
                
            }
            _stateWinPlayer = 0;
            _stateWinPC = 0;
            _draw = 0;
            
        }

    }
    
}



