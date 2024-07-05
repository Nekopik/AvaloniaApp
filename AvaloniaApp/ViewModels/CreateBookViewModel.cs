using AvaloniaApp.Access;
using AvaloniaApp.Service;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.ViewModels
{
    public class CreateBookViewModel : ViewModelBase
    {
        private string _bookName;
        private string _bookAuthor;
        private string _bookCategory;

        private MainWindowViewModel _mainWindowViewModel;
        private BookService _bookService;

        public string BookName
        {
            get => _bookName;
            set => this.RaiseAndSetIfChanged(ref _bookName, value);
        }
        public string BookAuthor
        {
            get => _bookAuthor;
            set => this.RaiseAndSetIfChanged(ref _bookAuthor, value);
        }
        public string BookCategory
        {
            get => _bookCategory;
            set => this.RaiseAndSetIfChanged(ref _bookCategory, value);
        }

        public ReactiveCommand<Unit, Unit> CreateBookCommand { get; }
        public ReactiveCommand<Unit, Unit> BackCommand { get; }

        public CreateBookViewModel(MainWindowViewModel mainWindowViewModel, IAppDbContext appDbContext)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _bookService = new BookService(appDbContext);
            CreateBookCommand = ReactiveCommand.Create(CreateBook);
            BackCommand = ReactiveCommand.Create(NavigateBack);
        }

        private async void CreateBook()
        {
            await _bookService.CreateBook(_bookName, _bookAuthor, _bookCategory);
            _mainWindowViewModel.ShowBooksView();
        }

        private void NavigateBack()
        {
            _mainWindowViewModel.ShowBooksView();
        }
    }
}
