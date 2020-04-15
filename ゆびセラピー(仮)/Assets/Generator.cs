using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject size_s_prefab;
    public GameObject size_m_prefab;
    public GameObject size_l_prefab;
    public GameObject spike_prefab;

    public GameObject touch_prefab;

    const int size_s_max = 10;
    const int size_m_max = 5;
    const int size_l_max = 2;
    const int spike_max = 2;

    int numOfSizeS = 0;
    int numOfSizeM = 0;
    int numOfSizeL = 0;
    int numOfSpike = 0;

    GameObject touch;

    // Use this for initialization
    void Start () {
		
	}

    public Vector3 GetTouchDirection(Vector3 position)
    {
        Vector3 direction = touch.transform.position - position;
        return direction.normalized;
    }

    public bool IsInTouchRadius(Vector3 position)
    {
        if (touch == null)
        {
            return false;
        }

        touch tc = (touch)touch.GetComponent(typeof(touch));

        return tc.IsInRadius(position);
    }

    public Vector3 GetTouchPosition()
    {
        if (touch == null)
        {
            return new Vector3(0.0f, 0.0f, 0.0f );
        }

        Transform trans = touch.GetComponent<Transform>();
        return trans.position;
    }

    public float GetTouchInfrationLevel()
    {
        if( touch == null)
        {
            return 0;
        }

        touch tc = (touch)touch.GetComponent( typeof(touch) );

        return tc.GetInfrationLevel();
    }
    
    // called when touch object is going to be destroyed.
    public void touchDestroy()
    {
        touch = null;
    }

    void addAnySize( GameObject anySize )
    {
        float x = 6 * Random.value - 3;
        float y = 10 * Random.value - 5;

        Vector3 location;
        location.x = x;
        location.y = y;
        location.z = 0;

        GameObject newObject = (GameObject)Instantiate( anySize, location, Quaternion.identity);

        IgeneratorRef iGen = (IgeneratorRef)newObject.GetComponent(typeof(IgeneratorRef));
        iGen.SetGenerator(this);

    }

    void addSizeS()
    {
        addAnySize(size_s_prefab);
    }

    void addSizeM()
    {
        addAnySize(size_m_prefab);
    }

    void addSizeL()
    {
        addAnySize(size_l_prefab);
    }

    void addSpike()
    {
        addAnySize(spike_prefab);
    }

    // Update is called once per frame
    void Update () {

        if (numOfSizeS < size_s_max)
        {
            numOfSizeS++;
            addSizeS();
        }

        if (numOfSizeM < size_m_max)
        {
            numOfSizeM++;
            addSizeM();
        }

        if (numOfSizeL < size_l_max)
        {
            numOfSizeL++;
            addSizeL();
        }

        if (numOfSpike < spike_max)
        {
            numOfSpike++;
            addSpike();
        }





        processTouch();


    }

    void processTouch()
    {
        if(Input.GetButtonDown( "Fire1" ))
        {
            touch = (GameObject)Instantiate(touch_prefab, transform.position, Quaternion.identity);
            IgeneratorRef tc = (IgeneratorRef)touch.GetComponent(typeof(IgeneratorRef));
            tc.SetGenerator(this);

        }
    }

}
