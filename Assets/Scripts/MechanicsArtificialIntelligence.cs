using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MechanicsArtificialIntelligence : MonoBehaviour
{
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private CreatingField creatingField;
    private const int _MINCountLapsCycle = 10;


    public void ChangeImageByPC()
    {
        if (gameMechanic.playerTurn == false)
        {
            for (int i = 0; i < _MINCountLapsCycle * creatingField.cellsCount; i++)
            {
                int randomPosition = Random.Range(0, creatingField.cellsCount);
                if (creatingField.selectCell[randomPosition].GetComponent<CellIndicator>().statusCell ==
                    CellStatus.None)
                {
                    gameMechanic.ChangeImage(randomPosition);
                    break;
                }
            }
        }
    }
    

    

    private void Update()
    {
        ChangeImageByPC();
    }
       
}
