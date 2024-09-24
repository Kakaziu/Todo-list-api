using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("Para fazer")]
        Todo = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluída")]
        Done = 3
    }
}
