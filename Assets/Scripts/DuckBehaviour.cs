using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DuckBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Vector2 originPosition;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = true;
    public float SWIPE_THRESHOLD = 200f;
    private Camera cam;
    private BoxCollider2D boxCollider;
    Vector3 fingerDownPosition;

    public List<Sprite> hearts;
    public List<Sprite> stomachs;
    public int life = 100;
    public int hunger = 10;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;

    private GameObject stomach;
    private GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        boxCollider = GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        originPosition = transform.position;

        heart = gameObject.transform.GetChild(0).gameObject;
        stomach = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 10)
        {
            GameEvents.current.DuckDeath(this.gameObject.GetComponent<DuckBehaviour>());
            Destroy(this.gameObject);
        }
        life = Mathf.Clamp(life, 10, 100);
        hunger = Mathf.Clamp(hunger, 10, 100);
        heart.GetComponent<SpriteRenderer>().sprite = hearts[life / 10 - 1];
        stomach.GetComponent<SpriteRenderer>().sprite = stomachs[hunger / 10 - 1];

        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            hunger -= 1;
        }



        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
                fingerDownPosition = cam.ScreenToWorldPoint(fingerDown);
                fingerDownPosition.z = 0;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                if (boxCollider.bounds.Contains(fingerDownPosition))
                {
                    checkSwipe();
                }
            }
        }
        transform.position = Vector2.Lerp(transform.position, originPosition, 0.2f);
    }

    private void FixedUpdate()
    {
        
    }


    void checkSwipe()
    {
        //Check if Horizontal swipe
        if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }
    }
    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void OnSwipeLeft()
    {
        MenuSoundManager.Instance.PlaySwim();
        originPosition = new Vector2(Mathf.Clamp(originPosition.x - 1.5f, -1.5f, 1.5f), originPosition.y);
    }

    void OnSwipeRight()
    {
        MenuSoundManager.Instance.PlaySwim();
        originPosition = new Vector2(Mathf.Clamp(originPosition.x + 1.5f, -1.5f, 1.5f), originPosition.y);
    }
}
