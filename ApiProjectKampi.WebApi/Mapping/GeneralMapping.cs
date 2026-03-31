using ApiProjectKampi.WebApi.Dtos.AboutDtos;
using ApiProjectKampi.WebApi.Dtos.CategoryDtos;
using ApiProjectKampi.WebApi.Dtos.ChefDtos;
using ApiProjectKampi.WebApi.Dtos.ContactDtos;
using ApiProjectKampi.WebApi.Dtos.EmployeeTaskDtos;
using ApiProjectKampi.WebApi.Dtos.FeatureDtos;
using ApiProjectKampi.WebApi.Dtos.GroupReservationDtos;
using ApiProjectKampi.WebApi.Dtos.ImageDtos;
using ApiProjectKampi.WebApi.Dtos.MessageDtos;
using ApiProjectKampi.WebApi.Dtos.NotificationDtos;
using ApiProjectKampi.WebApi.Dtos.ProductDtos;
using ApiProjectKampi.WebApi.Dtos.ReservationDtos;
using ApiProjectKampi.WebApi.Dtos.ServiceDtos;
using ApiProjectKampi.WebApi.Dtos.TestimonialDtos;
using ApiProjectKampi.WebApi.Dtos.YummyEventDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjectKampi.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactByIdDto>().ReverseMap();

            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();

            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetMessageByIdDto>().ReverseMap();

            CreateMap<Product, GetProductByIdDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, GetServiceByIdDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();

            CreateMap<YummyEvent, CreateYummyEventDto>().ReverseMap();
            CreateMap<YummyEvent, ResultYummyEventDto>().ReverseMap();
            CreateMap<YummyEvent, UpdateYummyEventDto>().ReverseMap();
            CreateMap<YummyEvent, GetYummyEventByIdDto>().ReverseMap();

            CreateMap<Chef, ResultChefDto>().ReverseMap();
            CreateMap<Chef, GetChefByIdDto>().ReverseMap();
            CreateMap<Chef, UpdateChefDto>().ReverseMap();
            CreateMap<Chef, CreateChefDto>().ReverseMap();

            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();

            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();

            CreateMap<Image, CreateImageDto>().ReverseMap();
            CreateMap<Image, UpdateImageDto>().ReverseMap();
            CreateMap<Image, ResultImageDto>().ReverseMap();
            CreateMap<Image, GetImageByIdDto>().ReverseMap();

            CreateMap<EmployeeTask, CreateEmployeeTaskDto>().ReverseMap();
            CreateMap<EmployeeTask, ResultEmployeeTaskDto>().ReverseMap();
            CreateMap<EmployeeTask, UpdateEmployeeTaskDto>().ReverseMap();
            CreateMap<EmployeeTask, GetEmployeeTaskByIdDto>().ReverseMap();

            CreateMap<GroupReservation, GetGroupReservationByIdDto>().ReverseMap();
            CreateMap<GroupReservation, CreateGroupReservationDto>().ReverseMap();
            CreateMap<GroupReservation, UpdateGroupReservationDto>().ReverseMap();
            CreateMap<GroupReservation, ResultGroupReservationDto>().ReverseMap();
        }
    }
}
