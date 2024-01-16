namespace NBodyThreadedSimulation.Domain;

record Vector3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public double SqrLength()
        => X * X + Y * Y + Z * Z;

    public double Length()
        => Math.Sqrt(SqrLength());

    public Vector3D Normalized()
        => this / Length();

    public static Vector3D operator *(Vector3D vector, double scalar) => new()
    {
        X = vector.X * scalar,
        Y = vector.Y * scalar,
        Z = vector.Z * scalar
    };

    public static Vector3D operator /(Vector3D vector, double scalar)
        => vector * (1 / scalar);

    public static Vector3D operator -(Vector3D vector)
        => vector * -1;

    public static Vector3D operator +(Vector3D left, Vector3D right) => new()
    {
        X = left.X + right.X,
        Y = left.Y + right.Y,
        Z = left.Z + right.Z
    };

    public static Vector3D operator -(Vector3D left, Vector3D right)
        => left + -right;

    public override string ToString()
        => $"({X:F4}, {Y:F4}, {Z:F4})";
}
