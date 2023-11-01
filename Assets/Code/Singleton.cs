using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    
    public static Singleton Instance { get; private set; }
    public DialogueManager DialogueManager { get => _dialogueManager; set => _dialogueManager = null; }

    [SerializeField] private DialogueManager _dialogueManager;
    
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
        _dialogueManager = FindObjectOfType<DialogueManager>();

    }
}
