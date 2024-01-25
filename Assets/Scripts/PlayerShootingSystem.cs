using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShootingSystem : SystemBase {

    public event EventHandler OnShoot;

    protected override void OnCreate() {
        RequireForUpdate<Player>();
    }


    protected override void OnUpdate() {

        if(Input.GetKeyDown(KeyCode.T)) {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
        }

        if(Input.GetKeyDown(KeyCode.Y)) {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
        }

        if(!Input.GetKeyDown(KeyCode.Space)) {
            return;
        }

        SpawnSquaresConfig spawnSquaresConfig = SystemAPI.GetSingleton<SpawnSquaresConfig>();

        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);

        foreach(var (localTransform, entity) in
                SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>().WithEntityAccess()) {
            //EntityManager.Instantiate ������ ���� �����, �� ��� ����� ������������ ��� ������ �� ���� ���
            Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnSquaresConfig.squarePrefabEntity);
            //EntityManager.SetComponentData ������ ���� �����,
            //�� � ����� performance SystemAPI ������� ����� ������
            //* SystemAPI.SetComponent ����� ���������� ��� ��� �������� � entityCommandBuffer
            entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = 1f
            });

            OnShoot?.Invoke(entity, EventArgs.Empty);
        }

        entityCommandBuffer.Playback(EntityManager);
    }
}
