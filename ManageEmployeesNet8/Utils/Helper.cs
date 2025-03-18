using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ManageEmployeesNet8.Utils
{
    public class Helper
    {
        //Get the display name of the Enum file
        public static string GetDisplayName(System.Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                return displayAttribute?.Name ?? value.ToString();
            }

            return value.ToString(); // Devuelve el nombre del enum si no se encuentra el atributo
        }
    }
}
