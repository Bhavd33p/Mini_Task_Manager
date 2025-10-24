# Smart Scheduler API Example

## Overview
The Smart Scheduler API helps users plan their work automatically by analyzing task dependencies and providing an optimal execution order.

## API Endpoint
```
POST /api/v1/projects/{projectId}/schedule
```

## Example Request

```json
{
  "tasks": [
    {
      "title": "Design API",
      "estimatedHours": 5,
      "dueDate": "2025-10-25",
      "dependencies": []
    },
    {
      "title": "Implement Backend",
      "estimatedHours": 12,
      "dueDate": "2025-10-28",
      "dependencies": ["Design API"]
    },
    {
      "title": "Build Frontend",
      "estimatedHours": 10,
      "dueDate": "2025-10-30",
      "dependencies": ["Design API"]
    },
    {
      "title": "End-to-End Test",
      "estimatedHours": 8,
      "dueDate": "2025-10-31",
      "dependencies": ["Implement Backend", "Build Frontend"]
    }
  ]
}
```

## Example Response

```json
{
  "recommendedOrder": [
    "Design API",
    "Implement Backend",
    "Build Frontend",
    "End-to-End Test"
  ]
}
```

## How It Works

1. **Dependency Analysis**: The algorithm analyzes task dependencies to build a directed graph
2. **Topological Sorting**: Uses Kahn's algorithm to find a valid execution order
3. **Circular Dependency Detection**: Prevents infinite loops by detecting circular dependencies
4. **Optimal Ordering**: Provides the most efficient task execution sequence

## Algorithm Details

The Smart Scheduler uses **Kahn's Algorithm** for topological sorting:

1. **Build Graph**: Create a dependency graph from the input tasks
2. **Calculate In-Degrees**: Count incoming dependencies for each task
3. **Initialize Queue**: Add tasks with no dependencies to the processing queue
4. **Process Queue**: Remove tasks from queue and update dependent tasks
5. **Validate Result**: Ensure all tasks are processed (no circular dependencies)

## Error Handling

- **Circular Dependencies**: Returns error if tasks have circular dependencies
- **Invalid Dependencies**: Ignores dependencies that don't exist in the task list
- **Empty Tasks**: Validates that at least one task is provided

## Frontend Integration

The Smart Scheduler is integrated into the Project Details page with:
- **Modal Interface**: Clean, user-friendly task input form
- **Real-time Validation**: Immediate feedback on form inputs
- **Loading States**: Visual feedback during schedule generation
- **Mobile Responsive**: Optimized for all device sizes
- **Error Display**: Clear error messages for invalid inputs

## Use Cases

- **Project Planning**: Plan complex projects with interdependent tasks
- **Resource Allocation**: Optimize team member assignments
- **Timeline Estimation**: Better understand project duration
- **Risk Management**: Identify critical path dependencies
- **Agile Development**: Plan sprints with proper task sequencing

