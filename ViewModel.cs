using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using _1511.Annotations;

namespace _1511
{
    public class ViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<User> _userList = new ObservableCollection<User>();

        private string _uName;
        private string _pWord;
        private string _answer;         

        private RelayCommand _logInCommand;

        public ViewModel()
        {
            UserList.Add(new User() { UserName = "Adam", Password = "HolyNEvil" });
            UserList.Add(new User() { UserName = "Bella", Password = "Useless" });
            UserList.Add(new User() { UserName = "Cali", Password = "Adorable" });
            UserList.Add(new User() { UserName = "David", Password = "Sling" });
            UserList.Add(new User() { UserName = "Edward", Password = "NotAFuckingVampire" });
            LogInCommand = new RelayCommand(LogIn);
        }

        public void LogIn()
        {
            foreach (User user in _userList)
            {
                if (user.UserName == _uName)
                {
                    if (user.Password == _pWord)
                    {
                        //Skifter til 'LoggedPage'
                        ((Frame) Window.Current.Content).Navigate(typeof(LoggedPage));
                        break;
                    }
                    else
                    {
                        Answer = "Password Incorrect";
                        break;
                    }
                }
                else
                {
                    Answer = "UserName Incorrect";
                }
            }
        }

        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }

        public string UName
        {
            get { return _uName; }
            set { _uName = value; OnPropertyChanged();}
        }

        public string PWord
        {
            get { return _pWord; }
            set { _pWord = value; OnPropertyChanged();}
        }

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; OnPropertyChanged();}
        }

        public RelayCommand LogInCommand
        {
            get { return _logInCommand; }
            set { _logInCommand = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}