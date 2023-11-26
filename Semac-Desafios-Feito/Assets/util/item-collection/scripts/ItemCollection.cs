using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private bool ItemColleted { get; set; } = false;
    [SerializeField] private LayerMask layersCollection;

    [SerializeField] private int incrementScore;

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((layersCollection & (1 << col.gameObject.layer)) != 0)
        {
            if(!ItemColleted)
            {
                ItemColleted = true;
                gameController.SaveItemCollection(incrementScore);
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("collect");
            }
        }
    }
    [SerializeField] private void DestroyItemCollected ()
    {
        Destroy(gameObject);
    }
}
