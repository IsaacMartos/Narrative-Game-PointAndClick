using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public InkDialogueManager DialogueManager { get => _dialogueManager; set => _dialogueManager = null; }
    public ItemManager ItemManager { get => _itemManager; set => _itemManager = null; }
    public GameManager GameManager { get => _gameManager; set => _gameManager = null; }
    public GameObject Pointer { get => _pointer; set => _pointer = null; }
    
    public Camera Camera { get => _camera; set => _camera = null; }

    [SerializeField] private InkDialogueManager _dialogueManager;
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _pointer;
    [SerializeField] private Camera _camera;

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
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _camera = Camera.main;
    }

    private void LoadSingletones(Scene scene, LoadSceneMode mode)
    {
        _dialogueManager = FindObjectOfType<InkDialogueManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _itemManager = FindObjectOfType<ItemManager>();
        _pointer = GameObject.FindGameObjectWithTag("Pointer");
        _camera = Camera.main;
    }
}
