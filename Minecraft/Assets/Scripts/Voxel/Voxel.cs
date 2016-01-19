using UnityEngine;

public class Voxel
{
    public bool Enabled;
    public bool Exposed;

    public float Health;

    public IntVec3 Index;

    public BoxCollider Collider;
    public VoxelType Type;

    public Voxel[] Neighbors;

    public Voxel(IntVec3 index, BoxCollider collider)
    {
        Enabled = true;
        Exposed = true;
        Index = index;
        Collider = collider;
        Neighbors = new Voxel[Side.Num];
    }

    public void SetType(VoxelType type)
    {
        Type = type;
        Health = Type.Health;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0.0f)
            DestroyVoxel();
    }

    public void DestroyVoxel()
    {
        Enabled = false;
        Exposed = false;
        VoxelTerrain.Inst.UpdateExposedVoxels();
        VoxelTerrain.Inst.RefreshMesh();
    }

    public static bool Exist(Voxel voxel)
    {
        return voxel != null && voxel.Enabled;
    }
}