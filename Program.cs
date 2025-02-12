using GraphQL.API.Schema.Mutations;
using GraphQL.API.Schema.Subscriptions;
using GraphQL.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL()
    .AddTypes()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions(); ;

string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddPooledDbContextFactory<SchoolDBContext>(o => o.UseSqlite(connectionString));

builder.Services.AddCors((options) =>
{
    options.AddPolicy("DevCors", (corsBuilder) =>
    {
        corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
    options.AddPolicy("ProdCors", (corsBuilder) =>
    {
        corsBuilder.WithOrigins("https://myProductionSite.com")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddTransient<SchoolDBContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDBContext>>();
    using (var context = dbContextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
}
else
{
    app.UseCors("ProdCors");
    app.UseHttpsRedirection();
}

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
