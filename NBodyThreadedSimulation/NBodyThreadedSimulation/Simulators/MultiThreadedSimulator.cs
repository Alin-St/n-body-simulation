using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class MultiThreadedSimulator : ISimulator
{
    public Task<int> Simulate(Scene scene, CancellationToken ct, int maxFrames = int.MaxValue, string? simulationFilename = null)
    {
        throw new NotImplementedException();
    }
}
