using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [Header("Objeto")]
    public CharacteristicsData data;
    public GameObject Outline;

    [Header("UI")]
    public Image imageSlot;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        imageSlot = GameManager.Instance.itemManager.SpriteHolder;
        nameText = GameManager.Instance.itemManager.itemName;
        descriptionText = GameManager.Instance.itemManager.itemDescription;
        ShowOutline(false);
    }
    public void ShowDescription()
    {
        GameManager.Instance.itemManager.SetInteracting(true);
        //Debug.Log( data.name + " " + data.description);
        imageSlot.sprite = data.image;
        nameText.text = data.name;
        descriptionText.text = data.description;
        GameManager.Instance.itemManager.ShowItem();

        //DEBUG LUEGO LO QUITAMOS
        StartCoroutine(DebugItemStopShowing());
    }

    public void ShowOutline(bool show)
    {
        Outline.SetActive(show);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer") || GameManager.Instance.itemManager.GetInteracting()) return;
        if (GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        ShowOutline(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pointer")) return;
        ShowOutline(false);
    }
    
    
    IEnumerator DebugItemStopShowing()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.itemManager.HideItem();
        GameManager.Instance.itemManager.SetInteracting(false);
    }
}
