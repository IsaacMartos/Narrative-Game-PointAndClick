using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraActivate : ExtraEfect
{
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        Object.SetActive(false);
    }

    public override void Action()
    {
        base.Action();
        Object.SetActive(true);
    }
}
