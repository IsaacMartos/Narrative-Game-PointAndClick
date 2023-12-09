using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraActivDeactiv : ExtraEfect
{
    public GameObject DeacivObject;
    public GameObject ActivObject;
    // Start is called before the first frame update
    void Start()
    {
        ActivObject.SetActive(false);
        DeacivObject.SetActive(true);
    }

    public override void Action()
    {
        base.Action();
        ActivObject.SetActive(true);
        DeacivObject.SetActive(false);
    }
}

