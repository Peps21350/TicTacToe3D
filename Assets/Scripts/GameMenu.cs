using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject choiceSide;
    [SerializeField] private GameObject choiceTypeGame;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameMechanic gameMechanic;
    [SerializeField] private CreatingField scriptCreatingField;
    [SerializeField] private GameObject displayMode;
    [HideInInspector] public bool isRestart = false;
   

    private void Start()
    {
        if (isRestart == true)
        {
            menu.SetActive(false);
            choiceSide.SetActive(false);
            choiceTypeGame.SetActive(true);
        }
    }

    public void StartGame()
    {
        menu.SetActive(false);
        displayMode.SetActive(true);
    }

    public void Selection2D()
    {
        choiceSide.SetActive(true);
        menu.SetActive(false);
        displayMode.SetActive(false);
    }
    public void Selection3D()
    {
        choiceSide.SetActive(true);
        menu.SetActive(false);
        displayMode.SetActive(false);
        gameMechanic.is3D = true;
    }

    public void ZeroSelection()
    {
        gameMechanic.pc = 2;
        choiceSide.SetActive(false);
        choiceTypeGame.SetActive(true);
    }
    
    public void CrossSelection()
    {
        gameMechanic.player = 2;
        choiceSide.SetActive(false);
        choiceTypeGame.SetActive(true);
    }


    public void TypeGame3X3()
    {
        choiceTypeGame.SetActive(false);
        scriptCreatingField.CreateField(3);
        
    }
    
    public void TypeGame6X6()
    {
        choiceTypeGame.SetActive(false);
        scriptCreatingField.CreateField(6);
    }
    public void TypeGame9X9()
    {
        choiceTypeGame.SetActive(false);
        scriptCreatingField.CreateField(9);
    }
    
    public void TypeGame15X15()
    {
        choiceTypeGame.SetActive(false);
        scriptCreatingField.CreateField(15);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

}
