using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : ClickableObject
{
    public string NextScene;
    // Start is called before the first frame update
    public override void Action()
    {
        base.Action();
        if (GameManager.Instance.state == GameManager.GameState.Description || GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        Debug.Log("wut");
        SceneManager.LoadScene(NextScene);
        GameManager.Instance.camera = Singleton.Instance.Camera;
    }
}
