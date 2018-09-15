using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;

    private bool isAlive;
    private bool didFlap;
    private GameObject spawner;

    public float flag = 0f;
    public int score = 0;

    public static BirdController instance;

    void MakeInstance()
    {
        if (instance == null) instance = this;
    }

    private void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    private void BirdMoveMent()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if(myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    private void FixedUpdate()
    {
        BirdMoveMent();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FlapButton()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D taget)
    {
        if (taget.tag == "PipeHolder")
        {
            score++;
            Debug.Log("" + score);
            if (GamePlayController.instace != null) GamePlayController.instace.SetScore(score);
            audioSource.PlayOneShot(pingClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D taget)
    {
        if (taget.gameObject.tag == "Pipe" || taget.gameObject.tag == "Ground")
        {
            if (GamePlayController.instace != null) GamePlayController.instace.ShowGameOverPanel(score);
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(dieClip);
                anim.SetTrigger("Die");
            }
        }
    }
}
