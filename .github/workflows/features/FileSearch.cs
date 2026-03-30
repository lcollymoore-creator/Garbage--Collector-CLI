using System.IO;
using Spectre.Console;
public static class FileSearch
{
    public static void SearchFile(string targetPath)
    {
        
        // targetPath = Console.ReadLine();
        var files = Directory.EnumerateFiles(targetPath, "*.*", SearchOption.AllDirectories)
                             .Select(f => new FileInfo(f))
                             .Where(f => f.Extension == ".tmp" || f.LastAccessTime < DateTime.Now.AddDays(-30));
                             AnsiConsole.Markup($"[bold yellow]Searching for files in: {targetPath}[/]\n");
         
                                   
        foreach (var file in files)
        
        {
            if (file.Exists)
            {
            AnsiConsole.Markup($"[bold green]✔ [/][RED]Found: {file.Name} ({file.Length / 1024} KB)[/]\n");
            deletefile(file);

            }
            else if (!file.Length.Equals(0))
            {
                AnsiConsole.Markup($"[bold red]✘ [/][RED]File Empty");
             
            }

        
          
       
        }
        

        
    }

    public static void deletefile(FileInfo file)
    {
                 string opt = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do with this file?")
                    .AddChoices(new[] { "Delete", "Skip" }));
            if (opt == "Delete"){
                file.Delete();
                AnsiConsole.Markup($"[bold green]✔ [/][RED]Deleted: {file.Name}[/]\n");
            }
            else if (opt == "Skip")
            {
                AnsiConsole.Markup($"[bold yellow]⚠ [/][RED]Skipped: {file.Name}[/]\n");
            }
            else
            {
                AnsiConsole.Markup($"[bold red]✘ [/][RED]Error processing: {file.Name}[/]\n");
            }
    }

    
}