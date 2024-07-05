using AvaloniaApp.Access;
using AvaloniaApp.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;
        private IAppDbContext _appDbContext;
        private User _currentUser;

        public object CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        public User CurrentUser
        {
            get => _currentUser;
            set => this.RaiseAndSetIfChanged(ref _currentUser, value);
        }

        public MainWindowViewModel()
        {
            _appDbContext = new AppDbContext("Data Source=DESKTOP-F731TCH\\SQLEXPRESS;Integrated Security=True");
            CurrentView = new LoginViewModel(this, _appDbContext);
        }

        public void ShowBooksView()
        {
            CurrentView = new BooksViewModel(this, _appDbContext);
        }

        public void ShowCreateNoteView()
        {
            CurrentView = new CreateBookViewModel(this, _appDbContext);
        }

        public void ShowLoginView()
        {
            CurrentView = new LoginViewModel(this, _appDbContext);
        }

        public void ShowRegisterView()
        {
            CurrentView = new RegisterViewModel(this, _appDbContext);
        }

    }
}
