using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public CharacteristicsData data;
    public GameObject Outline;
    private void Start()
    {
        ShowOutline(false);
    }
    public void ShowDescription()
    {
        Debug.Log( data.name + " " + data.description);
    }
    public void ShowOutline(bool show)
    {
        Outline.SetActive(show);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowOutline(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ShowOutline(false);
    }
}
