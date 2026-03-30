using Spectre.Console;

string[] logoFrames =
{
@"
   GGGGG   AAAAA   RRRRR   BBBBB    AAAAA   GGGGG   EEEEE
  G       A     A  R    R  B    B  A     A G       E
  G  GGG  AAAAAAA  RRRRR   BBBBB   AAAAAAA G  GGG  EEEE
  G    G  A     A  R   R   B    B  A     A G    G  E
   GGGG   A     A  R    R  BBBBB   A     A  GGGG   EEEEE

          Collector CLI by lcollym
"
};

await AnsiConsole.Live(new Panel(""))
    .StartAsync(async ctx =>
    {
        foreach (var frame in logoFrames)
        {
            ctx.UpdateTarget(
                new Panel($"[cyan]{frame}[/]")
                    .Border(BoxBorder.Rounded)
                    .Header("My CLI")
            );

            await Task.Delay(200);
        }
    });


FileSearch.SearchFile("C:\\Users\\lcoll\\OneDrive\\Imágenes");