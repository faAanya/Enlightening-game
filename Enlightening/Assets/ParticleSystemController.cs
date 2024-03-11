using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{

    public ParticleSystem particles;
    [SerializeField]
    private Rigidbody2D playerRB;

    [Range(0, 0.2f)]
    [SerializeField]
    float particleFormationPeriod;

    private PlayerController playerController;
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        Rotate();
        // if (playerRB.velocity != Vector2.zero && !particles.isEmitting)
        // {
        //     particles.Play();
        //     counter = 0;
        // }
        // else
        // {
        //     particles.Stop();
        // }
    }
    public void Rotate()
    {
        Vector3 rotation = playerController.transform.position.normalized;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        Debug.Log(rot);
        gameObject.transform.rotation = Quaternion.Euler(rot, -90, 90);
    }
}
