using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

interface ISimulator
{
    Task<Scene> Simulate(Scene initialScene, string? simulationFilename, CancellationToken ct);
}
