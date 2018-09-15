using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Scale Background in game
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;

        //transform.localScale = new Vector3(worldWidth, worldHeight, 0);

        tempScale.y = worldHeight / height;
        tempScale.x = worldHeight / width;
        transform.localScale = tempScale;
        //END Scale Background in game
    }
}
