using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class xyMovement : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.zero;

    public GameObject GoMovie;
    public GameObject GoMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // x,y ������ �̵�
        float x = Input.GetAxisRaw("Horizontal");//�¿� �̵�
        float y = Input.GetAxisRaw("Vertical"); //���� �̵�
        //�̵����� ����
        moveDirection = new Vector3(x, y, 0);
        
        //���ο� ��ġ ����
        transform.position += moveDirection* moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Music")
        {
            GoMusic.SetActive(true);
        }
        else if(other.gameObject.tag == "Movie")
        {
            GoMovie.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Music")
        {
            GoMusic.SetActive(false);
        }
        else if (other.gameObject.tag == "Movie")
        {
            GoMovie.SetActive(false);
        }
    }


}
