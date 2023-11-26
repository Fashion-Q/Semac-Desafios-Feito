using UnityEngine;
public class NextStage1 : MonoBehaviour
{
    [SerializeField] private string NextStage;
    [SerializeField] private GameController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            controller.NextStage(NextStage);
        }
    }
}
