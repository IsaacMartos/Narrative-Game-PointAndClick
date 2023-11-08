using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public GameObject ObjectInspector;

    public Image SpriteHolder;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    bool interacting;

    private void Awake()
    {
        interacting = false;
        ObjectInspector.SetActive(false);
    }

    // Start is called before the first frame update
    public void ShowItem()
    {
        //CAMBIAR A UNA ANIMACIÓN
        ObjectInspector.SetActive(true);
        GameManager.Instance.state = GameManager.GameState.Dialogue;
    }
    public void HideItem()
    {
        //CAMBIAR A UNA ANIMACIÓN
        ObjectInspector.SetActive(false);
        GameManager.Instance.state = GameManager.GameState.Playing;
    }
    public void SetInteracting(bool set)
    {
        interacting = set;
    }
    public bool GetInteracting()
    {
        return interacting;
    }
}
