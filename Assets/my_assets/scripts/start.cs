using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("trying to load level");
    }
}
