using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> studentsList = new List<Student>();
            studentsList.Add(new Student("Артур", "Морган", 20, 2, 100));
            studentsList.Add(new Student("Джон", "Черчиль", 35, 3, 100));
            studentsList.Add(new Student("Рон", "Карлос", 23, 2, 60));

            SaveAsXmlFormat(studentsList, "data.xml");
            LoadFromXmlFormat(ref studentsList, "data.xml");

            foreach (var student in studentsList)
            {
                Console.WriteLine("Имя: {0}, Фамилия: {1}, Возраст: {2}, Курс: {3}, Успеваемость: {4}", student.FirstName, student.LastName, student.Age, student.Course, student.Score);
            }
            Console.WriteLine();

            //Task 1
            Type dateTimeType = typeof(DateTime);

            PropertyInfo[] properties = dateTimeType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }

            Console.ReadLine();
        }

        static void SaveAsXmlFormat(List<Student> obj, string fileName)
        {
            // Сохранить объект класса Student в файле fileName в формате XML
            // typeof(Student) передает в XmlSerializer данные о классе.
            // Внутри метода Serialize происходит большая работа по постройке
            // графа зависимостей для последующего создания xml-файла.
            // Процесс получения данных о структуре объекта называется рефлексией.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            // Создаем файловый поток(проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create,
            FileAccess.Write);
            // В этот поток записываем сериализованные данные(записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }

        static void LoadFromXmlFormat(ref List<Student> obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            obj = (List<Student>)xmlFormat.Deserialize(fStream);
            fStream.Close();

        }
    }
}
