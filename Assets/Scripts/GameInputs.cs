using System;
using UnityEngine;

public class GameInputs : MonoBehaviour
{

    public event EventHandler OnLaunch;
    public static GameInputs Instance {  get; private set; }

    private GameControls gameControls;

    private void Awake()
    {
        Instance = this;
        gameControls = new GameControls();
        gameControls.GamePlay.Launch.performed += Launch_performed;

        gameControls.Enable();
    }

    private void Launch_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnLaunch?.Invoke(this,EventArgs.Empty);
    }

    private void OnDestroy()
    {
        gameControls.Disable();
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
