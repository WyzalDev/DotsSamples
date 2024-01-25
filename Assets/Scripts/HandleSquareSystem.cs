using Unity.Entities;

public partial struct HandleSquareSystem : ISystem {
    public void OnCreate(ref SystemState state) {
        state.RequireForUpdate<RotateSpeed>();
        state.RequireForUpdate<Movement>();
    }

    public void OnUpdate(ref SystemState state) {
        foreach(var rotatingMovingSquareAspect in
                SystemAPI.Query<RotatingMovingSquareAspect>().WithAll<RotatingSquare>()) {
            rotatingMovingSquareAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
        }
    }
}
