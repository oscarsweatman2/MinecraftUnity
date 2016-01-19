using UnityEngine;

public class VoxelUVSet
{
    public PanelUVSet Top;
    public PanelUVSet Side;
    public PanelUVSet Bottom;

    public VoxelUVSet(int topx, int topy, int sidex, int sidey, int bottomx, int bottomy)
    {
        Top = new PanelUVSet(topx, topy);
        Side = new PanelUVSet(sidex, sidey);
        Bottom = new PanelUVSet(bottomx, bottomy);
    }

    public static readonly VoxelUVSet Grass = new VoxelUVSet(0, 7, 1, 7, 0, 6);
    public static readonly VoxelUVSet Dirt = new VoxelUVSet(0, 6, 0, 6, 0, 6);
    public static readonly VoxelUVSet Stone = new VoxelUVSet(2, 7, 2, 7, 2, 7);
    public static readonly VoxelUVSet Debug = new VoxelUVSet(7, 0, 7, 0, 7, 0);

    public static VoxelUVSet[] TypeToSet = new VoxelUVSet[VoxelType.NumVoxelTypes]
    {
        Grass,
        Dirt,
        Stone,
        Debug,
    };
}

public class PanelUVSet
{
    public const float TilesAcross = 8;
    public const float TileSize = 1.0f / TilesAcross;

    public Vector2 A;
    public Vector2 B;
    public Vector2 C;
    public Vector2 D;

    public PanelUVSet(int X, int Y)
    {
        A = new Vector2(X * TileSize, Y * TileSize);
        B = new Vector2(X * TileSize, Y * TileSize + TileSize);
        C = new Vector2(X * TileSize + TileSize, Y * TileSize + TileSize);
        D = new Vector2(X * TileSize + TileSize, Y * TileSize);
    }
}