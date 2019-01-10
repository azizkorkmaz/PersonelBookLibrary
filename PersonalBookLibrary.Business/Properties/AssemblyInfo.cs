using PersonalBookLibrary.Core.Aspects.Postsharp.ExceptionAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.LogAspects;
using PersonalBookLibrary.Core.Aspects.Postsharp.PerformanceAspects;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PersonalBookLibrary.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PersonalBookLibrary.Business")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//buraya bütün managerlarımızda ki classları logla demiş oluyoruz.
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes =
    "PersonalBookLibrary.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes =
    "PersonalBookLibrary.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(FileLogger), AttributeTargetTypes =
    "PersonalBookLibrary.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(AttributeTargetTypes =
    "PersonalBookLibrary.Business.Concrete.Managers.*")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("bbec9227-8b62-4303-96d2-9c5e1896617e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
