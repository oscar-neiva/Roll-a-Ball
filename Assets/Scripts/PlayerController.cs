using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private int count;

    public Text countText;
    public Text winText;
    public float speed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetText();
    }

    // Called before every render frame
    /*void Update()
    {

    }*/

    // Called before every step simulation
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetText();
        }
    }

    void SetText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 16)
        {
            winText.text = "You Win";
        }
    }
}