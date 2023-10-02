using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaterObject : MonoBehaviour
{
    [SerializeField] private GameObject shaterVersion;

    public void DestroyObjectAfterExplodion()
    {
        Instantiate(shaterVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
