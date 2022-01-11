using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public GameObject startPos, endPos;
    public float speed = 5;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPos = GameObject.Find("RunnerStart");
        endPos = GameObject.Find("RunnerEnd");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.Normalize(endPos.transform.position - transform.position);
        moveDirection.y = 0;
        rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == endPos)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
