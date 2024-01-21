using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestCaseApplication.Data;
using TestCaseApplication.Model;

namespace TestCaseApplication.Services
{
    public class Service : IService
    {
        private readonly AppDbContext _context;

        public Service(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add the project", ex);
            }
        }

        public async Task<List<TestCase>> GetAllTestCases()
        {
            try
            {
                return await _context.TestCases.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to get all test cases", ex);
            }
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<string> PerformAddition(TestCaseInputDto testCaseInput)
        {
            try
            {
                long projectId = await DetermineProjectId("Addition"); 

                int result = int.Parse(testCaseInput.Input1) + int.Parse(testCaseInput.Input2);

                var testCase = new TestCase
                {
                    Input1 = testCaseInput.Input1,
                    Input2 = testCaseInput.Input2,
                    Result = result.ToString(),
                    ProjectId = projectId
                };

                _context.TestCases.Add(testCase);
                await _context.SaveChangesAsync();

                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to perform addition", ex);
            }
        }

        public async Task<string> PerformSubtraction(TestCaseInputDto testCaseInput)
        {
            try
            {
                long projectId = await DetermineProjectId("Subtraction");

                int result = int.Parse(testCaseInput.Input1) - int.Parse(testCaseInput.Input2);

                var testCase = new TestCase
                {
                    Input1 = testCaseInput.Input1,
                    Input2 = testCaseInput.Input2,
                    Result = result.ToString(),
                    ProjectId = projectId
                };

                _context.TestCases.Add(testCase);
                await _context.SaveChangesAsync();

                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to perform subtraction", ex);
            }
        }

        public async Task<string> PerformMultiplication(TestCaseInputDto testCaseInput)
        {
            try
            {
                long projectId = await DetermineProjectId("Multiplication");

                int result = int.Parse(testCaseInput.Input1) * int.Parse(testCaseInput.Input2);

                var testCase = new TestCase
                {
                    Input1 = testCaseInput.Input1,
                    Input2 = testCaseInput.Input2,
                    Result = result.ToString(),
                    ProjectId = projectId
                };

                _context.TestCases.Add(testCase);
                await _context.SaveChangesAsync();

                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to perform multiplication", ex);
            }
        }

        public async Task<long> DetermineProjectId(string operationType)
        {
            return await _context.Projects
                .Where(p => p.ProjectTitle.ToLower() == operationType.ToLower())
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
        }
    }
}
