## Using RazorLight

Install with `dotnet add package RazorLight`

Altenatives are : `RazorEngine` which I couldn't get working

Weirdly enough, RL needs `.UseEmbeddedResourcesProject(typeof(ViewModel))`.
`ViewModel` can be **ANY** class in the app's assembly. Here, we use `Dummy`

The only issue is that one needs to add the following to `*.csproj`

```xml
  <PropertyGroup>
   <PreserveCompilationContext>true</PreserveCompilationContext>
  </PropertyGroup>
```

Docs are [here:](https://github.com/toddams/RazorLight)