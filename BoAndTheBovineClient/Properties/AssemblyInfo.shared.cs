using System.Reflection;

//  Shared information between projects go here.
// http://blogs.msdn.com/b/jjameson/archive/2009/04/03/shared-assembly-info-in-visual-studio-projects.aspx

// Make it easy to distinguish Debug and Release (i.e. Retail) builds;
// for example, through the file properties window.
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Flavour=Debug")] // a.k.a. "Comments"
#else
[assembly: AssemblyConfiguration("Retail")]
[assembly: AssemblyDescription("Flavour=Retail")] // a.k.a. "Comments"
#endif

[assembly: AssemblyCompany("LIUS")]
[assembly: AssemblyProduct("Bo and the Bovine")]
[assembly: AssemblyCopyright("Free and open source license 2012")]
[assembly: AssemblyTrademark("F/OSS")]


//  We use semantic versioning:
//  http://semver.org
//  plus a trailing wildcard.  Maybe we should remove the wildcard as times goes - I don't know how
//  it will affect build versioning in the future.
//  As from the documentation:
//  (Major.Minor.Patch). Bug fixes not affecting the API increment the patch version, backwards 
//  compatible API additions/changes increment the minor version, and backwards incompatible API changes 
//  increment the major version.
[assembly: AssemblyVersion("1.3.2.*")]
[assembly: AssemblyFileVersion("1.3.2.*")]