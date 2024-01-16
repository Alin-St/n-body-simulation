# N-Body Simulation
The goal is to simulate the [n-body problem](https://en.wikipedia.org/wiki/N-body_simulation) using parallel programming techniques.

This repository will contain 3 projects:
* **NBodyThreadedSimulation**: Simulates the n-body problem using regular threads.
* **NBodyDistributedSimulation**: Simulates the n-body problem using distributed programming techniques.
* **NBodyVisualizer**: A 3D visualization tool that helps in validating the results of the simulation.

The first two projects will generate the initial configuration of bodies randomly, then simulate gravity for a limited number of frames, then output a file that represents the result of the simulation. The file primarily contains the position of each body for each frame. This file can be opened with the visualizer to check the result of the simulation.

### Git commit message conventions:
* `thd: ` prefix - The change affects _NBodyThreadedSimulation_ project.
* `dis: ` prefix - The change affects _NBodyDistributedSimulation_ project.
* `vis: ` prefix - The change affects _NBodyVisualizer_ project.
