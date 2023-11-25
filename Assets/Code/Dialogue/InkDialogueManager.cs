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
    [SerializeField] private GameObject nextButton;
    [SerializeField] private Animator portraitAnimator;
    private Animator animator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static InkDialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private bool canContinue = false;

    [SerializeField] private DefinitivePlayerMovement _playerMovement;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Dialogue manager on this scene");
        }
        instance = this;

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

        if (InputController.GetInstance().GetSubmitPressed() && canContinue)
        {
            Debug.Log("si hombre");
            ContinueStory();
        }
        
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Debug.Log("estoy en el siguiente estado del juego");
        GameManager.Instance.UpdateGameState(GameManager.GameState.Dialogue);
        animator.SetBool("IsOpen", true);
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        _playerMovement.canMove = false;

        nameText.text = "???";
        portraitAnimator.Play("default");
        
        ContinueStory();
    }
    private void ExitDialogueMode()
    {
        //dialogueText.text = "";
        StartCoroutine(EndDialogue());
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        _playerMovement.canMove = true;
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //dialogueText.text = currentStory.Continue();
            CleanChoices();
            StartCoroutine(TypeSentence(currentStory.Continue()));
            //DisplayChoices();
            HandleTags(currentStory.currentTags);
        }

        else
        {
            ExitDialogueMode();
        }
    }
    IEnumerator TypeSentence(string sentence)
    {
        canContinue = false;
        nextButton.SetActive(false);
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
        DisplayChoices();
        //Puedes darle al boton next
        canContinue = true;
        nextButton.SetActive(true);
    }

    private void CleanChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        int index = 0;
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be apparently parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    nameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    Debug.Log("layout" + tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handed: " + tag);
                    break;
            }
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

    private IEnumerator EndDialogue()
    {
        yield return new WaitForEndOfFrame();
        dialogueIsPlaying = false;
        animator.SetBool("IsOpen", false);
    }
}
