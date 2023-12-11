using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEWSCENE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GOSCENE()
    {
        SceneManager.LoadScene("IntroCasaDetective");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
