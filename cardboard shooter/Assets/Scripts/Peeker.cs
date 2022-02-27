using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeker : MonoBehaviour
{
    public GameObject startPos, endPos;
    public float speed = 2.5f;
    public int id;

    private Rigidbody rb;
    private bool peeking = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = GameObject.Find($"Peeker{id}Start");
        endPos = GameObject.Find($"Peeker{id}End");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (peeking == true)
        {
            Vector3 moveDirection = Vector3.Normalize(endPos.transform.position - transform.position);
            moveDirection.y = 0;
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
        else
        {
            Vector3 moveDirection = Vector3.Normalize(startPos.transform.position - transform.position);
            moveDirection.y = 0;
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == endPos && peeking == true)
        {
            Debug.Log("reversing");
            StartCoroutine(Hide());
        }
        else if (other.gameObject == startPos && peeking == false)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    IEnumerator Hide()
    {
        Debug.Log("started hide");
        yield return new WaitForSecondsRealtime(3f);
        peeking = false;
    }
}
