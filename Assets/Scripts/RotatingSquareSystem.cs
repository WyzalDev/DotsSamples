using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

public partial struct RotatingSquareSystem : ISystem {

    public void OnCreate(ref SystemState state) {
        state.RequireForUpdate<RotateSpeed>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state) {
        state.Enabled = false;
        return;
        /*foreach(var (localTransform, rotateSpeed)
                in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()) {

            localTransform.ValueRW =
                localTransform.ValueRO.RotateZ(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
        }*/

        RotatingSquareJob rotatingSquareJob = new RotatingSquareJob {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        rotatingSquareJob.Schedule();
    }

}

[BurstCompile]
[WithAll(typeof(RotatingSquare))]
public partial struct RotatingSquareJob : IJobEntity {

    public float deltaTime;

    public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed) {
        localTransform =
                localTransform.RotateZ(rotateSpeed.value * deltaTime);
    }
}
