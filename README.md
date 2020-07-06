Related to the following commentary on question **[16897](https://github.com/dotnet/roslyn/issues/16897 "16897")**: https://github.com/dotnet/roslyn/issues/16897#issuecomment-654201654

Code sample for executing dynamic expressions with **Microsoft.CodeAnalysis.CSharp.Scripting** features.

Currently a performance problem documented in the issue https://github.com/dotnet/roslyn/issues/16897.

I managed to greatly improve the performance problem, using an [expression simplifier](https://github.com/silvairsoares/CSharpScriptWebApi/blob/master/CSharpScriptWebApi/Controllers/ScriptsController.cs "expression simplifier"). In addition to using an empty script validator (singleton), injected into the controllers via **Microsoft.Extensions.DependencyInjection**.

This project is a simple Web API, configured to display the two endpoints "api/script/GlobalsParameter" and "api/script/SimplifyExpression" in the Swagger interface.

Slow method:
![](https://user-images.githubusercontent.com/18450095/86591973-f0762500-bf68-11ea-9778-7bdf0a5143e4.jpg)

Improved method:
![](https://user-images.githubusercontent.com/18450095/86591984-f53ad900-bf68-11ea-87c2-9767f2279e74.jpg)
