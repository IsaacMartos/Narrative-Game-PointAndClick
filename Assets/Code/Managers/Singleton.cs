using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    
    public static Singleton Instance { get; private set; }
    public InkDialogueManager DialogueManager { get => _dialogueManager; set => _dialogueManager = null; }
    public GameManager GameManager { get => _gameManager; set => _gameManager = null; }

    [SerializeField] private InkDialogueManager _dialogueManager;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadSingletones;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadSingletones;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void LoadSingletones(Scene scene, LoadSceneMode mode)
    {
        _dialogueManager = FindObjectOfType<InkDialogueManager>();
        _gameManager = FindObjectOfType<GameManager>();

    }
}
