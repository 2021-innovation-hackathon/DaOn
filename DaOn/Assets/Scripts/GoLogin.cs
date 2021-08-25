using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLogin : MonoBehaviour
{

    public void OnClickStart()
    {
        SceneManager.LoadScene("Login");
    }
}
