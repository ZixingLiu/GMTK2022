using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Vector3 lastVelocity;

    TrajectoryLine tl;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tl = GetComponent<TrajectoryLine>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;
            Debug.Log(startPoint);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15f;

            tl.RenderLine(startPoint, currentPoint);
        }

        if(Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15f;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
