using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool active = false;
    public NextLevelScript NLS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            active = false;
        }
    }

    public void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            NLS.LoadLevel();
        }
    }
}
