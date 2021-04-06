using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int score = 100;
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 5f;
    private GameManager gamemanger = null;

    bool isDamaged = false;

    void Start()
    {
        gamemanger = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (isDamaged) return;

            isDamaged = true;
            Destroy(collision.gameObject);
            StartCoroutine(Damaged());
            if (hp <= 0)
            {
                gamemanger.Addsocre(score);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damaged()
    {

        hp--;
        yield return new WaitForSeconds(0.1f);
        isDamaged = false;
    }
}
