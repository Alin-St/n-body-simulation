using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class MultiThreadedSimulator : ISimulator
{
    public async Task<Scene> Simulate(Scene initialScene, string? simulationFilename, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
