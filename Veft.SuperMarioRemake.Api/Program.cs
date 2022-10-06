using GraphQL;
using GraphQL.Types;
using Veft.SuperMarioRemake.Api.Schema;
using Veft.SuperMarioRemake.Api.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SMBData>();

builder.Services.AddGraphQL (qlBuilder => 
    qlBuilder.AddSystemTextJson()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
    .AddSchema<SMBSchema>()
    .AddGraphTypes());

var app = builder.Build();

app.UseGraphQLPlayground();
app.UseGraphQL<ISchema>();

app.MapGet("/", handler => {
    handler.Response.Redirect("/ui/playground");
    return Task.CompletedTask;
}

);


app.Run();
