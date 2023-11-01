using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue 
{
    public Sprite C1image;
    public Sprite C2image;

    public string C1name;
    public string C2name;

    [TextArea(3,10)]
    public string[] C1sentences;
    [TextArea(3,10)]
    public string[] C2sentences;
}
