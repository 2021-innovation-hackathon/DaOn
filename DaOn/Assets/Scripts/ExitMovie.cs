using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMovie : MonoBehaviour
{
    public void OnClickExit()
    {
        SceneManager.LoadScene("Main");
    }
}
