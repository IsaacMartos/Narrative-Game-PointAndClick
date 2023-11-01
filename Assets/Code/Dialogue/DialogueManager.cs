using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public Image Character1Image;
    public Image Character2Image;

    public Queue<string> C1sentences;
    public Queue<string> C2sentences;

    bool CharacterSpeaking = true;

    string C1name;
    string C2name;

    void Start()
    {
        C1sentences = new Queue<string>();
        C2sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //Play animation "Dialogue box appears"
        animator.SetBool("IsOpen",true);

        //Asign new speaking character images
        Character1Image.sprite = dialogue.C1image;
        Character2Image.sprite = dialogue.C2image;

        //Name is Character one's name
        C1name = dialogue.C1name;
        C2name = dialogue.C2name;
        nameText.text = C1name;

        //Change color to destacar character 1
        Character1Image.color = new Color32(250, 250, 250, 250);
        Character2Image.color = new Color32(100, 100, 100, 250);

        //Clear text box
        C1sentences.Clear();
        C2sentences.Clear();

        //Create a queue for character one sentences 
        foreach (string sentence in dialogue.C1sentences)
        {
            C1sentences.Enqueue(sentence);
        }
        //Create a queue for character two sentences 
        foreach (string sentence in dialogue.C2sentences)
        {
            C2sentences.Enqueue(sentence);
        }
        //Display next Character sentence [altering character order]
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //if both characters have no more sentences. Stop conversation
        if (C1sentences.Count == 0 && C2sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //write the sentence on screen, change name and image to darker tone
        if (CharacterSpeaking)
        {
            nameText.text = C1name;
            Character1Image.color = new Color32(250, 250, 250, 250);
            Character2Image.color = new Color32(100,100,100,250);
            string sentence = C1sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            CharacterSpeaking = false;
        }
        else
        {
            nameText.text = C2name;
            Character2Image.color = new Color32(250, 250, 250, 250);
            Character1Image.color = new Color32(100, 100, 100, 250);
            string sentence = C2sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            CharacterSpeaking = true;
        }
    }

    //Typing sentence
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
    }
    //Animation "hiding text box"
    public void EndDialogue( )
    {
        animator.SetBool("IsOpen", false);
    }
}
