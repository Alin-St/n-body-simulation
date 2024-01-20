# N-Body Simulation
The goal is to simulate the [n-body problem](https://en.wikipedia.org/wiki/N-body_simulation) using parallel programming techniques.

This repository contains 3 projects:
* **NBodyThreadedSimulation**: Simulates the n-body problem using regular threads.
  - Language: C#
  - IDE: Visual Studio 2022
* **NBodyDistributedSimulation**: Simulates the n-body problem using distributed programming techniques.
  - Language: C++
  - IDE: Visual Studio 2022
  - Uses the [MPI](https://en.wikipedia.org/wiki/Message_Passing_Interface) implementation for Windows: [MS-MPI](https://learn.microsoft.com/en-us/message-passing-interface/microsoft-mpi)
* **NBodyVisualizer**: A 3D visualization tool that helps in validating the results of the simulation.
  - Made with Unity
  - Language: C#

The first two projects will generate the initial configuration of bodies randomly, then simulate gravity for a limited number of frames, then output a file that represents the result of the simulation. The file primarily contains the position of each body for each frame. This file can be opened with the visualizer to check the result of the simulation.

# Project Structure

## File format:
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

## Project setup

### NBodyThreadedSimulation
* Open project with Visual Studio.
* Mind this code at the start of the program. The following code assumes that the Debug folder is located at `\NBodyThreadedSimulation\NBodyThreadedSimulation\bin\Debug\net6.0\`, and changes the current directory to `\NBodyThreadedSimulation\NBodyThreadedSimulation\_Run` as if the program was running at that location when debugging. This is where your simulation file will be created.

        if (Debugger.IsAttached)
            Directory.SetCurrentDirectory("../../../_Run");

### NBodyDistributedSimulation
* Install MS-MPI from [here](https://www.microsoft.com/en-us/download/details.aspx?id=105289) (both the SDK and the compiler). Prefer installation in the default directory.
* Open the project with Visual Studio. If you can't run the program normally (clicking the play button), follow these steps:
  * Go to the _NBodyDistributedSimulation Property Pages_ menu (right click project in the _Solution Explorer_ -> Properties)
  * Go to Configuration Properties -> C/C++ -> General -> Additional Include Directories -> <Edit...> -> New Line and enter the path to Microsoft MPI SDK includes (C:\Program Files %28x86%29\Microsoft SDKs\MPI\Include)
  * Go to Configuration Properties -> Linker -> General -> Additional Library Directories -> <Edit...> -> New Line and enter the path to Microsoft MPI SDK libraries (C:\Program Files %28x86%29\Microsoft SDKs\MPI\Lib\x64)
  * Go to Configuration Properties -> Linker -> Input -> Additional Dependencies -> <Edit...> and write **msmpi.lib** in the box
* To run the project using MPI:
  * Build the project
  * Open the .exe directory (e.g. n-body-simulation\NBodyDistributedSimulation\x64\Debug) in a terminal
  * Run the command `mpiexec -n 8 NBodyDistributedSimulation` (8 is the number of processes you want to run the program on, you can change this number)
 
### NBodyVisualizer
* Open the project in Unity
* My build directory is configured to \NBodyVisualizer\Build. Put in the build directory the simulation file that you want to visualize (near the .exe) and hit play.

## Git commit message conventions:
* `thd: ` prefix - The change affects _NBodyThreadedSimulation_ project.
* `dis: ` prefix - The change affects _NBodyDistributedSimulation_ project.
* `vis: ` prefix - The change affects _NBodyVisualizer_ project.
