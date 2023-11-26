using UnityEngine;

public class Tranpolim : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;
    private bool IsAnimatorName(string name) => anim.GetCurrentAnimatorStateInfo(0).IsName(name);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb == null && rb.bodyType == RigidbodyType2D.Dynamic)
            return;
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        if (IsAnimatorName("idle"))
            anim.SetTrigger("bounce");
        if(audioSource.isPlaying)
            audioSource.time = 0f;
        else
            audioSource.Play();
    }
}