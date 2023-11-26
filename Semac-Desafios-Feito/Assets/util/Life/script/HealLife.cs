using UnityEngine;

public class HealLife : MonoBehaviour
{
    private bool PotionConsumed { get; set; } = false;
    [SerializeField] private LayerMask layersCollection;
    [SerializeField] private int healLife;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((layersCollection & (1 << col.gameObject.layer)) != 0)
        {
            if (!PotionConsumed)
            {
                PotionConsumed = true;
                col.GetComponent<ICombateEntity>().life += healLife;
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetTrigger("drinkPotion");
            }
        }
    }
}
