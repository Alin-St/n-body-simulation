using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class MultiThreadedSimulator : ISimulator
{
    public async Task<int> Simulate(Scene initialScene, string? simulationFilename, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
