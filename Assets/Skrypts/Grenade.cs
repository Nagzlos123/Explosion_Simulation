using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float dely = 4f;
    public float blastRadius = 5f;
    public float explodionForce = 7000f;
    public GameObject explosionEfect;
    private float contdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        contdown = dely;

    }

    // Update is called once per frame
    void Update()
    {
        contdown -= Time.deltaTime;

        if (contdown <= 0 && ! hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEfect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbuObject in collidersToDestroy)
        {
            ShaterObject shaterObject = nearbuObject.GetComponent<ShaterObject>();
            if(shaterObject != null)
            {
                shaterObject.DestroyObjectAfterExplodion();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbuObject in collidersToMove)
        {
            Rigidbody rigidbody = nearbuObject.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explodionForce, transform.position, blastRadius);
            }
            else
            {
                Debug.Log("Rigidbody isn't there!");
            }
            
        }
            Destroy(gameObject);
    }
}
