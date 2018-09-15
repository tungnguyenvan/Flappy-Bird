using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        PipeMovement();
	}

    private void PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    //Bắt va chạm gồm 2 hàm
    private void OnCollisionEnter2D(Collision2D taget)
    {
        //nếu va chạm mà không có đối tượng nào đc check là isTrigger thì sẽ sử dụng hàm OnCollisionEnter2D
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //nếu va chạm mà 1 trong 2 đối tượng đc check là isTrigger thì sẽ sử dụng hàm OnTriggerEnter2D 

        if (collision.tag == "Des")
        {
            Destroy(gameObject);
        }
    }
}
