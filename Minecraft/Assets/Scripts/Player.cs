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
                    if (hitInfo.collider is BoxCollider)
                    {
                        Voxel voxel = VoxelWorld.Inst.GetVoxelFromCollider(hitInfo.collider as BoxCollider);
                        if (voxel != null)
                        {
                            voxel.TakeDamage(1);
                        }
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
