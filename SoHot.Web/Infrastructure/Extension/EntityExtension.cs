using SoHot.Model.Models;
using SoHot.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Infrastructure.Extension
{
    public static class EntityExtension
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;

        }
        public static void UpdateRoomType(this RoomType roomType, RoomTypeViewModel roomTypeVm)
        {
            roomType.ID = roomTypeVm.ID;
            roomType.Name = roomTypeVm.Name;
            roomType.Description = roomTypeVm.Description;
            roomType.Alias = roomTypeVm.Alias;

            roomType.Image = roomTypeVm.Image;
            roomType.MaxPeople = roomTypeVm.MaxPeople;

            roomType.CreatedDate = roomTypeVm.CreatedDate;
            roomType.CreatedBy = roomTypeVm.CreatedBy;
            roomType.UpdatedDate = roomTypeVm.UpdatedDate;
            roomType.UpdatedBy = roomTypeVm.UpdatedBy;
            roomType.MetaKeyword = roomTypeVm.MetaKeyword;
            roomType.MetaDescription = roomTypeVm.MetaDescription;
            roomType.Status = roomTypeVm.Status;

        }
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }
        public static void UpdateReservation(this Reservation reservation, ReservationViewModel reservationVm)
        {
            reservation.ID = reservationVm.ID;
            reservation.CheckInDateTime = reservationVm.CheckInDateTime;
            reservation.CheckOutDateTime = reservationVm.CheckOutDateTime;
            reservation.CreatedBy = reservationVm.CreatedBy;
            reservation.CreatedDate = reservationVm.CreatedDate;
            reservation.CustomerID = reservationVm.CustomerID;
            reservation.Deposit = reservationVm.Deposit;
            reservation.IsPaid = reservationVm.IsPaid;
            reservation.MetaDescription = reservationVm.MetaDescription;
            reservation.MetaKeyword = reservationVm.MetaKeyword;
            reservation.Note = reservationVm.Note;
            reservation.Price = reservationVm.Price;
            reservation.Quantity = reservationVm.Quantity;
           // reservation.Rooms = reservatioVm.
            reservation.Status = reservationVm.Status;
            reservation.Total = reservationVm.Total;
            reservation.UpdatedBy = reservationVm.UpdatedBy;
            reservation.UpdatedDate = reservationVm.UpdatedDate;
       
        }
        public static void UpdateRoom(this Room room, RoomViewModel roomVm)
        {
            room.ID = roomVm.ID;
            room.Name = roomVm.Name;
            room.Description = roomVm.Description;
          
            room.RoomTypeID = roomVm.RoomTypeID;
            room.Image = roomVm.Image;
            room.MoreImages = roomVm.MoreImages;
            room.Price = roomVm.Price;
            room.PromotionPrice = roomVm.PromotionPrice;
           
            room.HotFlag = roomVm.HotFlag;
            room.ViewCount = roomVm.ViewCount;

            room.CreatedDate = roomVm.CreatedDate;
            room.CreatedBy = roomVm.CreatedBy;
            room.UpdatedDate = roomVm.UpdatedDate;
            room.UpdatedBy = roomVm.UpdatedBy;
            room.MetaKeyword = roomVm.MetaKeyword;
            room.MetaDescription = roomVm.MetaDescription;
            room.Status = roomVm.Status;
            room.Tags = roomVm.Tags;
        }
        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.ID = customerVm.ID;
            customer.Name = customerVm.Name;
            customer.Nationality = customerVm.Nationality;
            customer.PassportNumber = customerVm.PassportNumber;
            customer.Phone = customerVm.Phone;
            customer.Status = customerVm.Status;
            customer.UpdatedBy = customerVm.UpdatedBy;
            customer.UpdatedDate = customerVm.UpdatedDate;
            customer.FacebookID = customerVm.FacebookID;
            customer.Email = customerVm.Email;
            customer.DateOfBirth = customerVm.DateOfBirth;
            customer.CreatedDate = customerVm.CreatedDate;
            customer.CreatedBy = customerVm.CreatedBy;
            customer.Address = customerVm.Address;
        }

        //public static void UpdateRoomTypeWithRoomAvailable(this RoomType roomType, RoomTypeWithRoomAvailable roomTypeWithRoomAvailable)
        //{
        //    roomType.ID = roomTypeWithRoomAvailable.ID;
        //    roomType.Name = roomTypeWithRoomAvailable.Name;
        //    roomType.Description = roomTypeWithRoomAvailable.Description;
        //    roomType.Alias = roomTypeWithRoomAvailable.Alias;
        //    roomType.Image = roomTypeWithRoomAvailable.Image;
        //    roomType.MaxPeople = roomTypeWithRoomAvailable.MaxPeople;
        //    roomType.CreatedDate = roomTypeWithRoomAvailable.CreatedDate;
        //    roomType.CreatedBy = roomTypeWithRoomAvailable.CreatedBy;
        //    roomType.UpdatedDate = roomTypeWithRoomAvailable.UpdatedDate;
        //    roomType.UpdatedBy = roomTypeWithRoomAvailable.UpdatedBy;
        //    roomType.MetaKeyword = roomTypeWithRoomAvailable.MetaKeyword;
        //    roomType.MetaDescription = roomTypeWithRoomAvailable.MetaDescription;
        //    roomType.Status = roomTypeWithRoomAvailable.Status;
        //}

        //public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackVm)
        //{
        //    feedback.Name = feedbackVm.Name;
        //    feedback.Email = feedbackVm.Email;
        //    feedback.Message = feedbackVm.Message;
        //    feedback.Status = feedbackVm.Status;
        //    feedback.CreatedDate = DateTime.Now;
        //}

        //public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        //{
        //    order.CustomerName = orderVm.CustomerName;
        //    order.CustomerAddress = orderVm.CustomerName;
        //    order.CustomerEmail = orderVm.CustomerName;
        //    order.CustomerMobile = orderVm.CustomerName;
        //    order.CustomerMessage = orderVm.CustomerName;
        //    order.PaymentMethod = orderVm.CustomerName;
        //    order.CreatedDate = DateTime.Now;
        //    order.CreatedBy = orderVm.CreatedBy;
        //    order.Status = orderVm.Status;
        //    order.CustomerId = orderVm.CustomerId;
        //}

        //public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        //{
        //    appGroup.ID = appGroupViewModel.ID;
        //    appGroup.Name = appGroupViewModel.Name;
        //}

        //public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        //{
        //    if (action == "update")
        //        appRole.Id = appRoleViewModel.Id;
        //    else
        //        appRole.Id = Guid.NewGuid().ToString();
        //    appRole.Name = appRoleViewModel.Name;
        //    appRole.Description = appRoleViewModel.Description;
        //}
        //public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        //{

        //    appUser.Id = appUserViewModel.Id;
        //    appUser.FullName = appUserViewModel.FullName;
        //    appUser.BirthDay = appUserViewModel.BirthDay;
        //    appUser.Email = appUserViewModel.Email;
        //    appUser.UserName = appUserViewModel.UserName;
        //    appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        //}
    }
}
