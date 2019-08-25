using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Вид деятельности
    /// </summary>
    public class TypeOfActivity
    {
        public int TypeOfActivityId { get; set; }

        [Display(Name = "Вид деятельности")]
        public string TypeOfActivityName { get; set; }

        public int? RootTypeOfActivityId { get; set; }
        public TypeOfActivity RootTypeOfActivity { get; set; }

        public List<TypeOfActivity> ChildTypeOfActivities { get; set; }
    }
}