using Flunt.Notifications;
using Flunt.Validations;
using Minimal.Models;

namespace Minimal.ViewModels
{
    public class UpdateClassViewModels : Notifiable<Notification>    
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public bool Done { get; set; }

        /// <summary>
        /// Method to validate the incoming data from body to Update in the DataBase.
        /// </summary>
        /// <returns></returns>
        public Tasks MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título da tarefa!")
                .IsGreaterThan(Title, 5, "O Titulo deve conter mais que 5 caracteres!"));
            
            return new Tasks(Id, Title, Done);
        } 

        
    }
}