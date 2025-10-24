using backend.DTOs;

namespace backend.Services
{
    public class SmartSchedulerService
    {
        public ScheduleResponseDto GenerateSchedule(ScheduleRequestDto request)
        {
            var tasks = request.Tasks;
            var taskMap = tasks.ToDictionary(t => t.Title, t => t);
            var dependencies = new Dictionary<string, List<string>>();
            var inDegree = new Dictionary<string, int>();

            // Initialize data structures
            foreach (var task in tasks)
            {
                dependencies[task.Title] = new List<string>();
                inDegree[task.Title] = 0;
            }

            // Build dependency graph
            foreach (var task in tasks)
            {
                foreach (var dependency in task.Dependencies)
                {
                    if (taskMap.ContainsKey(dependency))
                    {
                        dependencies[dependency].Add(task.Title);
                        inDegree[task.Title]++;
                    }
                }
            }

            // Topological sort using Kahn's algorithm
            var queue = new Queue<string>();
            var result = new List<string>();

            // Add tasks with no dependencies to queue
            foreach (var kvp in inDegree)
            {
                if (kvp.Value == 0)
                {
                    queue.Enqueue(kvp.Key);
                }
            }

            while (queue.Count > 0)
            {
                var currentTask = queue.Dequeue();
                result.Add(currentTask);

                // Process dependent tasks
                foreach (var dependent in dependencies[currentTask])
                {
                    inDegree[dependent]--;
                    if (inDegree[dependent] == 0)
                    {
                        queue.Enqueue(dependent);
                    }
                }
            }

            // Check for circular dependencies
            if (result.Count != tasks.Count)
            {
                throw new InvalidOperationException("Circular dependencies detected in task schedule");
            }

            return new ScheduleResponseDto
            {
                RecommendedOrder = result
            };
        }
    }
}
