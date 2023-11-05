using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InkDialogueTrigger : MonoBehaviour
{
    public GameObject visualCue;
    bool CanTalk;

    [SerializeField] TextAsset inkJSON;
    private InputController _inputController;

    private void Awake()
    {
        CanBeInteracted(false);
        _inputController = FindObjectOfType<InputController>();
    }

    void Update()
    {
        //Cambiar a input nuevo
     if (_inputController.interact && CanTalk && !InkDialogueManager.GetInstance().dialogueIsPlaying)
        {
            InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            CanBeInteracted(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CanBeInteracted(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CanBeInteracted(false);

    }
    public void CanBeInteracted(bool can)
    {
        visualCue.SetActive(can);
        CanTalk = can;
        //UI text
        //InteractText.SetActive(can);
    }
}
