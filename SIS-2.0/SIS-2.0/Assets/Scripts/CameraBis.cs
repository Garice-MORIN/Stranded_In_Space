using UnityEngine;

public class CameraBis : MonoBehaviour
{

    //public Variables variables;

    public Transform playerBody;

    float xRotation = 0f;

    int inverted;
    int sensitivity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    //Lock le curseur au milieu de l'écran au moment de la connexion
        inverted = PlayerPrefs.GetInt("Inverted");
        sensitivity = PlayerPrefs.GetInt("MouseSensitivity");
    }

    public void UpdateCamera()
    {
        float vertRotate = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime ;
        float horRotate = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= horRotate;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Bloque la rotation à 90° vers le bas et le haut

        playerBody.Rotate(0f, vertRotate * inverted, 0f); //Tourne la capsule
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);  //Tourne la caméra 
    }
}