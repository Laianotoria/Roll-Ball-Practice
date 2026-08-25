using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    public int winCount;
    int count = 0;
    public GameObject winText;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -5)
        {
            SceneManager.LoadScene("game");
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput * speed, 0, yInput * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            count++;

            Destroy(other.gameObject);

            if(count >= winCount)
            {
                winText.SetActive(true);
            }
        }
    }

}
