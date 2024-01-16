using NBodyThreadedSimulation.Utils;

namespace NBodyThreadedSimulation.Domain;

record Scene
{
    public double GravitationalConstant { get; set; }
    public double DeltaTime { get; set; }
    public List<Body> Bodies { get; set; } = new();

    public Scene DeepCopy() => new()
    {
        GravitationalConstant = GravitationalConstant,
        Bodies = Bodies.Select(b => b.DeepCopy()).ToList(),
    };

    public override string ToString()
    {
        return $"GravitationalConstant: {GravitationalConstant}\r\n" +
            $"DeltaTime: {DeltaTime}\r\n" +
            $"{string.Join("\r\n", Bodies.Select((b, i) => $"Body {i}:\r\n" + $"{b}".Indent()))}";
    }
}
