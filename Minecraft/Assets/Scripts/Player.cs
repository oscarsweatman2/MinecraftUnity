using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float ReachDistance = 3.0f;
    public LayerMask ReachMask;

    public Texture Crosshair = null;
    public float CrosshairScale = 1.0f;

	void Start ()
    {
        transform.position = new Vector3(VoxelTerrain.Inst.XLen * 0.5f, VoxelTerrain.Inst.YLen + 10.0f, VoxelTerrain.Inst.ZLen * 0.5f);
	}
	
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            if (Camera.main != null)
            {
                RaycastHit hitInfo;
                Ray CrosshairRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(CrosshairRay, out hitInfo, ReachDistance, ReachMask))
                {
                    Voxel voxel = VoxelTerrain.Inst.GetVoxelFromCollider(hitInfo.collider);
                    if (voxel != null)
                    {
                        voxel.TakeDamage(1);
                    }
                }
            }
        }
	}

    void OnGUI()
    {
        float cx = Screen.width * 0.5f;
        float cy = Screen.height * 0.5f;
        float halfWidth = Crosshair.width * 0.5f * CrosshairScale;
        float halfHeight = Crosshair.height * 0.5f * CrosshairScale;
        GUI.DrawTexture(new Rect(cx - halfWidth, cy - halfHeight, Crosshair.width * CrosshairScale, Crosshair.height * CrosshairScale), Crosshair);
    }
}
