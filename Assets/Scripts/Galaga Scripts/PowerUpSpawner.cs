using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    
    public GameObject powerUps;
    public float powerUpTimer = 0, powerUpWait = 15f;

    // Update is called once per frame
    void Update()
    {
        powerUpTimer += Time.deltaTime;
        if(powerUpTimer>powerUpWait)
        {
            powerUpTimer = 0;
            Instantiate(powerUps, transform.position - new Vector3(Random.Range(-3f, 3f), .5f, 0), Quaternion.identity);
        }
        
    }
}
