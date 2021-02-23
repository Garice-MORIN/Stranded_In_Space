using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Interface : NetworkBehaviour
{
    public Text health;
    public GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        health.text = "You currently have " + gameObject.GetComponentInParent<Health>().health.ToString()
            + " health points";
    }
}
