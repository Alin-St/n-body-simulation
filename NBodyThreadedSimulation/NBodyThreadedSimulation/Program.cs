using NBodyThreadedSimulation.Domain;
using NBodyThreadedSimulation.Simulators;
using NBodyThreadedSimulation.Utils;
using System.Diagnostics;

namespace NBodyThreadedSimulation;

class Program
{
    public static async Task Main()
    {
        if (Debugger.IsAttached)
            Directory.SetCurrentDirectory("../../../_Run");

        await SimulateSampleAsync();
    }

    public static async Task SimulateSampleAsync()
    {
        // Create a scene with two bodies
        var scene = new Scene
        {
            GravitationalConstant = 6.67430e-11,
            DeltaTime = 1d / 50,
            Bodies = new List<Body>
            {
                new() {
                    Position = new Vector3D { X = 1.2, Y = 5.32, Z = 2.24 },
                    Velocity = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Mass = 1000
                },
                new() {
                    Position = new Vector3D { X = 1.52, Y = 2.16, Z = -1.52 },
                    Velocity = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Mass = 1000
                }
            }
        };

        // Simulate the scene using a single-threaded simulator for a few seconds
        Console.WriteLine($"Initial scene:\r\n" + $"{scene}".Indent());
        Console.WriteLine("Simulating...\r\n");

        ISimulator simulator = new SingleThreadedSimulator();
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        var startTime = DateTime.Now;
        var resultScene = await simulator.Simulate(scene, "sample_sim.txt", cts.Token);
        var runTime = DateTime.Now - startTime;

        Console.WriteLine($"Simulation ran for {resultScene} frames in {runTime.TotalSeconds:f4} seconds");
        Console.WriteLine($"Final scene:\r\n" + $"{scene}".Indent());
    }
}
