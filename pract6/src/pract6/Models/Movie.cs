namespace pract6.Models;

// Модель сущности Movies. Структура соответствует варианту 3.
// При выполнении Database First этот файл может быть заново создан командой
// dotnet ef dbcontext scaffold (см. README.md и scripts/scaffold-db.*).
public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public int ReleaseYear { get; set; }

    public bool IsAvailable { get; set; }
}
