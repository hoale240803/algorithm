using algorithm.Graph;

CourseSchedule courseSchedule = new CourseSchedule();
int numCourses = 2;
int[][] prerequisites = new int[][]
{
    new int[] { 1, 0 }
};

bool canFinish = courseSchedule.CanFinish(numCourses, prerequisites);
Console.WriteLine($"Can finish all courses: {canFinish}");

