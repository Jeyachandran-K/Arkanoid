using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public static GameInputs Instance {  get; private set; }

    private GameControls gameControls;

    private float moveInput = 0f;
    private Vector2 input;

    private void Awake()
    {
        Instance = this;
        gameControls = new GameControls();
        gameControls.Enable();
    }
    public bool IsRightKeyPressed()
    {
        return gameControls.GamePlay.RightMovement.IsPressed();
    }
    public bool IsLeftKeyPressed()
    {
        return gameControls.GamePlay.LeftMovement.IsPressed();
    }

}
