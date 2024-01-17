using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class SingleThreadedSimulator : ISimulator
{
    public Task<int> Simulate(Scene scene, CancellationToken ct, int maxFrames, string? simulationFilename)
    {
        int frameCount = 0;

        using var writer = simulationFilename is null ? null : new StreamWriter(simulationFilename);
        SimulatorUtils.WriteHeader(scene, writer);

        while (frameCount < maxFrames && !ct.IsCancellationRequested)
        {
            SimulateFrame(scene);
            SimulatorUtils.WriteFrame(scene, writer);
            frameCount++;
        }

        return Task.FromResult(frameCount);
    }

    static void SimulateFrame(Scene currentScene)
    {
        foreach (var body in currentScene.Bodies)
            SimulatorUtils.ComputeBodyVelocity(currentScene, body);

        SimulatorUtils.MoveBodies(currentScene);
    }
}
