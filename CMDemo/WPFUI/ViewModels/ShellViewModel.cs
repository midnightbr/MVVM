using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName;
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "John", LastName = "Lucca" });
            People.Add(new PersonModel { FirstName = "Marcos", LastName = "Defaste" });
            People.Add(new PersonModel { FirstName = "Davion", LastName = "Dragon" });
            People.Add(new PersonModel { FirstName = "Fabiana", LastName = "Drumonte" });
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }

            return true;
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public async void LoadPageOne()
        {
            await ActivateItemAsync(new FirstChildViewModel(), CancellationToken.None);
        }

        public async void LoadPageTwo()
        {
            await ActivateItemAsync(new SecondChildViewModel(), CancellationToken.None);
        }
    }
}