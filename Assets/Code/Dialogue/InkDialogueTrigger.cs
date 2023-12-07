using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Input = UnityEngine.Windows.Input;

public class InkDialogueTrigger : MonoBehaviour
{
    public GameObject visualCue;
    public bool canTalk;
    public bool hasExtra;
    public ExtraEfect Extra;

    [SerializeField] TextAsset inkJSON;

    private void Awake()
    {
        CanBeInteracted(false);
    }

    void Update()
    {
        if ( canTalk && InkDialogueManager.GetInstance().dialogueIsPlaying == false && 
             GameManager.Instance.state == GameManager.GameState.Playing && InputController.GetInstance().GetInteractionPressed())
        {
            StartTriggerInteraction();
        }
    }

    public void StartTriggerInteraction()
    {
        Debug.Log("Esto esta apretando la E y furulando");
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        CanBeInteracted(false);
        if (!hasExtra) return;
        ExtraEfects();
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
        canTalk = can;
        //UI text
        //InteractText.SetActive(can);
    }
    private void ExtraEfects()
    {
        Extra.Action();
    }
}
