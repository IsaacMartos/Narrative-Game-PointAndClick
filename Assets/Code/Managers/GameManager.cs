using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InkDialogueManager dialogueManager;
    public ItemManager itemManager;
    public GameObject pointer;
    public GameState state;

    #region Events

    public static event Action<GameState> OnGameStateChanged;
    
    #endregion

    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
        dialogueManager = FindObjectOfType<InkDialogueManager>();
        pointer = GameObject.FindGameObjectWithTag("Pointer");

        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
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
            case GameState.Description:
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
        Victory,
        Description
    }
}
