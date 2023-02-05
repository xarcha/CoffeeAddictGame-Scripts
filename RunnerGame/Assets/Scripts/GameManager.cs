using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Pause,
    End
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState;
    private LevelManager levelManager;
    private UIManager uIManager;
    
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        uIManager= GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState= GameState.Pause;
    }
    public void StartGame()
    {
        currentGameState= GameState.Start;
        uIManager.UpdateLevelText(levelManager.currentLevel);
        levelManager.StartLevel();
    }
    public void StartNextGame()
    {
        currentGameState = GameState.Start;
        levelManager.StartNextLevel();
        uIManager.UpdateLevelText(levelManager.currentLevel);
    }

    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextGame();
        }
    }
    public void EndGame()
    {
        levelManager.EndLevel();
        uIManager.EndLevel();
        currentGameState= GameState.End;
        Debug.Log("Level Tamamlandý");
    }
    
}
