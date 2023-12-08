using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoom : ClickableObject
{
    public GameObject PreviousRoom;
    public GameObject NextRoom;
    private GameObject Player;

    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Action()
    {
        base.Action();
        if (GameManager.Instance.state == GameManager.GameState.Description || GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        NextRoom.SetActive(true);
        Vector3 NewPos = new Vector3(transform.position.x, Player.transform.position.y, Player.transform.position.z);
        Player.transform.position = NewPos;
        PreviousRoom.SetActive(false);

    }

}
