using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour {

    public GameObject RedCrystalUI = null;
    public GameObject BlueCrystalUI = null;
    public GameObject GreenCrystalUI = null;
    public Text BlockText = null; 
    

    void Update()
    {
        int totalGems = 0;

        foreach(bool hasGem in Player.Inst.heldGems)
        {
            if (hasGem)
                ++totalGems;
        }
        if (totalGems == 0)
        {
            RedCrystalUI.SetActive(false);
            BlueCrystalUI.SetActive(false);
            GreenCrystalUI.SetActive(false);
        }
        else if (totalGems == 1)
        {
            RedCrystalUI.SetActive(true);
            BlueCrystalUI.SetActive(false);
            GreenCrystalUI.SetActive(false);
        }
        else if (totalGems == 2)
        {
            RedCrystalUI.SetActive(true);
            BlueCrystalUI.SetActive(true);
            GreenCrystalUI.SetActive(false);
        }
        else if (totalGems == 3)
        {
            RedCrystalUI.SetActive(true);
            BlueCrystalUI.SetActive(true);
            GreenCrystalUI.SetActive(true);
        }
        BlockText.text = "x" + Player.Inst.NumBlocks;
    }
}
