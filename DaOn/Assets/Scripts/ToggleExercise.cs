using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleExercise : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggle = new Toggle[24];

    private int[] checkToggle = new int[24];

    public void OnClickBtn()
    {
        /*
        for(int i = 0; i < toggle.Length; i++)
        {
            if (toggle[i].isOn)
            {
                checkToggle[i] = 1;
                Debug.Log(i.ToString() + ":" + 1);
            }
            else
            {
                checkToggle[i] = 0;
                Debug.Log(i.ToString() + ":" + 0);
            }
        }
        */

        SceneManager.LoadScene("LogIn");
    }
    
}
