using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get {
            if (instance == null)
            {
                
            }
            return instance;
        } 
    }

    public Canvas playCanvas;
    public Canvas upgrateCanvas;
    public Canvas ScreenCanvas;
    public Canvas gameOverPanel;
    
    private void Awake()
    {
        instance = this;
        gameOverPanel.enabled= false;
    }
    private void Start()
    {
        ScreenCanvas.enabled = false;
    }
    public void SetActiveUpgrateCanvas()
    {
        playCanvas.enabled = false;
        upgrateCanvas.enabled = true;
    }
    public void PlaytheGame()
    {
        GameManager.Instance.canPlayGame = true;
        playCanvas.enabled = false;
        ScreenCanvas.enabled = true;
        upgrateCanvas.enabled = false;
    }
    public void GameOver()
    {
        gameOverPanel.enabled = true;
    }
}
