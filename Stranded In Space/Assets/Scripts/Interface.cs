using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Text life;
    public Text waveInfo;
    public PlayerMovement player;
    public Spawner spawner;

    int numberOfEnemies;
    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemies").Length;
        life.text = "Player life is : " + player.life.ToString();
        waveInfo.text = "You're currently on wave : " + spawner.waveNumber.ToString() +
                         "\nThere " + Pluriel(numberOfEnemies) + " " + numberOfEnemies.ToString() + " " + PlurielBis(numberOfEnemies) + " left";
    }

    string Pluriel(int number)
    {
        if(number == 1)
        {
            return "is";
        }
        else
        {
            return "are";
        }
    }

    string PlurielBis(int number)
    {
        if(number == 1)
        {
            return "enemy";
        }
        else
        {
            return "enemies";
        }
    }


}
