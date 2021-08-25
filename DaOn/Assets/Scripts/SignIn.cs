using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignIn : MonoBehaviour
{
    public void OnClickNext()
    {
        SceneManager.LoadScene("CheckBox");
    }
}
