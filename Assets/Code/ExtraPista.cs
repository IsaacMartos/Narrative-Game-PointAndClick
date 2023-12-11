using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPista : ExtraEfect
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Action()
    {
        base.Action();
        GameObject.Find("FindAllClues").GetComponent<FindAllClues>().AddClue();
    }
}
