using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuth : MonoBehaviour {

    public class Baker : Baker<MovementAuth> {
        public override void Bake(MovementAuth authoring) {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Movement {
                movementVector =
                    new float3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f)
            });
        }
    }
}

public struct Movement : IComponentData {
    public float3 movementVector;
}
