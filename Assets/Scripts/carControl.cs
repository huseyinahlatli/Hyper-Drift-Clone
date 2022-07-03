using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carControl : MonoBehaviour
{

    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float steerAngle; // sağa sola dönme değişkeni
    [SerializeField] float traction;
    
    public GameObject redCar;
    public GameObject text;

    Vector3 _moveVector;
    Vector3 _rotVector;

    public float dragAmount;
    public Transform lw, rw;

    void Update()
    {
        if(redCar.transform.position.y >= -5)
        {
            _moveVector += transform.forward * carSpeed * Time.deltaTime;
            transform.position += _moveVector * Time.deltaTime;

            _rotVector += new Vector3(0, Input.GetAxis("Horizontal"), 0);

            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVector.magnitude);

            _moveVector *= dragAmount;
            _moveVector = Vector3.ClampMagnitude(_moveVector, maxSpeed);
            _moveVector = Vector3.Lerp(_moveVector.normalized, transform.forward, traction * Time.deltaTime) * _moveVector.magnitude;
    
            _rotVector = Vector3.ClampMagnitude(_rotVector, steerAngle); // Tekerleklerin dönme açısı
            lw.localRotation = Quaternion.Euler(_rotVector);
            rw.localRotation = Quaternion.Euler(_rotVector);
        }

        else
        {
            redCar.transform.position = new Vector3(redCar.transform.position.x, -6, redCar.transform.position.z);
            
            text.SetActive(true); // oyun bitince text gösterilecek.

            if(Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("Day");
        }
    }
}
