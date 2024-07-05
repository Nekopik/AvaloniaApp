﻿using AvaloniaApp.Access;
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
            _appDbContext = new AppDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            CurrentView = new LoginViewModel(this, _appDbContext);
        }

        public void ShowBooksView()
        {
            CurrentView = new BooksViewModel(this, _appDbContext);
        }

        public void ShowCreateBookView()
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
