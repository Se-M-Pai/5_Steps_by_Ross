using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Bridge bridge;
    public SpriteRenderer sprite;
    [SerializeField] Sprite leverOff;
    [SerializeField] Sprite leverOn;
    private bool active = false;
    public bool signal = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            active = true;
        }
        if (collision.gameObject.name == "Player2")
        {
            active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            active = false;
        }
        if (collision.gameObject.name == "Player2")
        {
            active = false;
        }
    }
    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            if (signal == true)
            {
                signal = false;
                sprite.sprite = leverOn;
                bridge.Open();
            }
            else
            {
                signal = true;
                sprite.sprite = leverOff;
                bridge.Close();
            }
        }
    }
}
