using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaxiAppsWebAPICore.Helper.InterFace
{
   
        /// <summary>
        /// Helper functions that make reflection handling easier
        /// </summary>
        public static class Reflections
        {
            /// <summary>
            /// Get location of the entry assembly
            /// </summary>
            /// <returns></returns>
            public static DirectoryInfo GetEntryAssemblyLocation()
            {
                return new FileInfo(Assembly.GetEntryAssembly().Location).Directory;
            }

            /// <summary>
            /// Get location of the entry assembly
            /// </summary>
            /// <returns></returns>
            public static DirectoryInfo GetCurrentAssemblyLocation()
            {
                return new FileInfo(Assembly.GetCallingAssembly().Location).Directory;
            }

            /// <summary>
            /// Gets the entry assemblies comment xml file name
            /// </summary>
            /// <returns></returns>
            public static string GetApplicationCommentFile()
            {
                return $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            }

            /// <summary>
            /// Get application version string
            /// </summary>
            /// <returns></returns>
            public static string GetAppVersion()
            {
                var assembly = Assembly.GetEntryAssembly();
                var version = assembly.GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            }

            /// <summary>
            /// Get the file info with root relative path arguments
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static FileInfo GetRootRelativeFile(params string[] path)
            {
                List<string> args = new List<string>();
                args.Add(GetEntryAssemblyLocation().FullName);
                args.AddRange(path);
                return new FileInfo(GetFullPath(args.ToArray()));
            }

            /// <summary>
            /// Get combined full path
            /// </summary>
            /// <param name="args"></param>
            /// <returns></returns>
            private static string GetFullPath(params string[] args)
            {
                return Path.GetFullPath(Path.Combine(args));
            }


            /// <summary>
            /// Get the file info with root relative path arguments
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static FileInfo GetAssemblyRelativeFile(params string[] path)
            {
                List<string> args = new List<string>();
                args.Add(GetCurrentAssemblyLocation().FullName);
                args.AddRange(path);
                return new FileInfo(GetFullPath(args.ToArray()));
            }

            /// <summary>
            /// Get root relative dir
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static DirectoryInfo GetRootRelativeDir(params string[] path)
            {
                List<string> args = new List<string>();
                args.Add(GetEntryAssemblyLocation().FullName);
                args.AddRange(path);
                return new DirectoryInfo(GetFullPath(args.ToArray()));
            }

            /// <summary>
            /// Get assembly relative directory
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static DirectoryInfo GetAssemblyRelativeDir(params string[] path)
            {
                List<string> args = new List<string>();
                args.Add(GetCurrentAssemblyLocation().FullName);
                args.AddRange(path);
                return new DirectoryInfo(GetFullPath(args.ToArray()));
            }

            /// <summary>
            /// Get public concreate implementations of the specified type defined in the assembly
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="assembly"></param>
            /// <returns></returns>
            public static IEnumerable<Type> GetImplementation<T>(this Assembly assembly)
            {
                return GetImplementation(assembly, typeof(T));
            }

            public static IEnumerable<Type> GetImplementation(this Assembly assembly, Type type)
            {
                return assembly.GetTypes().Where(t => t.IsPublic && !t.IsSealed && !t.IsAbstract && !t.IsInterface && type.IsAssignableFrom(t));
            }

            /// <summary>
            /// Load assembly file from physical location
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static Assembly LoadPhysicalFile(string path)
            {
#pragma warning disable S3885
                return Assembly.LoadFrom(path);
#pragma warning restore S3885
            }

            /// <summary>
            /// Create type from specified assembly
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="assembly"></param>
            /// <param name="typeName"></param>
            /// <returns></returns>
            public static T CreateInstance<T>(this Assembly assembly, string typeName, params object[] args)
            {
                var type = assembly.GetType(typeName);

                if (type == null)
                    throw new InvalidOperationException($"Type {typeName} not found in assemby {assembly.FullName}");

                return (T)Activator.CreateInstance(type, args);
            }

            /// <summary>
            /// Create type from assembly file
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="assemblyPath"></param>
            /// <param name="typeName"></param>
            /// <returns></returns>
            public static T CreateInstanceFromFile<T>(string assemblyPath, string typeName)
            {
                var assem = LoadPhysicalFile(assemblyPath);
                return CreateInstance<T>(assem, typeName);
            }
        }
}
