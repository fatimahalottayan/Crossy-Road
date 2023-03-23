using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class PlayerMovment : MonoBehaviour
{
    /// <summary>
    /// event will be invoked when the player move over Z axis.
    /// </summary>
    public event Action Moved;

    [SerializeField] TextMeshProUGUI TextHealth;
    [SerializeField] GameObject GameOver;
    Vector3 targetPos;
    float smooth = 6f;
    int health = 5;

    void Start()
    {
        //display the health score in the game screen.
        TextHealth.text = "Health : " + health.ToString();
        targetPos = transform.position;

    }

    
    void Update()
    {
        Detect();
        MovePlayer();
    }

    /// <summary>
    /// this function will detect the player movment and make the jump. 
    /// </summary>
    void Detect()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos.z++;
            Moved?.Invoke();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos.z--;
            Moved?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x <= -8)
            {
                return;
            }
            targetPos.x--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x >= 8)
            {
                return;
            }
            targetPos.x++;
        }
        if (Input.GetKeyDown("space"))
        {

            // Jump
            LeanTween.cancel(gameObject);
            LeanTween.moveY(gameObject, transform.position.y + 3f, 1.5f).setEasePunch(); 
            targetPos.z +=5f;
            Moved?.Invoke();
        }

    }

    /// <summary>
    /// this function will be called each frame to move the player based on the detected movment.
    /// </summary>
    void MovePlayer()
    {
        if (transform.position.y > 0)
        {
            targetPos.y = 0;
        }

        Vector3 movment = Vector3.MoveTowards(transform.position, new Vector3(targetPos.x, targetPos.y ,targetPos.z), smooth*Time.deltaTime);
        transform.position = movment;
     
    }

    /// <summary>
    /// this function is unity call, so when collision hapend we will decrease the health score and check if game over.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            health--;

            //ckeck if game over.
            if (health <= 0)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90f);
                GameOver.SetActive(true);
                TextHealth.text = "Health : 0";
                //gameObject.SetActive(false);
            }
            else
            {
                //display the health score in the game screen after decreasing it.
                TextHealth.text = "Health : " + health.ToString();
            }
        }
        if (collision.gameObject.tag == "MainCamera")
        {
            GameOver.SetActive(true);
        }
    }

}
