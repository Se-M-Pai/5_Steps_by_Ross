using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] Door;

    public void Update()
    {
        int j = PlayerPrefs.GetInt("levelAccess");
        for (int i = 0; i <= j; i++)
        {
            Door[i].SetActive(true);
        }
    }
}