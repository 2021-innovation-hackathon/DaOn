using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoSignin : MonoBehaviour
{
    public void OnClickSignIn()
    {
        SceneManager.LoadScene("SignIn");
    }
}
