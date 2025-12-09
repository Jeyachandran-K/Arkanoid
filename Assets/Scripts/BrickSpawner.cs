using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private Transform brickSpawnerInitialLocation;

    private int rows = 10;
    private int cols = 13;
    private Vector2 spawnLocation;
    private float spacingX ;
    private float spacingY ;
    private const float BRICK_LENGTH = 2.5f;
    private const float BRICK_WIDTH = 0.75f;

    private void Awake()
    {
       spawnLocation = brickSpawnerInitialLocation.position;
        SpawnBricks();
    }

    private void SpawnBricks()
    {
        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Instantiate(brickPrefab,new Vector3(spawnLocation.x+spacingX,spawnLocation.y+spacingY,0), Quaternion.identity);
                spacingX += BRICK_LENGTH;
            }
            spacingX = 0;
            spacingY -= BRICK_WIDTH;
        }
    }
}
