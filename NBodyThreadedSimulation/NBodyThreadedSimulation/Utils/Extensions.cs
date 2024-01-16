namespace NBodyThreadedSimulation.Utils;

static class Extensions
{
    public static string Indent(this string s, string indentation = "    ")
    {
        var lines = s.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        return string.Join(Environment.NewLine, lines.Select(l => indentation + l));
    }
}
