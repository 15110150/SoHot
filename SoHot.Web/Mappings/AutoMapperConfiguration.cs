using AutoMapper;
using SoHot.Model.Models;
using SoHot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            Mapper.CreateMap<Bill, BillViewModel>();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<Footer, FooterViewModel>();
            Mapper.CreateMap<Page, PageViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<PostTag, PostCategoryViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Reservation, ReservationViewModel>();
            Mapper.CreateMap<RoomService, RoomServiceViewModel>();
            Mapper.CreateMap<RoomTag, RoomTagViewModel>();
            Mapper.CreateMap<RoomType, RoomTypeViewModel>();
            Mapper.CreateMap<Room, RoomViewModel>();
            //Mapper.CreateMap<Service, ServiceViewModel>();
            Mapper.CreateMap<Slide, SlideViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

            ////Mapper.<Post, PostViewModel>();
            //Mapper.CreateMap<RoomType, RoomTypeViewModel>().ReverseMap();
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<Post, PostViewModel>();
            //});
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Customer, CustomerViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<Page, PageViewModel>();
            //});
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Footer, FooterViewModel>();
            //});
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Bill, BillViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<RoomService, RoomServiceViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<RoomTag, RoomTagViewModel>();
            //});
            ////Mapper.Initialize(cfg => {
            ////    cfg.CreateMap<RoomType, RoomTypeViewModel>();
            ////});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<Room, RoomViewModel>();
            //});
           
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Reservation, ReservationViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<PostCategory, PostCategoryViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<PostTag, PostTagViewModel>();
            //});
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<Tag, TagViewModel>();
            //});
           
        }
    }
}