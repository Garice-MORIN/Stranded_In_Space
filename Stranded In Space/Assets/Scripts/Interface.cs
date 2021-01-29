using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Text life;
    public Text waveInfo;
    public PlayerMovement player;
    public Spawner spawner;

    // Update is called once per frame
    void Update()
    {
        life.text = "Player life is : " + player.life.ToString();
        waveInfo.text = "You're currently on wave : " + spawner.waveNumber.ToString() +
                         "\n There is " + GameObject.FindGameObjectsWithTag("Enemies").Length.ToString() + " enemies left";
    }
}
