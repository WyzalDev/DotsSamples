using Unity.Entities;
using UnityEngine;

public class SpawnSquaresConfigAuth : MonoBehaviour {

    public GameObject squarePrefab;
    public int amountToSpawn;

    public class Baker : Baker<SpawnSquaresConfigAuth> {
        public override void Bake(SpawnSquaresConfigAuth authoring) {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new SpawnSquaresConfig {
                squarePrefabEntity = GetEntity(authoring.squarePrefab, TransformUsageFlags.Dynamic),
                amountToSpawn = authoring.amountToSpawn
            });
        }
    }

}

public struct SpawnSquaresConfig : IComponentData {
    public Entity squarePrefabEntity;
    public int amountToSpawn;
}
