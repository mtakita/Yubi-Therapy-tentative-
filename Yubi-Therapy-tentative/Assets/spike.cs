using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour, IgeneratorRef
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
		
	}
}
