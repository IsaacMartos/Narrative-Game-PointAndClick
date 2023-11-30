using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public GameObject Exterior;
    public GameObject Interior;
    public GameObject Outline;
    public bool OnRoom;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterRoom()
    {
        Exterior.SetActive(false);
        Interior.SetActive(true);
        ShowOutline(false);
        OnRoom = true;
    }
    public void ExitRoom()
    {
        // Le falta un poco en el horno a este script. Estoy pensando
    }

    public void ShowOutline(bool show)
    {
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

