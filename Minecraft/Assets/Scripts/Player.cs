using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Inst = null;

    public float ReachDistance = 3.0f;
    public LayerMask ReachMask;

    public float ExplosivePower = 3.0f;

    public int NumBlocks = 0;
    public int MaxBlocks = 10;

    public Texture Crosshair = null;
    public float CrosshairScale = 1.0f;

    public GameObject ExplodeEffect = null;
    public AudioClip PlaceDirt = null;
    public AudioClip RemoveDirt = null;
    public AudioClip RemoveRock = null;
    public AudioClip RemoveChunk = null;
    public AudioClip GotGems = null;

	public bool[] heldGems;

	void Start ()
    {
        Inst = this;

		transform.position = new Vector3(transform.position.x,
			VoxelWorld.Inst.ChunksHigh * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize + 1, transform.position.z);

		heldGems = new bool[GemSpawning.Inst.numGems];
	}
	
	void Update ()
    {
        if (Camera.main != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray CrosshairRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                AttackBlock(CrosshairRay);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Ray CrosshairRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                PlaceBlock(CrosshairRay, VoxelType.Dirt);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                Ray CrosshairRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                ExplodeBlock(CrosshairRay, ExplosivePower);
            }

            Vector3 currentPosition = transform.position;
            float voxelsDeep = VoxelWorld.Inst.ChunksDeep * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;
            float voxelsWide = VoxelWorld.Inst.ChunksWide * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;

            if (currentPosition.x < 0)
                currentPosition.Set(0, currentPosition.y, currentPosition.z);
            if (currentPosition.x > voxelsWide)
                currentPosition.Set(voxelsWide, currentPosition.y, currentPosition.z);
            if (currentPosition.z < 0)
                currentPosition.Set(currentPosition.x, currentPosition.y, 0);
            if (currentPosition.z > voxelsDeep)
                currentPosition.Set(currentPosition.x, currentPosition.y, voxelsDeep);

            transform.position = currentPosition;
        }
	}

	void OnTriggerEnter(Collider other)
	{
		Gem gem = other.GetComponent<Gem>();
		if(gem != null)
		{
            heldGems[gem.index] = true;
			gem.holder = gameObject;
			gem.isHeld = true;
            this.GetComponent<AudioSource>().PlayOneShot(GotGems);
        }
		
	}

    void AttackBlock(Ray ray)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, ReachDistance, ReachMask))
        {
            if (hitInfo.collider is BoxCollider)
            {
                Voxel voxel = VoxelWorld.Inst.GetVoxelFromCollider(hitInfo.collider as BoxCollider);
                if (voxel != null)
                {
                    voxel.TakeDamage(1);

                    this.GetComponent<AudioSource>().PlayOneShot(RemoveDirt);


                    if( voxel.TypeDef.Type == VoxelType.Air)
                    {
                        ++NumBlocks;
                        if (NumBlocks > MaxBlocks)
                        {
                            NumBlocks = MaxBlocks;
                        }
                    }

                }
            }
        }
    }

    void PlaceBlock(Ray ray, VoxelType type)
    {
        if (NumBlocks <= 0 )
        {
            return;
        }
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, ReachDistance, ReachMask))
        {
            if (hitInfo.collider is BoxCollider)
            {
                Voxel voxel = VoxelWorld.Inst.GetVoxelFromCollider(hitInfo.collider as BoxCollider);
                if (voxel != null)
                {
                    float threshold = 0.1f;
                    IntVec3 offset = new IntVec3(0, 0, 0);
                    if (hitInfo.normal.y > threshold)
                        offset.Y = 1;
                    else if (hitInfo.normal.x > threshold)
                        offset.X = 1;
                    else if (hitInfo.normal.z > threshold)
                        offset.Z = 1;
                    else if (hitInfo.normal.y < -threshold)
                        offset.Y = -1;
                    else if (hitInfo.normal.x < -threshold)
                        offset.X = -1;
                    else if (hitInfo.normal.z < -threshold)
                        offset.Z = -1;
                    IntVec3 placePos = voxel.Position.Offset(offset);
                    if (VoxelWorld.Inst.IsVoxelWorldIndexValid(placePos.X, placePos.Y, placePos.Z))
                    {
                        Voxel placeVoxel = VoxelWorld.Inst.GetVoxel(placePos);
                        if (placeVoxel.TypeDef.Type == VoxelType.Air)
                        {
                            placeVoxel.SetType(type);
                            VoxelWorld.Inst.Refresh();

                            this.GetComponent<AudioSource>().PlayOneShot(PlaceDirt);

                            NumBlocks--;

                        }
                    }
                }
            }
        }
    }

    void ExplodeBlock(Ray ray, float radius)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, ReachDistance, ReachMask))
        {
            if (hitInfo.collider is BoxCollider)
            {
                List<Voxel> voxels = VoxelWorld.Inst.GetVoxels(hitInfo.point, radius);
                voxels.ForEach(vox => vox.TakeDamage(3));
                VoxelWorld.Inst.Refresh();

                GameObject.Instantiate(ExplodeEffect, hitInfo.point, Quaternion.identity);
                this.GetComponent<AudioSource>().PlayOneShot(RemoveChunk);
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
