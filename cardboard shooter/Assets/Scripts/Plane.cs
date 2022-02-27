using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject startPos, endPos;
    public float speed = 7.5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //startPos = GameObject.Find("PlaneStart");
        //endPos = GameObject.Find("PlaneEnd");
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
            Destroy(gameObject, 0.3f);
        }
    }
}
