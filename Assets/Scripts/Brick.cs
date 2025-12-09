using UnityEngine;

public class Brick : MonoBehaviour
{
    private int scorPoints=100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            GameManager.Instance.AddScore(scorPoints);
            Destroy(gameObject);

        }
    }

}
