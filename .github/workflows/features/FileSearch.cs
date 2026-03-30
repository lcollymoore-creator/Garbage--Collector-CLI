using System.IO;
using Spectre.Console;
public static class FileSearch
{
    public static void SearchFile(string targetPath)
    {
        var files = Directory.EnumerateFiles(targetPath, "*.*", SearchOption.AllDirectories)
                             .Select(f => new FileInfo(f))
                             .Where(f => f.Extension == ".tmp" || f.LastAccessTime < DateTime.Now.AddDays(-30));

        foreach (var file in files)
        {
            Console.WriteLine($"Found: {file.Name} ({file.Length / 1024} KB)");
            // file.Delete(); // Solo si no es dry-run
        }
    }
}