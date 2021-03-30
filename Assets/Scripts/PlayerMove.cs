using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;

    private Rigidbody2D rigid = null;
    private Vector2 targetPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Fire());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //rigid.MovePosition(targetPosition);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        while(true)
        {
            GameObject newbullet = Instantiate(bulletPrefab, bulletPosition);
            newbullet.transform.position = bulletPosition.position;
            newbullet.transform.SetParent(null);
            yield return new WaitForSeconds(1f);
        }
    }
}
