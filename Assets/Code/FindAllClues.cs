using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindAllClues : MonoBehaviour
{
    [Header("NPCs")]
    public GameObject NPCBefore;
    public GameObject NPCAfter;
    [Header("Logic")]
    public int totalClues; 
    public int currentClues; 
    [Header("UI")]
    public TextMeshProUGUI cluesText;

    // Start is called before the first frame update
    void Start()
    {
        NPCBefore.SetActive(true);
        NPCAfter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cluesText.text = "Pistas encontradas: " + currentClues + "/"+totalClues;
        if (currentClues == totalClues)
        {
            NPCBefore.SetActive(false);
            NPCAfter.SetActive(true);
        }
    }
    public void AddClue()
    {
        currentClues++;
    }
}
