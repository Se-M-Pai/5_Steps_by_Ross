using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    [SerializeField] int sceneNumber;

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }
}
