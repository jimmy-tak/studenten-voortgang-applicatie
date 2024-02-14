using studenten_voortgang_applicatie.Models;
using studenten_voortgang_applicatie.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using static System.Environment;

namespace studenten_voortgang_applicatie.Controllers
{
    internal class FileController
    {
        private string _folderName = Environment.GetFolderPath(SpecialFolder.ApplicationData) + "\\studenten_voortgang_applicatie";
        private string _schoolFileName = "schools.json";
        private string _studentFileName = "students.json";
        private string _employeeFileName = "employees.json";
        private string _teacherFileName = "teachers.json";
        private string _courseFileName = "coures.json";

        private JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters =
                {
                    new JsonStringEnumConverter()
                }
        };

        public FileController()
        {
            // create the folder containging the apps files if it does not exist yet
            try
            {
                if (!Directory.Exists(_folderName))
                {
                    Directory.CreateDirectory(_folderName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to initiate FileController. Reason: {ex.Message}");
                Environment.Exit(1);
            }            
        }

        public void WriteSchool(School school)
        {
            try
            {
                File.WriteAllText(_folderName + "\\" + _schoolFileName, JsonSerializer.Serialize(school, _options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing students to file. Reason: {ex.Message}");
            }
        }

        public void WriteEmployees(IEnumerable<Employee> employees)
        {
            try
            {
                File.WriteAllText(_folderName + "\\" + _employeeFileName, JsonSerializer.Serialize(employees, _options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing students to file. Reason: {ex.Message}");
            }
        }

        public void WriteTeachers(IEnumerable<Teacher> teachers)
        {
            try
            {
                File.WriteAllText(_folderName + "\\" + _teacherFileName, JsonSerializer.Serialize(teachers, _options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing students to file. Reason: {ex.Message}");
            }
        }

        public School LoadSchool()
        {
            string fileContent = String.Empty;
            try
            {
                fileContent = File.ReadAllText(_folderName + "\\" + _schoolFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading students from file. Reason: {ex.Message}");
            }
            return JsonSerializer.Deserialize<School>(fileContent);
        }

        public IEnumerable<Employee> LoadEmployees()
        {
            string fileContent = String.Empty;
            try
            {
                fileContent = File.ReadAllText(_folderName + "\\" + _employeeFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading students from file. Reason: {ex.Message}");
            }
            return JsonSerializer.Deserialize<HashSet<Employee>>(fileContent);
        }

        public IEnumerable<Teacher> LoadTeachers()
        {
            string fileContent = String.Empty;
            try
            {
                fileContent = File.ReadAllText(_folderName + "\\" + _teacherFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading students from file. Reason: {ex.Message}");
            }
            return JsonSerializer.Deserialize<HashSet<Teacher>>(fileContent);
        }

        //public IEnumerable<Student> LoadStudents()
        //{
        //    string fileContent = String.Empty;
        //    try
        //    {
        //        fileContent = File.ReadAllText(_folderName + "\\" + _studentFileName);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine($"Error reading students from file. Reason: {ex.Message}");
        //    }
        //    return JsonSerializer.Deserialize<HashSet<Student>>(fileContent);
        //}

        //public void WriteStudents(IEnumerable<Student> students)
        //{
        //    try
        //    {
        //        File.WriteAllText(_folderName + "\\" + _studentFileName, JsonSerializer.Serialize(students, _options));
        //    }
        //    catch(Exception ex) 
        //    {
        //        Console.WriteLine($"Error writing students to file. Reason: {ex.Message}");
        //    }
        //}


    }
}
