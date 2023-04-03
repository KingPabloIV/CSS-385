using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera cam;

    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField]private float zoomLerpSpeed = 10f;
    [SerializeField]private float minZoom = 2f;
    [SerializeField]private float maxZoom = 20f;
    private float currentZoom;

    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        
        currentZoom = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKey(KeyCode.UpArrow)) {
            currentZoom += 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            currentZoom -= 0.1f;
        }

        

        if (Input.GetKey(KeyCode.LeftArrow)) {
            cam.transform.position += new Vector3(-0.1f, 0, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            cam.transform.position += new Vector3(0.1f, 0, 0);
        }

        targetZoom -= currentZoom * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        if (Input.GetKey(KeyCode.C)){
            targetZoom = 0;
        }
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
