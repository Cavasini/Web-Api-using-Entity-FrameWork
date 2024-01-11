using AutoMapper;
using Look.Dtos;
using Look.Model;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CreateUserDto, Users>();

        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();

        CreateMap<CreateTaskDto, Tasks>();
    }
}
