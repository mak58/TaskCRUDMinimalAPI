namespace Minimal.Interfaces
{
    public interface ITaskRepositories
    {
        IEnumerable<Tasks> GetTasks();
        Task<Tasks> GetTasksById(Guid id);
        Task<Tasks> PostTask(TaskValidate task);
        Task<Tasks> PutTask(Guid id, TaskValidate model);
        void DeleteTask (Guid id);
    }
}