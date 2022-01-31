using System.Reflection;
using AutoMapper;
//using HelloWorldGenerated;
using EnumGenerators;

HelloWorldGenerated.HelloWorld.SayHello();

//using MapProfilesGenerated;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddAutoMapper(x=>x.AddProfile<TodoApiProfile>());


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
    var user = new User(
        Guid.NewGuid(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString());

    var model = mapper.Map<UserModel>(user);

    return model;
}).WithName("GetUsers");

app.Run();

public class User
{
    public User(Guid id, string name, string lastname, string cityName)
    {
        Id = id;
        Name = name;
        LastName = lastname;
        CityName = cityName;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string CityName { get; private set; }
}

public class UserModel : IMapFrom<User>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }

    /*public void Mapping(Profile configuration)
    {
        configuration.CreateMap<User, UserModel>()
            .ForMember(destination => destination.City, source
                => source.MapFrom(src => src.CityName));
    }*/
}


public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>().ForMember(destination => destination.City, source
            => source.MapFrom(src => src.CityName));
    }
}

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}
// https://github.com/dotnet/roslyn/issues/44093
[EnumExtensions] // Our marker attribute
public enum Colour
{
    Red = 0,
    Blue = 1,
}
