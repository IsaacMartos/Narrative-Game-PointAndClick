using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Animator animator;

    [Header("Choice UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currnetStory;

    public bool dialogueIsPlaying { get; private set; }

    private static InkDialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

    private InputController _inputController;
    [SerializeField] private DefinitivePlayerMovement _playerMovement;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Dialogue manager on this scene");
        }
        instance = this;

        _inputController = FindObjectOfType<InputController>();
    }
    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        animator = dialogueBox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueIsPlaying) return;

        // Cambiar a input nuevo
        if (_inputController.interact)
        {
            _inputController.AddInteractFunction(ContinueStory);
            //ContinueStory();
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Dialogue);
        animator.SetBool("IsOpen", true);
        currnetStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        _playerMovement.canMove = false;

        _inputController.AddInteractFunction(ContinueStory);
    }
    private void ExitDialogueMode()
    {
        animator.SetBool("IsOpen", false);
        dialogueIsPlaying = false;
        dialogueText.text = "";
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        _inputController.RemoveInteractFunction(ContinueStory);
        _playerMovement.canMove = true;
    }
    private void ContinueStory(InputAction.CallbackContext ctx)
    {
        if (!currnetStory.canContinue)
        {
            ExitDialogueMode();
            return;
        }

        dialogueText.text = currnetStory.Continue();
    }
}
