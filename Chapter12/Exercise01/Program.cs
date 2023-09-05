using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
           // Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string v) {
            var employee = new Employee{
                Id = 100,
                HireDate = new DateTime(2023,4,1),
                Name = "abc"
            };

            using(var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }

            
            using (var reader = XmlReader.Create((v))) {
                var serializer = new XmlSerializer(typeof(Employee));
                var emp = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(employee);
            }

        }

        private static void Exercise1_2(string v) {
            var employee = new Employee[] { 
                new Employee {
                    Id = 101,
                    HireDate = new DateTime(2023, 4, 1),
                    Name = "bcd", 
                
                }
                ,
                new Employee {
                    Id = 102,
                    HireDate = new DateTime(1980, 4, 1),
                    Name = "cdf",
                }
            
            };

            var settings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            using (var writer = XmlWriter.Create(v,settings)) {
                var serializer = new DataContractSerializer(employee.GetType());
                serializer.WriteObject(writer, employee);
            }

        }

        private static void Exercise1_3(string v) {
            using(XmlReader reader = XmlReader.Create(v)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var employee = serializer.ReadObject(reader) as Employee[];
                foreach (var Employee in employee ) {
                    Console.WriteLine("{0}{1}{2}",Employee.Id,Employee.Name,Employee.HireDate);
                }
            }
        }

        private static void Exercise1_4(string v) {
            var emp = new Employee[] {
                new Employee {
                    Id = 101,
                    HireDate = new DateTime(2023, 4, 1),
                    Name = "bcd",

                },
                new Employee {
                    Id = 102,
                    HireDate = new DateTime(1980, 4, 1),
                    Name = "cdf",
                },


            };
            using(var stream = new FileStream(v, FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(emp.GetType());
                serializer.WriteObject(stream, emp);
            }
        }
            

    }
}