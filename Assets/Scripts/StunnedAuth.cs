using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class StunnedAuth : MonoBehaviour {
    public class Baker : Baker<StunnedAuth> {
        public override void Bake(StunnedAuth authoring) {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Stunned { });
            SetComponentEnabled<Stunned>(entity, false);
        }
    }
}

public struct Stunned : IComponentData, IEnableableComponent {

}
