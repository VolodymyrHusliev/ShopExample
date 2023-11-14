using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private bool isGround;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Jump()
    {
        if (isGround)
        {
            rb.AddForce(0f,5f, 0f, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void Update()
    {
        Jump();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}


