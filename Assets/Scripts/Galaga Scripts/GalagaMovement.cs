using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GalagaMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bullet;
    public Image[] lives;
    public int lifeCount = 3;
    public bool hasPowerUp = false;
    public float timer = 0, powerUpDuration = 5f;

    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

         if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }

        if(hasPowerUp)
        {
            timer += Time.deltaTime;
            if(timer <= powerUpDuration)
            {
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    Instantiate(bullet, transform.position + new Vector3(0, .75f, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(-.25f, .5f, 0), Quaternion.identity);
                    Instantiate(bullet, transform.position + new Vector3(.25f, .5f, 0), Quaternion.identity);
                }
            }
            else if(timer > powerUpDuration)
            {
                hasPowerUp = false;
                timer = 0;
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(bullet, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
            }
        }
        // if(Input.GetKeyUp(KeyCode.Space))
        // {
        //     Instantiate(bullet, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
        // }
        

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, -4, 4), 0);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           lifeCount -= 1;
           if (lifeCount <= 0)
           {
                lifeCount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           }
           lives[lifeCount].enabled = false;
        }

        if(collision.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(collision.gameObject);
        }
        
    }
}
