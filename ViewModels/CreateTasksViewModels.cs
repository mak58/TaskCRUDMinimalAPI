using Flunt.Notifications;
using Flunt.Validations;
using Minimal.Models;

namespace Minimal.ViewModels
{
    public class CreateTasksViewModels : Notifiable<Notification>
    {
        public string Title { get; set; }

        /// <summary>
        /// Method to validate the incoming data to Insert in the dataBase.
        /// </summary>
        /// <returns></returns>
        public Tasks MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título da tarefa!")
                .IsGreaterThan(Title, 5, "O Titulo deve conter mais que 5 caracteres!"));

                return new Tasks(Guid.NewGuid(), Title, false);
        }
    }
}