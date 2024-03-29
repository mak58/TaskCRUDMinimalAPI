namespace Minimal.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {        
        private readonly ApplicationDbContext _context;
        public TaskRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Tasks> GetTasks()
        {
            var tasks =  _context
                        .Tasks
                        .AsNoTracking()
                        .ToList();

            return tasks;
        }

        public async Task<Tasks> GetTasksById(Guid id)
        {
            var task =  _context
                        .Tasks
                        .AsNoTracking()                        
                        .FirstOrDefault(x => x.Id == id);

            if (task is null) return null;

            return await Task.FromResult(task);
        }

        public async Task<Tasks> PostTask(TaskValidate model)
        {
            var tasks = model.MapTo();

            if (!model.IsValid) return null;

             _context.Tasks.Add(tasks);
            
            await _context.SaveChangesAsync();

            return await Task.FromResult(tasks);
        }

        public async Task<Tasks> PutTask(Guid id, TaskValidate model)
        {        
            var task = model.MapTo();

            if (task is null) return null;

            task.Title = task.Title;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            
            return await Task.FromResult(task);
        }

        public async void DeleteTask(Guid id)
        {
            var editedTasks = _context.Tasks
                                .Where(x => x.Id == id)
                                .FirstOrDefault(); 
                                           
            if (editedTasks != null)
            {
                _context.Tasks.Remove(editedTasks);
                await _context.SaveChangesAsync();
            }            
        }
    }
}