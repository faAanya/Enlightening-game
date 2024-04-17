using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    public float range;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().health -= damage;
        }
        if (collider.gameObject.tag == "Comete")
        {
            collider.gameObject.GetComponent<CometeEnemy>().enemy.health -= damage;
        }
        if (collider.gameObject.tag == "Spawner")
        {
            collider.gameObject.GetComponent<Spawner>().health -= damage;
        }
    }
}
