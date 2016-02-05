using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public static Portal Inst = null;

    public GameObject Stargate = null;

	// Use this for initialization
	void Start () {
        Inst = this;

    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject == Player.Inst.gameObject )
        {
            if (Podium.Inst.PortalOpen)
            {
                Application.LoadLevel(0);
            }
        }
    }
}
