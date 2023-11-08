using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    #region Events

    public static event Action<GameState> OnGameStateChanged;
    
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Paused:
                OnPause();
                break;
            case GameState.Dialogue:
                break;
            case GameState.Playing:
                OnUnpause();
                break;
            case GameState.Lose:
                break;
            case GameState.Victory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
    
    public static void OnPause() => Time.timeScale = 0;
    
    public static void OnUnpause() => Time.timeScale = 1;
    
    public enum  GameState
    {
        Paused,
        Dialogue,
        Playing,
        Lose,
        Victory
    }
}
