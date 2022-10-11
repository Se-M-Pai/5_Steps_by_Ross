using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetup : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
