using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50f; // Speed of movement
    private float targetX; // Target x position to move towards
    private float laneWidth = 32f; // The width between the lanes
    public bool isFreeMovement = false;

    void Start()
    {
        targetX = transform.position.x; // Set initial x position
    }

    void Update()
    {
        if (isFreeMovement)
        {
            HandleFreeMovement();
        }
        else
        {
            HandleMovement();

        }
    }
    void HandleFreeMovement()
    {
        if(this.transform.position.x > -32 && this.transform.position.x < 32)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

           
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            }
        }
    }

    void HandleMovement()
    {
        // Get input from arrow keys or swipe gestures to move between lanes
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            targetX = Mathf.Clamp(targetX - laneWidth, -32f, 32f);
            //targetX = -32f;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            targetX = Mathf.Clamp(targetX + laneWidth, -32f, 32f);
            //targetX = 32f;

        // Smoothly move to the target position on the x-axis
        Vector3 targetPosition = new(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            UIManager.Instance.OnBombHit();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected");
            Destroy(collision.gameObject);
            UIManager.Instance.OnCoinCollected();
        }
        if(collision.gameObject.CompareTag("Life"))
        {
            Debug.Log("Life Collected");
            Destroy(collision.gameObject);
            UIManager.Instance.OnLifeHit();
        }
    }
    public void ToggleFreeMovement(bool freeMovement)
    {
         isFreeMovement = freeMovement;
    }
}
