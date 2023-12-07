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

    [SerializeField] private InkDialogueManager _dialogueManager;
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _pointer;

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
        _itemManager = FindObjectOfType<ItemManager>();
        _pointer = GameObject.FindGameObjectWithTag("Pointer");
    }
}
