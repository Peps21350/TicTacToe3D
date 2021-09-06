using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private const int _WindthWindowGameUI = 400; 
    private const int _HeightWindowGameUI = 600; 
    private Rect _windowRect = new Rect((Screen.width - _WindthWindowGameUI) / 2, (Screen.height - _HeightWindowGameUI) / 2, _WindthWindowGameUI, _HeightWindowGameUI);
    private bool _show = false;
    private bool _win = false;
    public GUIStyle[] labelStyle;
    [SerializeField] private GameMechanic gameMechanic;
    

    void OnGUI()
    {
        if(_show && !_win)
        {
            _windowRect = GUI.Window(0, _windowRect, DialogWindow, ""); 
        }
        if (_show && _win) 
        {
            _windowRect = GUI.Window(1, _windowRect, DialogWindow, ""); 
        }
    }
    
    private GUIStyle NewGuiStyle()
    {
        GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
        guiStyle.fontSize = 28;
        return guiStyle;
    }

    void DialogWindow(int windowID)
    {
        string text = windowID == 1 ? "New game" : "Restart";

        
        if (gameMechanic.isDraw == true)
        {
            GUI.Label(new Rect(5, 5, _windowRect.width, 360), "DRAW", NewGuiStyle());
        }
        else
        {
            GUI.Label(new Rect(5, 5, _windowRect.width, 360),"",labelStyle[windowID]);
        }
        
        if (GUI.Button(new Rect(5, 380, _windowRect.width - 10, 70), text, NewGuiStyle()))
        {
            SceneManager.LoadScene("GameScene");
            _show = false;
        }
        
        if (GUI.Button(new Rect(5, 460, _windowRect.width - 10, 70), "Exit to menu", NewGuiStyle()))
        {
            SceneManager.LoadScene("GameScene");
            _show = false;
        }
    }
    
    public void OpenGUI( bool win)
    {
        _show = true;
        _win = win;
    }

}
