using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user", (IMapper mapper) =>
{
    var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
    var model = mapper.Map<UserModel>(user);
    return model;
}).WithName("GetUsers");

app.Run();

public class User
{
    public User(Guid id, string name, string lastname)
    {
        Id = id;
        Name = name;
        LastName = lastname;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
}

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
    }
}