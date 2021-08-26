using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMovie : MonoBehaviour
{
    public void OnClickBtn()
    {
        SceneManager.LoadScene("Movie");
    }
}
