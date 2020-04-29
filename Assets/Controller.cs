using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private bool onGround;
    float count;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0, 5, 0);
                onGround = false;
            }
        }
    }

    void FixedUpdate()
    {

        float moveHorizntal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(moveHorizntal, 0, moveVertical);

        rb.AddForce(mov * speed);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
           // SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

    }
}

