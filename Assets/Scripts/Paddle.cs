using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Paddle : MonoBehaviour
{

    [SerializeField]private float speed = 10f;
    private float clampX = 15f;
    private float moveInput = 0f;

    private Vector3 paddlePosition;

    private void Awake()
    {
        paddlePosition.y = -9f;
    }

    private void Update()
    {

        if (GameInputs.Instance.IsLeftKeyPressed())
        {
            paddlePosition.x -= speed * Time.deltaTime;
        }
        if (GameInputs.Instance.IsRightKeyPressed())
        {
            paddlePosition.x += speed * Time.deltaTime;
        }
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, -clampX, clampX);

        transform.position = paddlePosition;    
    }
}
