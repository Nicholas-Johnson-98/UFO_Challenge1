using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;             
    public Text CountText;
    public Text WinText;
    public Text LivesText;

    private Rigidbody2D rb2d;
    private int count;
    private int Lives;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        Lives = 3;
        WinText.text = "";
        SetCountText();
        SetLivesText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            Lives = Lives - 1;
            SetLivesText();
        }
        if (count == 12)
        {
            transform.position = new Vector2(0.0f, 46.0f);
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            WinText.text = "You win! Game created by Nicholas Johnson!";
        }
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        if (Lives <= 0)
        {
            WinText.text = "You Lose!";
            Destroy(gameObject);
        }
    }
}