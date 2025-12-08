using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialBallSpeed;

    private Rigidbody2D ballRigidbody2D;
    private bool isPlay=false;
    private float ballLaunchRange = 0.5f;

    private void Awake()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();

        
    }
    private void Start()
    {
        GameInputs.Instance.OnLaunch += Ball_OnLaunch;
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
        Vector2 balldirection = new Vector2(Random.Range(-ballLaunchRange, ballLaunchRange),1).normalized;
        ballRigidbody2D.linearVelocity = balldirection * initialBallSpeed * Time.deltaTime;
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
        transform.position = Vector3.zero;
        ballRigidbody2D.linearVelocity = Vector2.zero;
    }
}
