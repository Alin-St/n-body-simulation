namespace NBodyThreadedSimulation.Domain;

record Body
{
    public double Mass { get; set; }
    public Vector3D Position { get; set; } = new();
    public Vector3D Velocity { get; set; } = new();

    public Body DeepCopy() => new()
    {
        Mass = Mass,
        Position = Position with { },
        Velocity = Velocity with { },
    };

    public override string ToString()
    {
        return $"Mass: {Mass}\r\n" +
            $"Position: {Position}\r\n" +
            $"Velocity: {Velocity}";
    }
}
