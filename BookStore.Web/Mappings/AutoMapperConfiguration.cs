using AutoMapper;
using BookStore.Model.Models;
using BookStore.Web.Models;

namespace BookStore.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<Footer, FooterViewModel>();
            Mapper.CreateMap<Slide, SlideViewModel>();
            Mapper.CreateMap<ContactDetail, ContactDetailViewModel>();


            //Mapper.Initialize(cfg => cfg.CreateMap<Post, PostViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<PostCategory, PostCategoryViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Tag, TagViewModel>());

            //Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductViewModel>());
            //Mapper.Initialize(cfg => cfg.CreateMap<ProductTag, ProductTagViewModel>());


        }
    }
}