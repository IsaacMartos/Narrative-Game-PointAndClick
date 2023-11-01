using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 10;
    
    // Update is called once per frame
    void Update()
    {
        OnPlayerMovement();
    }

    void OnPlayerMovement()
    {
        if (GameManager.Instance.state == GameManager.GameState.Dialogue) return;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * (speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * (speed * Time.deltaTime);
        }
    }
}
