using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ClickableObject
{
    public GameObject Closed;
    public GameObject Open;
    public bool Opened;

    // Start is called before the first frame update
    private void Awake()
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

    public override void ShowOutline(bool show)
    {
        if (Opened) return;
        base.ShowOutline(show);
    }

    public override void Action()
    {
        Closed.SetActive(false);
        Open.SetActive(true);
        ShowOutline(false);
        Opened = true;
    }
}
