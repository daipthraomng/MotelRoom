using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MotelRoom.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class

    // has a class is already inherited from identityUser that will has a property like email, username, encrypted passwork so we just have to create first name, last name vv
    public class AppUser : IdentityUser
    {
        [PersonalData] // beside the user tab it will be a persional data so we have to make that with this attribute [PersionalData]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } // ten
        [PersonalData] 
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } // ho
        [PersonalData] 
        [Column(TypeName = "nvarchar(2000)")]
        public string Address { get; set; } // dia chi
        [PersonalData] 
        [Column(TypeName = "nvarchar(50)")]
        public string PersonNo { get; set; }// so CMTND
        [PersonalData] 
        [Column(TypeName = "bit")]
        public Boolean StatusCheck { get; set; } //trang thai kiem duyet tk
        [PersonalData]
        [Column(TypeName = "bit")]
        public Boolean StatusRoleEditInfor { get; set; } //trang thai kiem duyet quyen sua info
    }
}
