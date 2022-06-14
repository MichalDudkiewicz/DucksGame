using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBehaviour : MonoBehaviour
{
    public float breadSpeed;

    public List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        System.Random r = new System.Random();
        int rInt = r.Next(0, sprites.Count);
        spriteRenderer.sprite = sprites[rInt];
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * breadSpeed * Time.deltaTime);
        
        if (this.gameObject.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            DuckBehaviour duck = collision.gameObject.GetComponent<DuckBehaviour>();
            duck.life -= 10;
            duck.hunger += 5;

            GameManager.Instance.points -= 10;

            Vibrator.Vibrate();
            MenuSoundManager.Instance.PlayBread();
        }
    }
}
