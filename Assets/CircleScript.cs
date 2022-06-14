using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
	public Rigidbody2D rb;
	
	private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale -= Vector3.one * speed * Time.fixedDeltaTime;

		if(transform.localScale.x <= 0.05f)
		{
			Destroy(gameObject);
		}
    }
}
