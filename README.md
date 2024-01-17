# N-Body Simulation
The goal is to simulate the [n-body problem](https://en.wikipedia.org/wiki/N-body_simulation) using parallel programming techniques.

This repository contains 3 projects:
* **NBodyThreadedSimulation**: Simulates the n-body problem using regular threads.
  - Language: C#
  - IDE: Visual Studio 2022
* **NBodyDistributedSimulation**: Simulates the n-body problem using distributed programming techniques.
  - Language: C++
  - IDE: CLion
  - Uses OpenMPI library
* **NBodyVisualizer**: A 3D visualization tool that helps in validating the results of the simulation.
  - Made with Unity
  - Language: C#

The first two projects will generate the initial configuration of bodies randomly, then simulate gravity for a limited number of frames, then output a file that represents the result of the simulation. The file primarily contains the position of each body for each frame. This file can be opened with the visualizer to check the result of the simulation.

### Git commit message conventions:
* `thd: ` prefix - The change affects _NBodyThreadedSimulation_ project.
* `dis: ` prefix - The change affects _NBodyDistributedSimulation_ project.
* `vis: ` prefix - The change affects _NBodyVisualizer_ project.

### File format:
The file generated in the Simulation projects is used by the Visualizer to render the simulation. This is a _.txt_ file and it has a very simple format:
* On the first line there are two numbers separated by a space: `body count` (integer) and `delta time` (floating-point).
* The second line is empty.
* Starting form the third line, each frame will be represented using `body count + 1` lines. Each line `i`, except the last one which is empty, contains 3 floating-point numbers separated by a space, representing the `X`, `Y` and `Z` coordinates of body `i`.
* Note: The number of frames is not specified in the beginning, you need to read the whole file and count them manually.

Example with 4 frames and 2 bodies:
```
2 0.0200

1.2000 5.3200 2.2400
1.5200 2.1600 -1.5200

1.2000 5.3199 2.2398
1.5198 2.1600 -1.5198

1.2000 5.3199 2.2397
1.5196 2.1600 -1.5197

1.2000 5.3199 2.2395
1.5194 2.1600 -1.5195
```
