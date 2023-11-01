using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCConversation : MonoBehaviour
{
    public GameObject bubble;
    public GameObject InteractText;
    bool CanTalk = false;
    DialogueTrigger triggerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(false);
        //InteractText = GameObject.Find("InteractText");
        InteractText.SetActive(false);
        triggerDialogue = gameObject.GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        Talk();
    }
    public void Talk()
    {
        if (!CanTalk) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            triggerDialogue.TriggerDialogue();
            bubble.SetActive(false);
            InteractText.SetActive(false);
            CanTalk = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        bubble.SetActive(true);
        InteractText.SetActive(true);
        CanTalk = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag!="Player") return;
        bubble.SetActive(false);
        InteractText.SetActive(false);
        CanTalk = false;
        
    }
}
