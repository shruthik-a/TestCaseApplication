using TestCaseApplication.Model;

public interface IService
{
    Task<List<User>> GetAllUsers();
    Task AddUser(User user);
    Task CreateProject(Project project);
    Task<List<Project>> GetAllProjects();
    Task<string> PerformAddition(TestCaseInputDto testCaseInput);
    Task<string> PerformSubtraction(TestCaseInputDto testCaseInput);
    Task<string> PerformMultiplication(TestCaseInputDto testCaseInput);
    Task<List<TestCase>> GetAllTestCases();
}
