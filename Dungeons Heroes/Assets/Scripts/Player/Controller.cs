using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            gameObject.transform.Translate(0.0f, 0.0f, -speed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        
    }

    private void FixedUpdate() {
        
    }
}
