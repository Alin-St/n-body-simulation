using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

static class SimulatorUtils
{
    /// <summary> Updates the velocity of the given body based on the gravitational effects of all other bodies in the scene. </summary>
    public static void ComputeBodyVelocity(Scene currentScene, Body body)
    {
        foreach (var otherBody in currentScene.Bodies)
        {
            if (ReferenceEquals(body, otherBody))
                continue;

            DoBodyInteraction(body, otherBody, currentScene.GravitationalConstant);
        }
    }

    /// <summary> Computes the gravitational effects between two bodies and updates the velocity of the first body. </summary>
    public static void DoBodyInteraction(Body body, Body otherBody, double G)
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

    /// <summary> Move the bodies in the scene based on their velocity. </summary>
    public static void MoveBodies(Scene scene)
    {
        foreach (var body in scene.Bodies)
            body.Position += body.Velocity * scene.DeltaTime;
    }

    /// <summary> Writes the first part of the simulation file. </summary>
    public static void WriteHeader(Scene scene, StreamWriter? writer)
    {
        if (writer is null)
            return;

        writer.WriteLine($"{scene.Bodies.Count} {scene.DeltaTime}\r\n");
    }

    /// <summary> Writes information related to the given frame to the simulation file. </summary>
    public static void WriteFrame(Scene scene, StreamWriter? writer)
    {
        if (writer is null)
            return;

        foreach (var body in scene.Bodies)
            writer.WriteLine($"{body.Position.X} {body.Position.Y} {body.Position.Z}");

        writer.WriteLine();
    }
}
