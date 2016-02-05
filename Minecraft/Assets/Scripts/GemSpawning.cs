using UnityEngine;
using System.Collections;

public class GemSpawning : MonoBehaviour
{
	public static GemSpawning Inst = null;

    public int numGems = 3;
    public Gem gemPrefab = null;
    private Gem[] gems;

    public int goblinsPerGem = 3;
    public int goblinSpawnRadius = 3;
    public Entity goblinPrefab = null;

	// Use this for initialization
	void Start ()
    {
		Inst = this;

        gems = new Gem[numGems];
        for(int i = 0; i < numGems; ++i)
        {
            gems[i] = GameObject.Instantiate<Gem>(gemPrefab);
			gems[i].index = i;
            spawnGem(gems[i]);
        }

        spawnGoblins();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void spawnGem(Gem gem)
    {
        int x = 0;
        int y = 0;
        int z = 0;

        float voxelsDeep = VoxelWorld.Inst.ChunksDeep * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;
        float voxelsWide = VoxelWorld.Inst.ChunksWide * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;
        float voxelsHigh = VoxelWorld.Inst.ChunksHigh * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize;

        
        while (y == 0)
        {
            x = (int)(Random.value * voxelsWide);
            z = (int)(Random.value * voxelsDeep);
            for (int i = 0; i < voxelsHigh - 3; ++i)
            {
                if (VoxelWorld.Inst.GetVoxel(new IntVec3(x, i, z)).TypeDef.Type == VoxelType.Air)
                {
                    y = i;
                    break;
                }
            }
        }

        spawnGem(gem, x, y, z);
    }

    public void spawnGem(Gem gem, int x, int y, int z)
    {
        gem.transform.position = new Vector3(x + .5f, y + .5f, z + .5f);
    }

    public void spawnGoblins()
    {
        foreach(Gem gem in gems)
        {
            for(int i = 0; i < goblinsPerGem; ++i)
            {
                Entity goblin = GameObject.Instantiate<Entity>(goblinPrefab);
                goblin.myGem = gem;
                int x = (int)(Random.value * goblinSpawnRadius * 2 + gem.transform.position.x - goblinSpawnRadius);
                int z = (int)(Random.value * goblinSpawnRadius * 2 + gem.transform.position.z - goblinSpawnRadius);
                int y = (int)(VoxelWorld.Inst.ChunksHigh * VoxelWorld.Inst.ChunkVoxelSize * VoxelWorld.Inst.PhysicalVoxelSize + 1);

                goblin.transform.position = new Vector3(x + .5f, y + 1, z + .5f);
            }
            
        }
    }
}
