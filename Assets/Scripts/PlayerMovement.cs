using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
   public float speed = 4;
   private int scoreVal = 0;

   //private bool isProtected = false;

   //private float protectionTimer = 0, protectionWait = 5;

    public TMPro.TextMeshProUGUI scoreBox;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }

        //To keep the object from moving off screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            if(collision.GetComponent<ProjectileMove>() != null)
            {
                
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBox.text = "Score: " + scoreVal;
            }

            Destroy(collision.gameObject);
        }
        
    }
}
