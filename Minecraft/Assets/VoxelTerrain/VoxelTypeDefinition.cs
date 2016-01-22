using UnityEngine;

[System.Serializable]
public class VoxelTypeDefinition
{
    public readonly VoxelType   Type;
    public int                  MaxHealth; 
    public bool                 IsVisible;   
    public bool                 IsSolid;
    public int                  UVTopX;
    public int                  UVTopY;
    public int                  UVSideX;
    public int                  UVSideY;
    public int                  UVBottomX;
    public int                  UVBottomY;
    public VoxelUVSet           UVSet;

    public VoxelTypeDefinition(VoxelType type, int maxHealth, bool isSolid, bool isVisible)
    {
        Type = type;
        MaxHealth = maxHealth;
        IsSolid = isSolid;
        IsVisible = isVisible;
        UVTopX = 0;
        UVTopY = 0;
        UVSideX = 0;
        UVSideY = 0;
        UVBottomX = 0;
        UVBottomY = 0;
        UVSet = new VoxelUVSet();
    }

    public void RecalcUVSet()
    {
        float tileSize = 1.0f / VoxelWorld.Inst.VoxelTextureTilesAcross;

        UVSet.Top.A = new Vector2(UVTopX * tileSize, UVTopY * tileSize);
        UVSet.Top.B = new Vector2(UVTopX * tileSize, UVTopY * tileSize + tileSize);
        UVSet.Top.C = new Vector2(UVTopX * tileSize + tileSize, UVTopY * tileSize + tileSize);
        UVSet.Top.D = new Vector2(UVTopX * tileSize + tileSize, UVTopY * tileSize);
        
        UVSet.Side.A = new Vector2(UVSideX * tileSize, UVSideY * tileSize);
        UVSet.Side.B = new Vector2(UVSideX * tileSize, UVSideY * tileSize + tileSize);
        UVSet.Side.C = new Vector2(UVSideX * tileSize + tileSize, UVSideY * tileSize + tileSize);
        UVSet.Side.D = new Vector2(UVSideX * tileSize + tileSize, UVSideY * tileSize);
        
        UVSet.Bottom.A = new Vector2(UVBottomX * tileSize, UVBottomY * tileSize);
        UVSet.Bottom.B = new Vector2(UVBottomX * tileSize, UVBottomY * tileSize + tileSize);
        UVSet.Bottom.C = new Vector2(UVBottomX * tileSize + tileSize, UVBottomY * tileSize + tileSize);
        UVSet.Bottom.D = new Vector2(UVBottomX * tileSize + tileSize, UVBottomY * tileSize);
    }
}