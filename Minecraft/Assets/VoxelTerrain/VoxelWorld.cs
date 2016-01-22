using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VoxelWorld : MonoBehaviour
{
    public static VoxelWorld Inst = null;

    public VoxelWorldChunk VoxelWorldChunkPrefab = null;

    public int ChunksWide       = 2;
    public int ChunksDeep       = 2;
    public int ChunksHigh       = 2;

    public int ChunkVoxelSize   = 8;

    public float PhysicalVoxelSize = 1.0f;

    public int VoxelTextureTilesAcross = 8;

    public VoxelTypeDefinition VoxelTypeDefAir      = new VoxelTypeDefinition(VoxelType.Air, 1, false, false);
    public VoxelTypeDefinition VoxelTypeDefGrass    = new VoxelTypeDefinition(VoxelType.Grass, 1, true, true);
    public VoxelTypeDefinition VoxelTypeDefDirt     = new VoxelTypeDefinition(VoxelType.Dirt, 1, true, true);
    public VoxelTypeDefinition VoxelTypeDefStone    = new VoxelTypeDefinition(VoxelType.Stone, 2, true, true);

    public Dictionary<VoxelType, VoxelTypeDefinition> VoxelTypeDefs;

    private VoxelWorldChunk[,,] Chunks = null;

    public int VoxelWidth   = 0;
    public int VoxelHeight  = 0;
    public int VoxelDepth   = 0;

    public bool Initialized = false;

    public void Start()
    {
        Inst = this;

        VoxelWidth = ChunksWide * ChunkVoxelSize;
        VoxelHeight = ChunksHigh * ChunkVoxelSize;
        VoxelDepth = ChunksDeep * ChunkVoxelSize;

        VoxelTypeDefs = new Dictionary<VoxelType, VoxelTypeDefinition>();
        VoxelTypeDefs[VoxelType.Air] = VoxelTypeDefAir;
        VoxelTypeDefs[VoxelType.Grass] = VoxelTypeDefGrass;
        VoxelTypeDefs[VoxelType.Dirt] = VoxelTypeDefDirt;
        VoxelTypeDefs[VoxelType.Stone] = VoxelTypeDefStone;

        VoxelTypeDefs.Values.ToList().ForEach(def => def.RecalcUVSet());

        InstantiateChunks();

        GenerateWorldVoxels();

        Initialized = true;

        Refresh();
    }

    public void InstantiateChunks()
    {
        Chunks = new VoxelWorldChunk[ChunksWide, ChunksHigh, ChunksDeep];

        for (int x = 0; x < ChunksWide; ++x)
        {
            for (int y = 0; y < ChunksHigh; ++y)
            {
                for (int z = 0; z < ChunksDeep; ++z)
                {
                    string chunkName = string.Concat("Chunk ", x, ", ", y, ", ", z);
                    VoxelWorldChunk chunk = GameObject.Instantiate<VoxelWorldChunk>(VoxelWorldChunkPrefab);
                    chunk.name = chunkName;
                    chunk.transform.parent = transform;
                    chunk.ChunkPosition = new IntVec3(x, y, z);
                    int worldx = x * ChunkVoxelSize;
                    int worldy = y * ChunkVoxelSize;
                    int worldz = z * ChunkVoxelSize;
                    chunk.InstantiateVoxels(worldx, worldy, worldz, ChunkVoxelSize, ChunkVoxelSize, ChunkVoxelSize);
                    Chunks[x, y, z] = chunk;
                }
            }
        }
    }

    public void GenerateWorldVoxels()
    {
        for (int x = 0; x < ChunksWide; ++x)
        {
            for (int y = 0; y < ChunksHigh; ++y)
            {
                for (int z = 0; z < ChunksDeep; ++z)
                {
                    VoxelWorldChunk chunk = Chunks[x, y, z];

                    GenerateChunkVoxels(chunk);
                }
            }
        }
    }

    public void GenerateChunkVoxels(VoxelWorldChunk chunk)
    {
        for (int x = 0; x < chunk.Width; ++x)
        {
            for (int y = 0; y < chunk.Height; ++y)
            {
                for (int z = 0; z < chunk.Depth; ++z)
                {
                    Voxel voxel = chunk.GetVoxel(x, y, z);

                    GenerateVoxel(voxel);
                }
            }
        }
    }

    public void GenerateVoxel(Voxel voxel)
    {
        voxel.SetType(Random.value < 0.10f ? VoxelType.Air : VoxelType.Grass);
        if (voxel.Position.Y == 0)
            voxel.SetType(VoxelType.Stone);
        voxel.SetType(VoxelType.Grass);
    }

    public void Refresh()
    {
        foreach (VoxelWorldChunk chunk in Chunks)
            if (chunk.IsDirty)
                chunk.Refresh();
    }

    public void UpdateExposedVoxels()
    {
        for (int x = 0; x < ChunksWide; ++x)
        {
            for (int y = 0; y < ChunksHigh; ++y)
            {
                for (int z = 0; z < ChunksDeep; ++z)
                {
                    Chunks[x, y, z].UpdateExposedVoxels();
                }
            }
        }
    }

    public Voxel GetVoxel(IntVec3 pos)
    {
        return GetVoxel(pos.X, pos.Y, pos.Z);
    }

    public Voxel GetVoxel(int x, int y, int z)
    {
        int chunkx = x / ChunkVoxelSize;
        int chunky = y / ChunkVoxelSize;
        int chunkz = z / ChunkVoxelSize;
        
        int localx = x % ChunkVoxelSize;
        int localy = y % ChunkVoxelSize;
        int localz = z % ChunkVoxelSize;
        
        return Chunks[chunkx, chunky, chunkz].GetVoxel(localx, localy, localz);
    }

    public VoxelWorldChunk GetChunk(IntVec3 chunkPosition)
    {
        return Chunks[chunkPosition.X, chunkPosition.Y, chunkPosition.Z];
    }

    public bool IsChunkIndexValid(IntVec3 chunkPosition)
    {
        return IsChunkIndexValid(chunkPosition.X, chunkPosition.Y, chunkPosition.Z);
    }

    public bool IsChunkIndexValid(int x, int y, int z)
    {
        return x >= 0 && y >= 0 && z >= 0 && x < ChunksWide && y < ChunksHigh && z < ChunksDeep;
    }
    
    public bool IsVoxelWorldIndexValid(int x, int y, int z)
    {
        return x >= 0 && y >= 0 && z >= 0 && x < VoxelWidth && y < VoxelHeight && z < VoxelDepth;
    }

    public Voxel GetVoxelFromCollider(BoxCollider collider)
    {
        VoxelWorldChunk chunk = collider.gameObject.GetComponent<VoxelWorldChunk>();
        return chunk.GetVoxelFromCollider(collider);
    }
}