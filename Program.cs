using RazorLight;

var builder = WebApplication.CreateBuilder(args);



var engine = new RazorLightEngineBuilder()
	// required to have a default RazorLightProject type,
	// but not required to create a template from string.
	.UseEmbeddedResourcesProject(typeof(Dummy))
	.SetOperatingAssembly(typeof(Dummy).Assembly)
	.UseMemoryCachingProvider()
	.Build();



var app = builder.Build();

app.MapGet("/", async () => {
    var people = new Person[]
    {
          new Person("Weston", 33),
          new Person("Johnathon", 41),
    };
    var model = new {Name = "John Doe", People = people};
    string template = @"Hello, @Model.Name. 
@for (var i = 0; i < Model.People.Length; i++)
{
    var person = Model.People[i];
    <p>Name: @person.Name</p>
    <p>Age: @person.Age</p>
}
    ";
    string result = await engine.CompileRenderStringAsync("templateKey", template, model);
    return Results.Text(result,  "text/html");
});

app.Run();

class Dummy {};

public readonly record struct Person(string Name, int Age);