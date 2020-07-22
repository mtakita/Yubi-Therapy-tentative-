using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size_l : MonoBehaviour, IgeneratorRef
{
    Generator generator;

    public void SetGenerator(Generator inGenerator)
    {
        generator = inGenerator;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool isInRadius = generator.IsInTouchRadius(transform.position);
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (isInRadius == true)
        {
            Vector3 direction = generator.GetTouchDirection(transform.position);
            float thrust = 1.0f;
            body.AddRelativeForce(thrust * direction);
        }
        else
        {
        }

    }
}
