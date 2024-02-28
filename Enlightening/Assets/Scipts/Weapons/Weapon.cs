using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector]
    public float damage;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Enemy"){
            collider.gameObject.GetComponent<Enemy>().health -= damage;
        }
    }
}
