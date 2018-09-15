using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour {
    [SerializeField]
    private GameObject pipeHolder;


	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawner() //IEnumerator cho phep delay bao nhieu giay
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-1f, 2f);

        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
