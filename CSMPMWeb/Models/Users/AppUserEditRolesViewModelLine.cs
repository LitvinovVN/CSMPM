using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Модель одной строки модели представления изменения ролей пользователя
    /// </summary>
    public class AppUserEditRolesViewModelLine
    {
        public string RoleName { get; set; }
        public bool IsInRole { get; set; }        
        public bool IsInRole_Edited { get; set; }
    }
}
