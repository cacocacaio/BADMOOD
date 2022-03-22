using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private PlayerController parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        parent.Invoke(gameObject.name + "In", 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.Invoke(gameObject.name + "Out", 0f);
    }
}
