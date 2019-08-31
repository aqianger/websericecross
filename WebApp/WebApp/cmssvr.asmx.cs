using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebApp
{
    /// <summary>
    /// Summary description for cmssvr
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  [System.Web.Script.Services.ScriptService]
    public class cmssvr : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string Test()
        {
            return "[{\"id\":123,\"name\":\"zhengjing\"},{\"id\":124,\"name\":\"lishi\"}]";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]  //ajax调用时加上这句话
        public List<Student> getStudents()
        {
            //Student s = new Student() {Id= 1,Name= "sa",Age= 18 };
            List<Student> list = new List<Student>() {
            new Student(){ Id= 1,Name= "zhangsna",Age= 19},
            new Student(){Id=2,Name="lisi",Age=23},
            new Student(){Id =3,Name="hehe",Age=32}
        };
            return list;
        }
        [WebMethod]
        public Student getStudent()
        {
            Student s = new Student() { Id = 1, Name = "sa", Age = 18 };

            return s;
        }
    }
    public class Student
    {
        public Student()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }

    }
}
