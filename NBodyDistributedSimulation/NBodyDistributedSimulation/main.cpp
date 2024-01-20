#include <iostream>
#include <mpi.h>

int main()
{
	MPI_Init(NULL, NULL);
	std::cout << "Hello world!\n";
	MPI_Finalize();
	return 0;
}
