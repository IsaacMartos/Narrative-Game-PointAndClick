using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Input = UnityEngine.Windows.Input;

public class InkDialogueTrigger : MonoBehaviour
{
    public GameObject visualCue;
    bool CanTalk;
    public bool HasExtra;
    public ExtraEfect Extra;

    [SerializeField] TextAsset inkJSON;

    private void Awake()
    {
        CanBeInteracted(false);
    }

    void Update()
    {
     if (InputController.GetInstance().GetInteractPressed() && CanTalk && !InkDialogueManager.GetInstance().dialogueIsPlaying)
     {
         Debug.Log("Esto esta apretando la E y furulando");
         InkDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
         CanBeInteracted(false);
         if (!HasExtra) return;
         ExtraEfects();
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
    private void ExtraEfects()
    {
        Extra.Action();
    }
}
