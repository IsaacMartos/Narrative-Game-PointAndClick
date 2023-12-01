using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject Outline;
    // Start is called before the first frame update
    void Start()
    {
        ShowOutline(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Action()
    {
        //Do something
    }

    public virtual void ShowOutline(bool show)
    {
        Outline.SetActive(show);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer") || GameManager.Instance.itemManager.GetInteracting()) return;
        //if (!collision.CompareTag("Pointer")) return;
        if (GameManager.Instance.state == GameManager.GameState.Description) return;
        ShowOutline(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer")) return;
        ShowOutline(false);
    }

}
