using NBodyThreadedSimulation.Domain;
using NBodyThreadedSimulation.Simulators;

namespace NBodyThreadedSimulation;

class Program
{
    public static async Task Main()
    {
        await SimulateSampleAsync();
    }

    public static async Task SimulateSampleAsync()
    {
        ISimulator simulator = new SingleThreadedSimulator();
        var scene = new Scene
        {
            GravitationalConstant = 6.67430e-11,
            Bodies = new List<Body>
            {
                new Body
                {
                    Position = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Velocity = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Mass = 1000
                },
                new Body
                {
                    Position = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Velocity = new Vector3D { X = 0, Y = 0, Z = 0 },
                    Mass = 1000
                }
            }
        };

        var resultScene = await simulator.Simulate(scene, null, CancellationToken.None);
    }
}
