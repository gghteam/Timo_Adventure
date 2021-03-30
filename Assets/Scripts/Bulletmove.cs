using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
