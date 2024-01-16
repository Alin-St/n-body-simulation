namespace NBodyThreadedSimulation.Domain;

record Scene
{
    public double GravitationalConstant { get; set; }
    public List<Body>? Bodies { get; set; }

    public Scene DeepCopy() => new()
    {
        GravitationalConstant = GravitationalConstant,
        Bodies = (Bodies ?? new()).Select(b => b.DeepCopy()).ToList(),
    };
}
