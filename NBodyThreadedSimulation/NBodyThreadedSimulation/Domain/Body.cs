namespace NBodyThreadedSimulation.Domain;

record Body
{
    public double Mass { get; set; }
    public Vector3D? Position { get; set; }
    public Vector3D? Velocity { get; set; }

    public Body DeepCopy() => new()
    {
        Mass = Mass,
        Position = (Position ?? new()) with { },
        Velocity = (Velocity ?? new()) with { },
    };
}
