﻿using Bills_System_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bills_System_API.Controllers
{
    public class Validation : Controller
    {
        private readonly BillsContext db;

        public Validation(BillsContext db)
        {
            this.db = db;
        }
        public IActionResult SellingPrice(double SellingPrice, double BuyingPrice)
        {
            if (BuyingPrice > SellingPrice)
                return Json(false);
            return Json(true);
        }

        public IActionResult Quantity(int Quantity, int ItemId) 
        {
            var item = db.Items.FirstOrDefault(i => i.Id == ItemId);
            
            if (Quantity > item.RemainingQuantity)
                return Json(false);
            return Json(true);
        }

        
        
        
        
        //[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        //public class Unique : ValidationAttribute
        //{
        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            var Name = validationContext.MemberName;

        //            if (string.IsNullOrEmpty(Name))
        //            {
        //                var displayName = validationContext.DisplayName;

        //                var prop = validationContext.ObjectInstance.GetType().GetProperty(displayName);

        //                if (prop != null)
        //                {
        //                    Name = prop.Name;
        //                }
        //                else
        //                {
        //                    var props = validationContext.ObjectInstance.GetType().GetProperties().Where(x => x.CustomAttributes.Count(a => a.AttributeType == typeof(DisplayAttribute)) > 0).ToList();

        //                    foreach (PropertyInfo prp in props)
        //                    {
        //                        var attr = prp.CustomAttributes.FirstOrDefault(p => p.AttributeType == typeof(DisplayAttribute));

        //                        var val = attr.NamedArguments.FirstOrDefault(p => p.MemberName == "Name").TypedValue.Value;

        //                        if (val.Equals(displayName))
        //                        {
        //                            Name = prp.Name;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }

        //            PropertyInfo IdProp = validationContext.ObjectInstance.GetType().GetProperties().FirstOrDefault(x => x.CustomAttributes.Count(a => a.AttributeType == typeof(KeyAttribute)) > 0);

        //            int Id = (int)IdProp.GetValue(validationContext.ObjectInstance, null);

        //            Type entityType = validationContext.ObjectType;


        //            var result = db.Set(entityType).Where(Name + "==@0", value);
        //            int count = 0;

        //            if (Id > 0)
        //            {
        //                result = result.Where(IdProp.Name + "<>@0", Id);
        //            }

        //            count = result.Count();

        //            if (count == 0)
        //                return ValidationResult.Success;
        //            else
        //                return new ValidationResult(ErrorMessageString);
        //        }


        //    }
        }
    }

