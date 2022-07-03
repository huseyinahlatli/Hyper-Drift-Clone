using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{

    public Transform target; // kamera hedef
    public Vector3 offset; // aradaki takip mesafesi
    public float cameraSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);
    }
}
