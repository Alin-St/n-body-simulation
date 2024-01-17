using NBodyThreadedSimulation.Domain;

namespace NBodyThreadedSimulation.Simulators;

class MultiThreadedSimulator : ISimulator
{
    public async Task<int> Simulate(Scene scene, CancellationToken ct, int maxFrames, string? simulationFilename)
    {
        int frameCount = 0;

        using var writer = simulationFilename is null ? null : new StreamWriter(simulationFilename);
        SimulatorUtils.WriteHeader(scene, writer);

        while (frameCount < maxFrames && !ct.IsCancellationRequested)
        {
            await SimulateFrame(scene);
            SimulatorUtils.WriteFrame(scene, writer);
            frameCount++;
        }

        return frameCount;
    }

    static async Task SimulateFrame(Scene currentScene)
    {
        // Compute velocity for each body in parallel
        var computeVelocityTasks = new List<Task>();

        foreach (var body in currentScene.Bodies)
        {
            Task computeTask = Task.Run(() => SimulatorUtils.ComputeBodyVelocity(currentScene, body));
            computeVelocityTasks.Add(computeTask);
        }

        // Wait for all tasks to complete
        await Task.WhenAll(computeVelocityTasks);

        // Update positions
        SimulatorUtils.MoveBodies(currentScene);
    }
}
