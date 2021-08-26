using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participant : MonoBehaviour
{

    public GameObject scrollview;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScroll()
    {
        if (open)
        {
            scrollview.SetActive(false);
            open = false;
        }
        else
        {
            scrollview.SetActive(true);
            open = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
