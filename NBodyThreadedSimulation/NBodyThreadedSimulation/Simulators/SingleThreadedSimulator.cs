using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class SingleThreadedSimulator : ISimulator
{
    public Task<int> Simulate(Scene scene, CancellationToken ct, int maxFrames, string? simulationFilename)
    {
        int frameCount = 0;

        using var writer = simulationFilename is null ? null : new StreamWriter(simulationFilename);
        writer?.WriteLine($"{scene.Bodies.Count} {scene.DeltaTime}\r\n");
        WriteFrame(scene, writer);

        while (frameCount < maxFrames && !ct.IsCancellationRequested)
        {
            SimulateFrame(scene);
            WriteFrame(scene, writer);
            frameCount++;
        }

        return Task.FromResult(frameCount);
    }

    static void SimulateFrame(Scene currentScene)
    {
        foreach (var body in currentScene.Bodies)
        {
            foreach (var otherBody in currentScene.Bodies)
            {
                if (ReferenceEquals(body, otherBody))
                    continue;

                DoBodyInteraction(body, otherBody, currentScene.GravitationalConstant);
            }
        }

        foreach (var body in currentScene.Bodies)
            body.Position += body.Velocity * currentScene.DeltaTime;
    }

    static void DoBodyInteraction(Body body, Body otherBody, double G)
    {
        // Compute force magnitude
        var delta = otherBody.Position - body.Position;
        double sqrDistance = delta.SqrLength();

        // Newton's law of universal gravitation: F = G * ((m1 * m2) / r^2)
        var forceMagnitude = G * ((body.Mass * otherBody.Mass) / sqrDistance);

        // Compute acceleration
        var force = delta.Normalized() * forceMagnitude;
        var acceleration = force / body.Mass;

        // Update velocity
        body.Velocity += acceleration;
    }

    static void WriteFrame(Scene scene, StreamWriter? writer)
    {
        if (writer is null)
            return;

        foreach (var body in scene.Bodies)
            writer.WriteLine($"{body.Position.X} {body.Position.Y} {body.Position.Z}");

        writer.WriteLine();
    }
}
