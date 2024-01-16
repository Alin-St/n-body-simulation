using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

interface ISimulator
{
    /// <summary> Simulates the n-body problem frame-by-frame until it is cancelled. </summary>
    /// <param name="scene"> Used to receive the initial setup and to return the last scene after the simulation. </param>
    /// <param name="simulationFilename"> If not null the simulation will be saved here. </param>
    /// <returns> The number of frames that were simulated. </returns> 
    Task<int> Simulate(Scene scene, string? simulationFilename, CancellationToken ct);
}
