using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public float speed = 4f;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        
    }

    
}
