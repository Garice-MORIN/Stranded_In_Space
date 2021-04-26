﻿using UnityEngine;

public class CameraBis : MonoBehaviour
{

    public Variables variables;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    //Lock le curseur au milieu de l'écran au moment de la connexion
    }

    public void UpdateCamera()
    {
        float vertRotate = Input.GetAxis("Mouse X") * variables.mouseSensitivity * Time.deltaTime ;
        float horRotate = Input.GetAxis("Mouse Y") * variables.mouseSensitivity * Time.deltaTime;

        xRotation -= horRotate;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Bloque la rotation à 90° vers le bas et le haut

        playerBody.Rotate(0f, vertRotate * variables.inverted, 0f); //Tourne la capsule
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);  //Tourne la caméra 
    }
}