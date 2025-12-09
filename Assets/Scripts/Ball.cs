using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialBallSpeed;
    [SerializeField] private Paddle paddle;

    private Rigidbody2D ballRigidbody2D;
    private bool isPlay=false;
    private float ballLaunchRange = 0.5f;
    private Vector3 paddleOffset;
    
    private void Awake()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();

        
    }
    private void Start()
    {
       
        if(paddle)
        {
            paddleOffset = transform.position - paddle.transform.position;
        }
        GameInputs.Instance.OnLaunch += Ball_OnLaunch;
    }

    private void Update()
    {
        if (!isPlay)
        {
            if (paddle)
            {
                transform.position = paddle.transform.position + paddleOffset;
            }
        }
    }


    private void Ball_OnLaunch(object sender, System.EventArgs e)
    {
        if (!isPlay)
        {
            LaunchBall();

        }

    }


    private void LaunchBall()
    {
        isPlay = true;
        Vector2 ballDirection = new Vector2(Random.Range(-ballLaunchRange, ballLaunchRange),1).normalized;
        ballRigidbody2D.linearVelocity = ballDirection * initialBallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Paddle paddle))
        {
            float paddleX = collision.transform.position.x;
            float contactX= transform.position.x;
            float diff=contactX - paddleX;
            float scaleX = 5f;
            Vector2 newDirection = new Vector2(diff*scaleX,Mathf.Abs(ballRigidbody2D.linearVelocity.y)).normalized;
            ballRigidbody2D.linearVelocity= newDirection*initialBallSpeed;
            Debug.Log("new Velocity :"+ballRigidbody2D.linearVelocity.magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Wall wall))
        {
            isPlay = false;
            ResetBall();
        }
    }
    private void ResetBall()
    {
        //transform.position = Vector3.zero;
        ballRigidbody2D.linearVelocity = Vector2.zero;
        isPlay = false;
    }
}
