using Unity.Entities;
using UnityEngine;

public class RotateSpeedAuth : MonoBehaviour {
    public float value;

    private class Baker : Baker<RotateSpeedAuth> {
        public override void Bake(RotateSpeedAuth authoring) {
            Entity  entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed {
                value = authoring.value
            });
        }
    }
}


public struct RotateSpeed : IComponentData
{
    public float value;
}
