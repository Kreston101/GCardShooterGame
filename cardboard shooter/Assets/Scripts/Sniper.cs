using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public float peekingHeight, startHeight;
    public float speed = 2f;
    public GameManager gm;

    private Rigidbody rb;
    private Vector3 moveDist;
    private bool visible, retract = false;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        moveDist = new Vector3(0f, peekingHeight - startHeight, 0f);
    }

    void FixedUpdate()
    {
        if (visible == false && transform.position.y <= peekingHeight)
        {
            rb.MovePosition(transform.position + moveDist * speed * Time.deltaTime);
        }
        else if (retract == true && transform.position.y >= peekingHeight)
        {
            rb.MovePosition(transform.position - moveDist * speed * Time.deltaTime);
            gm.RemoveMe(gameObject);
            Destroy(gameObject, 0.1f);
        }
        else
        {
            visible = true;
            StartCoroutine("Aim");
        }
    }

    IEnumerator Aim()
    {
        yield return new WaitForSecondsRealtime(4f);
        retract = true;
    }
}
