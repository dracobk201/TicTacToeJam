using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Bullet Variables
    [Header("Bullet Variables")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private FloatReference BulletVelocity;
    [SerializeField]
    private FloatReference BulletTimeOfLife;
    [SerializeField]
    private GameEvent EnemyImpacted;
    [SerializeField]
    private GameEvent PlayerImpacted;
    [SerializeField]
    private GameEvent ObjectiveImpacted;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(AutoDestruction());
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.right * BulletVelocity.Value, ForceMode2D.Impulse);
    }

    private void Destroy()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(BulletTimeOfLife.Value);
        Destroy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string targetTag = other.tag;

        if (targetTag.Equals(Global.EnemyTag) && gameObject.tag.Equals(Global.PlayerBulletTag))
        {
            EnemyImpacted.Raise();
            Destroy();
        }
        else if (targetTag.Equals(Global.PlayerTag) && gameObject.tag.Equals(Global.EnemyBulletTag))
        {
            PlayerImpacted.Raise();
            Destroy();
        }
        else if (targetTag.Equals(Global.ObjectiveTag))
        {
            ObjectiveImpacted.Raise();
            Destroy();
        }
    }
}
