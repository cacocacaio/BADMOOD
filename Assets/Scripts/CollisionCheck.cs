using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private PhysicsInterface parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<PhysicsInterface>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        parent.Invoke(gameObject.name + "In");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.Invoke(gameObject.name + "Out");
    }
}
