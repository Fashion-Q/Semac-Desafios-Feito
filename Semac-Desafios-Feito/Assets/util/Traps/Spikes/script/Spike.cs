using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private ICombateEntity combateEntity;
    [SerializeField] private int damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        combateEntity = collision.GetComponent<ICombateEntity>();
        if (combateEntity == null)
            return;
        combateEntity.Hurt(damage);
    }
}
