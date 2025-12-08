using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private float testPlayerSpeed;

    private GameControls gameControls;
    private Vector2 moveDirection;

    private void Awake()
    {
        gameControls = new GameControls();
        gameControls.Enable();
        gameControls.GamePlay.Vector2Movement.performed += Vector2Movement_performed;

    }

    private void Vector2Movement_performed(InputAction.CallbackContext obj)
    {
        moveDirection = obj.ReadValue<Vector2>();
    }
   

    private void Update()
    {
        transform.position += new Vector3(moveDirection.x * testPlayerSpeed*Time.deltaTime, moveDirection.y * testPlayerSpeed*Time.deltaTime, 0);
    }
    public void OnVector2Movement(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
        
    }

}
