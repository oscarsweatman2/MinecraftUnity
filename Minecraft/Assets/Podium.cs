using UnityEngine;
using System.Collections;

public class Podium : MonoBehaviour {

    public static Podium Inst = null;

    public bool PortalOpen = false;

    public GameObject Crystals = null;

	// Use this for initialization
	void Start () {
        Inst = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Inst.gameObject)
        {
            Debug.Log("Player hit me!!!");

            int heldGemCounter = 0;

            for (int i = 0; i < Player.Inst.heldGems.Length; ++i)
            {
                if (Player.Inst.heldGems[i])
                {
                    ++heldGemCounter;
                }
            }

            if (heldGemCounter >= 3)
            {
                PortalOpen = true;
                Portal.Inst.Stargate.SetActive(true);
                Crystals.SetActive(true);
            }
        }
    }
}
