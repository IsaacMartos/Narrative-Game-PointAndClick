using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject Past;
    public GameObject Present;
    public GameObject Filter;
    public bool TimePresent = true;
    // Start is called before the first frame update
    void Start()
    {
        GoBackTime(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeTraveller();

    }

    private void TimeTraveller()
    {
        if (GameManager.Instance.state == GameManager.GameState.Dialogue || GameManager.Instance.state == GameManager.GameState.Description) return;

        if (!Input.GetKeyDown(KeyCode.Tab)) return;

        if (TimePresent)
        {
            GoBackTime(true);
            return;
        }
        GoBackTime(false);
        // Avisa al game manager para ver si lo has usado en el Acto 2
    }

    public void GoBackTime(bool back)
    {
        TimePresent = !back;
        Past.SetActive(back);
        Filter.SetActive(back);
        Present.SetActive(!back);
    }
}
