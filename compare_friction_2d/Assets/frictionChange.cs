using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frictionChange : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D col;


    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.sharedMaterial.friction = 0.3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            col.sharedMaterial.friction +=0.05f;
            Debug.Log("Friction is now: " + col.sharedMaterial.friction);
        }
    }
}
