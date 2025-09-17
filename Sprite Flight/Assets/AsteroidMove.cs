using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 0.1f;
    public float collisionForceMultiplier = 0.1f;
    public float torqueMultiplier = 0.05f;

    public float randomForceInterval = 2f;
    public float randomForceMagnitude = 0.05f;
    public float randomTorqueMagnitude = 0.01f;
    float minSize = 0.5f;
    float maxSize = 2.0f;

    // No manual velocity needed
    private Rigidbody2D rb;

    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        rb = GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector2 initialVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
        rb.linearVelocity = initialVelocity;
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Vector2 bounce = Vector2.Reflect(rb.linearVelocity, collision.contacts[0].normal);
            float boost = Random.Range(0.15f, 0.2f);
            bounce += collision.contacts[0].normal * boost;
            float maxSpeed = 5f;
            if (bounce.magnitude > maxSpeed)
                bounce = bounce.normalized * maxSpeed;
            rb.linearVelocity = bounce;
        }
        else if (collision.gameObject.name == "Asteroid")
        {
            Asteroid other = collision.gameObject.GetComponent<Asteroid>();
            if (other != null)
            {
                Vector2 v1 = rb.linearVelocity;
                Vector2 v2 = other.rb.linearVelocity;
                rb.linearVelocity = v2;
                other.rb.linearVelocity = v1;
            }
        }


    }

    private int RandomSign()
    {
        return Random.value > 0.5f ? 1 : -1;
    }
}
