using Unity.Entities;
using UnityEngine;

public class RotatingSquareAuth : MonoBehaviour
{
    public class Baker : Baker<RotatingSquareAuth> {
        public override void Bake(RotatingSquareAuth authoring) {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotatingSquare { });
        }
    }
}

public struct RotatingSquare : IComponentData { }
