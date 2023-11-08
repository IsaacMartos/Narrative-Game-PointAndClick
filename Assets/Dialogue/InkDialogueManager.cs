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

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

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

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueIsPlaying) return;

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
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        _playerMovement.canMove = false;
        _inputController.AddInteractFunction(ContinueStory);
        GetTheCurrentStory();
    }
    private void ExitDialogueMode()
    {
        animator.SetBool("IsOpen", false);
        dialogueIsPlaying = false;
        dialogueText.text = "";
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        _playerMovement.canMove = true;
        _inputController.RemoveInteractFunction(ContinueStory);
    }
    private void ContinueStory(InputAction.CallbackContext ctx)
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }

        else
        {
            ExitDialogueMode();
        }
    }

    private void GetTheCurrentStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }

        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. " +
                           "Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
}
