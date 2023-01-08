using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactFx;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceOnThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceOnThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceOnThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject fxInstance = Instantiate(impactFx, transform.position, transform.rotation);
        Destroy(fxInstance, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform _enemy)
    {
        Enemy enemy = _enemy.GetComponent<Enemy>();

        if (enemy != null)
            enemy.TakeDamage(damage);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
