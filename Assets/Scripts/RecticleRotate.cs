using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecticleRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private Vector3 rotationDirection = Vector3.up;

    void Update()
    {
        if(gameObject.activeInHierarchy) {
            transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);      
        }
    }
}
