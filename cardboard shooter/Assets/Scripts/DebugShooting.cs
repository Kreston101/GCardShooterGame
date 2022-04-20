using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShooting : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("input space");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                if (hit.collider.CompareTag("Target"))
                {
                    gm.RemoveMe(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.gameObject);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
                Debug.Log("No hit");
            }
        }
    }
}
