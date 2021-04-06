using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroisant;
    private int score = 0;
    private int life = 3;
    void Start()
    {
        StartCoroutine(SpawnCroisant());
    }
    public void Addsocre(int addscore)
    {
        score += addscore;
    }
    public int Getlife()
    {
        return life;
    }

    public void Dead()
    {
        life--;
    }
    private IEnumerator SpawnCroisant()
    {
        float randomX = 0f;
        float randomDelay = 0f;
        while (true)
        {
            randomX = Random.Range(-7f, 7f);
            randomDelay = Random.Range(1f, 5f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemyCroisant, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
