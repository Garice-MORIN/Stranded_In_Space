using UnityEngine;
using Mirror;

public class test : NetworkBehaviour
{
    void OnstartLocalPlayer()
    {
        gameObject.GetComponent<CameraBis>().enabled = true;
    }
}
