using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour
{
    public GemColor color;
	public int index;
	public bool isHeld = false;
	public GameObject holder = null;

    void Start()
    {

    }

    void Update()
    {
		if(isHeld)
		{
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<SphereCollider>().enabled = false;
			transform.position = holder.transform.position;
		}
		else
		{
			GetComponent<MeshRenderer>().enabled = true;
			GetComponent<SphereCollider>().enabled = true;
		}
    }
}

public enum GemColor
{
    Red,
    Green,
    Blue,
    NumColors
}