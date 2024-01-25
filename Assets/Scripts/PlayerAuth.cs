using Unity.Entities;
using UnityEngine;

public class PlayerAuth : MonoBehaviour {

    private class Baker : Baker<PlayerAuth> {
        public override void Bake(PlayerAuth authoring) {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Player { });
        }
    }
}

public struct Player : IComponentData {

}