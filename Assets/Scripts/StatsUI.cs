using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretextMesh;

    private void Update()
    {
        scoretextMesh.text = "Score :"+GameManager.Instance.GetScore();
    }
}
