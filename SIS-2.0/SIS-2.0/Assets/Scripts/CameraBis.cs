using UnityEngine;
using Mirror;

public class CameraBis : MonoBehaviour
{
    public float mouseSensitivity = 1250f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Verrouille le curseur au milieu de l'écran
    }

    void Update()
    {
        /*if(!isLocalPlayer)
        {
            return;
        }*/

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 10 * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Bloque la rotation à 90° vers le bas et le haut

            transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
            playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
        }
        
    }

}
