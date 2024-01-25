using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class SpawnSquaresSystem : SystemBase {
    protected override void OnCreate() {
        RequireForUpdate<SpawnSquaresConfig>();

    }
    protected override void OnUpdate() {
        Enabled = false;
        SpawnSquaresConfig spawnSquaresConfig = SystemAPI.GetSingleton<SpawnSquaresConfig>();

        for(int i = 0; i < spawnSquaresConfig.amountToSpawn; i++) {
            Entity spawnedEntity = EntityManager.Instantiate(spawnSquaresConfig.squarePrefabEntity);
            //EntityManager.SetComponentData делает тоже самое,
            //но в плане performance SystemAPI функции лучше всегда
            SystemAPI.SetComponent(spawnedEntity, new LocalTransform {
                Position = new float3(UnityEngine.Random.Range(-10f, 5f), UnityEngine.Random.Range(-4f, 7f), 0f),
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
    }
}
