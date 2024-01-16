using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class SingleThreadedSimulator : ISimulator
{
    public Task<Scene> Simulate(Scene initialScene, string? simulationFilename, CancellationToken ct)
    {
    }
}
