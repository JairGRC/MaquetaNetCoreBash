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
            var Direccion = Directory.GetCurrentDirectory();
            Console.WriteLine("Ingresa nombre del proyecto: ");
            string proyect = Console.ReadLine();
            string namefile = "CrearProyecto.bat";
            string ruta = Direccion + "\\" + namefile;
            string retorno = "cd ..";
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
                "set NLM=^",
                "set NL=^^^%NLM%%NLM%^%NLM%%NLM%"

            };


            basePrincipal.AddRange(claseBase);


            // RUTA REPOSITORY
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
            basePrincipal.AddRange(FileBat(claseBaseRepo, nameBaseRepo, rutaBaseRepo));
            basePrincipal.Add(retorno);
            File.WriteAllLines(ruta, basePrincipal, Encoding.UTF8);

           


            //File.WriteAllLines(RutaGenerica, claseBaseRepo, Encoding.UTF8);
            //string Connectionfactory = string.Format("\\{0}Microservice.Infraestructure\\ConnectionFactory.cs", proyect);
            //string EliminarRuta = string.Format("\\{0}Microservice.Infraestructure\\Class1.cs", proyect);
            //RutaGenerica = Direccion + Connectionfactory;
            //string[] ConnectionF = {
            //    string.Format("using {0}Microservice.Repository", proyect),
            //    "using System.Composition;",
            //    "using System.Data;",
            //    "using System.Data.Common;",
            //    "using Util;",
            //    string.Format("namespace {0}Microservice.Infraestructure", proyect),
            //        "{",
            //            "[Export(typeof(IConnectionFactory))]",
            //            "public class ConnectionFactory : IConnectionFactory",
            //            "{",
            //                "public IDbConnection GetConnection",
            //                "{",
            //                    "get",
            //                    "{",
            //                        "DbProviderFactory dbProvider = DbProviderFactories.GetFactory(TrackerConfig.databaseProvider);",
            //                        "DbConnection cn = dbProvider.CreateConnection();",
            //                        "cn.ConnectionString = TrackerConfig.connectionString;",
            //                        "return cn;",
            //                    "}",
            //                "}",
            //            "}",
            //        "}",
            //};
            //File.WriteAllLines(RutaGenerica, ConnectionF, Encoding.UTF8);
            //File.Delete(EliminarRuta);
            //// REPOSITORY 
            //string IConnectionfactory = string.Format("\\{0}Microservice.Repository\\IConnectionFactory.cs", proyect);
            //RutaGenerica = Direccion + IConnectionfactory;
            //string[] IConecction = {
            //    "using System.Data;",
            //     string.Format("namespace {0}Microservice.Repository", proyect),
            //     "{",
            //        "public interface IConnectionFactory",
            //            "{",
            //                "IDbConnection GetConnection { get; }",
            //            "}",
            //      "}"
            //};
            //File.WriteAllLines(RutaGenerica, IConecction, Encoding.UTF8);

        }
        public static List<string> FileBat(string[] clase,string nameArchivo,string ruta)
        {
            List<string> FileCreate = new();
            FileCreate.Add(String.Format("cd {0}",ruta));
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
