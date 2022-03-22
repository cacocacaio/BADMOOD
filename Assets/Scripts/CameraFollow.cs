using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform focus1;
    public Transform focus2;
    public float distance;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
		Vector2 position = Vector2.ClampMagnitude(Vector2.Lerp(focus1.position, focus2.position, 0.5f), distance);
		transform.position = Vector2.Lerp(transform.position, position, smoothing);
    }
}
