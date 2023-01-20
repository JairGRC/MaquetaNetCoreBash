using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CreandoMaqueta
{
    class Program
    {

        static void Main(string[] args)
        {
            // COMANDOS DE BASH  - EJECUTABLE WINDOWS
            var Direccion = Directory.GetCurrentDirectory();
            Console.WriteLine("Ingresa nombre del proyecto: ");
            string proyect = Console.ReadLine();
            string namefile = "CrearProyecto.bat";
            string ruta = Direccion + "\\" + namefile;
            string retorno = "cd ..";
            string fileDelete = "del Class1.cs";
            List<string> basePrincipal = new List<string>();

            string[] claseBase =
            {
                "",
                string.Format(" dotnet new sln --name {0}",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Infraestructure  -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj -s \"01. Layer Infraestructure\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Repository  -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Repository\\{0}Microservice.Repository.csproj -s \"01. Layer Infraestructure\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Domain  -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj -s \"02. Layer Domain\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Entities  -f net6.0",proyect),

                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj -s \"02. Layer Domain\"",proyect),
                string.Format(" mkdir \"{0}Microservice.Entities/Enums\"",proyect),
                string.Format(" mkdir \"{0}Microservice.Entities/Filter\"",proyect),
                string.Format(" mkdir \"{0}Microservice.Entities/Model\"",proyect),
                string.Format(" mkdir \"{0}Microservice.Entities/Request\"",proyect),
                string.Format(" mkdir \"{0}Microservice.Entities/Response\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Exceptions  -f net6.0",proyect),

                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Exceptions\\{0}Microservice.Exceptions.csproj -s \"02. Layer Domain\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o {0}Microservice.Service  -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Service\\{0}Microservice.Service.csproj -s \"03. Layer Api\"",proyect),
                "",
                string.Format(" dotnet new classlib -lang C# -o Util  -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\Util\\Util.csproj -s \"04. Util\"",proyect),
                "",
                string.Format(" dotnet new webapi --name {0}Microservice.Api -f net6.0",proyect),
                string.Format(" dotnet sln .\\{0}.sln add .\\{0}Microservice.Api	-s \"03. Layer Api\"",proyect),
                "",
                string.Format(" dotnet add .\\Util\\Util.csproj package System.Composition -v 1.4.0",proyect),
                string.Format(" dotnet add .\\Util\\Util.csproj package Microsoft.Extensions.Configuration -v 3.1.3",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Repository\\{0}Microservice.Repository.csproj reference .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj package Dapper -v 2.0.35",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj package System.Composition -v 1.4.0",proyect),

                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj package Microsoft.Extensions.Configuration -v 3.1.3",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj reference .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj reference .\\{0}Microservice.Repository\\{0}Microservice.Repository.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj reference .\\Util\\Util.csproj",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj package System.Composition -v 1.4.0",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj reference .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj reference .\\{0}Microservice.Exceptions\\{0}Microservice.Exceptions.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj reference .\\{0}Microservice.Repository\\{0}Microservice.Repository.csproj",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj reference .\\Util\\Util.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Service\\{0}Microservice.Service.csproj reference .\\{0}Microservice.Domain\\{0}Microservice.Domain.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Service\\{0}Microservice.Service.csproj reference .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Service\\{0}Microservice.Service.csproj reference .\\{0}Microservice.Exceptions\\{0}Microservice.Exceptions.csproj",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj reference .\\{0}Microservice.Entities\\{0}Microservice.Entities.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj reference .\\{0}Microservice.Infraestructure\\{0}Microservice.Infraestructure.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj reference .\\{0}Microservice.Service\\{0}Microservice.Service.csproj",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj reference .\\Util\\Util.csproj",proyect),
                "",
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 3.1.2",proyect),
                string.Format(" dotnet add .\\{0}Microservice.Api\\{0}Microservice.Api.csproj package Swashbuckle.AspNetCore -v 5.4.1",proyect),
                "@echo off",
                "SETLOCAL ENABLEDELAYEDEXPANSION",
                ":: the two blank lines are required!",
                "set NLM=^",
                "",
                "",
                "set NL=^^^%NLM%%NLM%^%NLM%%NLM%",
                "set \"and=^&^&\"",
                "set \"menor=^<\"",
                "set \"mayor=^>\""
            };


            basePrincipal.AddRange(claseBase);


            // RUTA INFRAESTRUCTURA
            // Class1.cs
            string rutaBaseRepo = string.Format("{0}Microservice.Infraestructure", proyect);
            string nameBaseRepo = "BaseRepository.cs";
            string[] claseBaseRepo = {
                string.Format("using {0}Microservice.Repository;", proyect),
                "using System.Composition;",
                string.Format("namespace {0}Microservice.Infraestructure", proyect),
                "{",
                "public abstract class BaseRepository",
                    "{",
                        "#region IoC",
                        "[Import]",
                        "public IConnectionFactory _connectionFactory { get; set; }",

                        "[ImportingConstructor]",
                        "public BaseRepository(IConnectionFactory connectionFactory)",
                        "{",
                            "_connectionFactory = connectionFactory;",
                        "}",
                        "#endregion",
                    "}",
                "}"
            };
            basePrincipal.AddRange(FileBat(claseBaseRepo, nameBaseRepo, rutaBaseRepo,true));
            nameBaseRepo = "ConnectionFactory.cs";
            string[] ConnectionF = {
                string.Format("using {0}Microservice.Repository;", proyect),
                "using System.Composition;",
                "using System.Data;",
                "using System.Data.Common;",
                "using Util;",
                string.Format("namespace {0}Microservice.Infraestructure", proyect),
                    "{",
                        "[Export(typeof(IConnectionFactory))]",
                        "public class ConnectionFactory : IConnectionFactory",
                        "{",
                            "public IDbConnection GetConnection",
                            "{",
                                "get",
                                "{",
                                    "DbProviderFactory dbProvider = DbProviderFactories.GetFactory(TrackerConfig.databaseProvider);",
                                    "DbConnection cn = dbProvider.CreateConnection();",
                                    "cn.ConnectionString = TrackerConfig.connectionString;",
                                    "return cn;",
                                "}",
                            "}",
                        "}",
                    "}",
            };
            basePrincipal.AddRange(FileBat(ConnectionF, nameBaseRepo, rutaBaseRepo));
            basePrincipal.Add(fileDelete);
            basePrincipal.Add(retorno);


            // EXCEPTIONS 
            //C: \Users\Des27\source\repos\FirmaDigital\FirmaDigitalMicroservice.Exceptions\CustomException.cs
            rutaBaseRepo = string.Format("{0}Microservice.Exceptions", proyect);
            nameBaseRepo = "CustomException.cs";
            string[] CustomException = {
                string.Format("namespace {0}Microservice.Exceptions", proyect),
                "{",
                    "public class CustomException : ApplicationException",
                    "{",
                        "public virtual string CustomMessage { get; }",
                    "}",
                "}"
            };
            basePrincipal.AddRange(FileBat(CustomException, nameBaseRepo, rutaBaseRepo, true));
            basePrincipal.Add(fileDelete);
            basePrincipal.Add(retorno);

            //CAPA UTIL 
            rutaBaseRepo = "Util";
            nameBaseRepo = "MEFContainer.cs";
            string[] MEFcontainer = {
            "using System.Composition.Hosting;",
            "using System.Reflection;",
            "using System.Runtime.Loader;",

            "namespace Util",
            "{",
                "public static class MEFContainer",
                "{",
                    "private static CompositionHost _container = null;",

                    "public static CompositionHost Container",
                    "{",
                        "get",
                        "{",
                            "if (_container == null)",
                            "{",
                                "//composition container, which contains all the parts available and performs composition.",
                                "//Composition is the matching up of imports to exports.",
                                "var executableLocation = Assembly.GetEntryAssembly().Location;",
                                "var pathAssembly = Path.GetDirectoryName(executableLocation);",


                                "var assemblies = Directory",
                                string.Format(".GetFiles(pathAssembly, \"{0}*.dll\", SearchOption.TopDirectoryOnly)",proyect) ,
                                ".Select(AssemblyLoadContext.GetAssemblyName)",
                                ".Select(AssemblyLoadContext.Default.LoadFromAssemblyName)",
                                ".ToList();",
                                "var configuration = new ContainerConfiguration().WithAssemblies(assemblies);",
                                "_container = configuration.CreateContainer();",

                            "}",
                            "return _container;",
                        "}",
                    "}",
                "}",
            "}"

            };
            basePrincipal.AddRange(FileBat(MEFcontainer, nameBaseRepo, rutaBaseRepo, true));
            nameBaseRepo = "TrackerConfig.cs";
            string[] TrackerConfig = {
            "using Microsoft.Extensions.Configuration;",
            "namespace Util",
            "{",
                "public static class TrackerConfig",
                "{",
                    "public static IConfiguration _configuration = null;",
                    "#region properties",
                    "private static string _databaseProvider = string.Empty;",
                    "public static string databaseProvider",
                    "{",
                        "get",
                        "{",
                            "if (_configuration is not null !and! string.IsNullOrEmpty(_databaseProvider))",
                            "{",
                                "_databaseProvider = _configuration[\"ConnectionStrings:databaseProvider\"];",
                            "}",
                            "return _databaseProvider;",
                        "}",
                    "}",
                    "private static string _connectionString = string.Empty;",
                    "public static string connectionString",
                    "{",
                        "get",
                        "{",
                            "if (_configuration is not null !and! string.IsNullOrEmpty(_connectionString))",
                            "{",
                                "_connectionString = _configuration[\"ConnectionStrings: cnBD\"];",
                            "}",
                            "return _connectionString;",
                        "}",
                    "}",
                    "#endregion",
                "}",
            "}"
            };
            basePrincipal.AddRange(FileBat(TrackerConfig, nameBaseRepo, rutaBaseRepo));
            basePrincipal.Add(fileDelete);
            basePrincipal.Add(retorno);


            //Capa Dominio - ENTIDADES 

            rutaBaseRepo = string.Format("{0}Microservice.Entities/Request", proyect, true);
            nameBaseRepo = "BaseRequest.cs";
            string[] BaseRequest = {
                string.Format("namespace {0}Microservice.Entities", proyect),
                    "{",
                        "public enum Operation : byte",
                        "{",
                            "Undefined,",
                            "Add,",
                            "Edit,",
                            "Delete",
                        "}",

                        "public class Pagination",
                        "{",
                            "public int PageIndex { get; set; } = 0;",
                            "public int PageSize { get; set; } = 0;",
                            "public int TotalRows { get; set; } = 0;",
                        "}",

                        "public abstract class BaseRequest",
                        "{",
                            "public Guid Ticket { get; set; } = Guid.NewGuid();",
                            "public string ClientName { get; set; } = string.Empty;",
                            "public string UserName { get; set; } = string.Empty;",
                            "public string ServerName { get; set; } = string.Empty;",
                            "public int Resultado { get; set; } = int.MaxValue;",
                        "}",

                        "public abstract class OperationRequest!menor!T!mayor! : BaseRequest",
                        "{",
                            "public T Item { get; set; }",
                            "public Operation Operation { get; set; }",
                        "}",

                       " public abstract class FilterItemRequest!menor!T, F!mayor! : BaseRequest",
                        "{",
                            "public T Filter { get; set; }",
                            "public F FilterType { get; set; }",
                        "}",

                        "public abstract class FilterLstItemRequest!menor!T, F!mayor! : BaseRequest",
                        "{",
                            "public T Filter { get; set; }",
                            "public F FilterType { get; set; }",
                            "public Pagination Pagination { get; set; } = new Pagination();",
                        "}",
                    "}",
             };
            basePrincipal.AddRange(FileBat(BaseRequest, nameBaseRepo, rutaBaseRepo, true));
            basePrincipal.Add(retorno);
            rutaBaseRepo = string.Format("Response", proyect);
            nameBaseRepo = "BaseResponse.cs";
            string[] BaseResponse =
            {
                 string.Format("namespace {0}Microservice.Entities", proyect),
                "{",
                    "public abstract class BaseResponse : BaseRequest",
                    "{",
                       " public bool IsSuccess { get; set; } = false;",
                       " public List!menor!string!mayor! LstError { get; set; } = new List!menor!string!mayor!();",
                    "}",
                    "public abstract class ItemResponse!menor!T!mayor! : BaseResponse",
                   "{",
                        "public T Item { get; set; }",
                    "}",
                    "public abstract class LstItemResponse!menor!T!mayor! : BaseResponse",
                    "{",
                        "public IEnumerable!menor!T!mayor! LstItem { get; set; } = new List!menor!T!mayor!();",
                        "public Pagination Pagination { get; set; } = new Pagination();",
                    "}",
                "}"
            };
            basePrincipal.AddRange(FileBat(BaseResponse, nameBaseRepo, rutaBaseRepo, true));
            basePrincipal.Add(retorno);
            basePrincipal.Add(fileDelete);
            basePrincipal.Add(retorno);


            // REPOSITORY 
            rutaBaseRepo = string.Format("{0}Microservice.Repository", proyect);
            nameBaseRepo = "IConnectionFactory.cs";
            string[] IConecction = {
                "using System.Data;",
                 string.Format("namespace {0}Microservice.Repository", proyect),
                 "{",
                    "public interface IConnectionFactory",
                        "{",
                            "IDbConnection GetConnection { get; }",
                        "}",
                  "}"
            };

            basePrincipal.AddRange(FileBat(IConecction, nameBaseRepo, rutaBaseRepo,true));
            nameBaseRepo = "IGenericRepository.cs";
            string[] IGenericRepository = {
                 string.Format("namespace {0}Microservice.Repository", proyect),
                    "{",
                       " public interface IGenericRepository!menor!T!mayor! where T : class",
                        "{",
                            "Task!menor!long!mayor! Insert(T item);",
                            "Task!menor!bool!mayor! Update(T item);",
                           "Task!menor!bool!mayor! Delete(long id);",
                            "Task!menor!bool!mayor! Delete(string id);",
                        "}",
                    "}"
            };
            basePrincipal.AddRange(FileBat(IGenericRepository, nameBaseRepo, rutaBaseRepo));
            basePrincipal.Add(fileDelete);
            basePrincipal.Add(retorno);
  

            



            File.WriteAllLines(ruta, basePrincipal, Encoding.UTF8);
        }
        public static List<string> FileBat(string[] clase, string nameArchivo, string ruta,bool flag =false)
        {
            List<string> FileCreate = new();
            if (flag)
            {
                FileCreate.Add(String.Format("cd {0}", ruta));
            }
            string cuerpo = "Set FileCreate=";
            foreach (var item in clase)
            {
                cuerpo = cuerpo + item + "!NL!";
            }
            FileCreate.Add(cuerpo);
            FileCreate.Add(String.Format("echo %FileCreate% >> {0}", nameArchivo));
            return FileCreate;
        }
    }
}
