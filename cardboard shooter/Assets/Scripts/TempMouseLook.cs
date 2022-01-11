using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMouseLook : MonoBehaviour
{
    public float sen = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal") * sen * Time.deltaTime;
        float verti = Input.GetAxis("Vertical") * sen * Time.deltaTime;

        transform.Rotate(verti, hori, 0, Space.Self);
    }
}
