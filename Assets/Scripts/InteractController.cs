using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractController : MonoBehaviour
{
    public PlayerController Player1;
    public PlayerController Player2;
    public NextLevelScript NextLevelScript;

    public int lockLevel = 0;
    public int levelAccess = PlayerPrefs.GetInt("levelAccess");


    private void FixedUpdate()
    {
        if (lockLevel == 2)
        {
            if (levelAccess < SceneManager.GetActiveScene().buildIndex)
            {
                levelAccess = SceneManager.GetActiveScene().buildIndex;
            }
            PlayerPrefs.SetInt("levelAccess", levelAccess);
            PlayerPrefs.Save();
            NextLevelScript.NextLevel();
        }
    }
    public void LockLevel()
    {
        lockLevel += 1;
    }
}