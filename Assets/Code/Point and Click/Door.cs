using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Outline;
    public GameObject Closed;
    public GameObject Open;
    public bool Opened;

    // Start is called before the first frame update
    void Start()
    {
        if (Opened)
        {
            Closed.SetActive(false);
            Open.SetActive(true);
        }
        else
        {
            Closed.SetActive(true);
            Open.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        Closed.SetActive(false);
        Open.SetActive(true);
        ShowOutline(false);
        Opened = true;
    }

    public void ShowOutline(bool show)
    {
        if (Opened) return;
        Outline.SetActive(show);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer") || GameManager.Instance.itemManager.GetInteracting()) return;
        if (GameManager.Instance.state == GameManager.GameState.Description) return;
        ShowOutline(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer")) return;
        ShowOutline(false);
    }
}
