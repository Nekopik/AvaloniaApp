using AvaloniaApp.Access;
using AvaloniaApp.Model;
using AvaloniaApp.Service;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        private ObservableCollection<Book> _books;
        private Book _selectedBook;

        private BookService _bookService;
        private MainWindowViewModel _mainWindowViewModel;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set => this.RaiseAndSetIfChanged(ref _books, value);
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
        }

        public ReactiveCommand<Unit, Unit> RemoveBookCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateBookCommand { get; }

        public BooksViewModel(MainWindowViewModel mainWindowViewModel, IAppDbContext appDbContext)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _bookService = new BookService(appDbContext);

            _books = new ObservableCollection<Book>();

            RemoveBookCommand = ReactiveCommand.Create(RemoveBook);
            CreateBookCommand = ReactiveCommand.Create(CreateBook);
            RefreshBooks();
        }

        private async void RemoveBook()
        {
            await _bookService.RemoveBook(_selectedBook.Id);
            RefreshBooks();
        }

        private void CreateBook()
        {
            _mainWindowViewModel.ShowCreateBookView();
        }

        private void RefreshBooks()
        {
            _books.Clear();
            var booksFromDb = _bookService.GetBooks();
            foreach (var book in booksFromDb)
            {
                _books.Add(book);
            }
        }

    }
}
