import UIKit

/*
 TASK
 Реализовать ООП модель Национальной библиотеки Республики Татарстан.

 Требования:

 Минимум 5 классов, 3 структуры, 2 протокола, 2 enum.
 Из части классов должна выстраиваться иерархия наследования с переопределением методов.
 Необходимо использовать разные модификаторы доступа.
 */

internal enum Genre{
    case detective
    case sci_fi
    case horror
    case fairyTale
    case fantasy
    case historical
}

internal enum Language{
    case russian
    case english
    case tatar
}

internal struct AuthorInfo {
    var name: String
    var birthYear: Int
}

internal struct BookCategory {
    var name: String
    var description: String
}

internal struct LibraryInfo {
    var libraryName: String
    var location: String
    var numBooks: Int
}

internal protocol BookProtocol {
    var title: String { get }
    var author: String { get }
    var genre: Genre { get }
    var language: Language { get }
}

internal protocol ReaderProtocol {
    var name: String { get }
    var id: Int { get }
    
    func readBook(book: Book)
    func readBooksList()
}

internal class Book: BookProtocol {
    var title: String
    var author: String
    var genre: Genre
    var language: Language
    
    init(title: String, author: String, genre: Genre, language: Language) {
        self.title = title
        self.author = author
        self.genre = genre
        self.language = language
    }
}

internal class Reader: ReaderProtocol {
    var name: String
    var id: Int
    private var readBooks: [Book] = []
    
    init(name: String, id: Int) {
        self.name = name
        self.id = id
    }
    
    func readBook(book: Book) {
            readBooks.append(book)
            print("reader: \(name), id : \(id) read '\(book.title)' by \(book.author)")
        }
    
    func readBooksList() {
            if readBooks.isEmpty {
                print("reader: \(name), id: \(id) has no read books.")
            } else {
                print("reader: \(name), id: \(id) has read the following books:")
                for book in readBooks {
                    print("- '\(book.title)' by \(book.author)")
                }
            }
        }
}

internal class LibraryStaff {
    var name: String
    var employeeID: Int
    
    init(name: String, employeeID: Int) {
        self.name = name
        self.employeeID = employeeID
    }
    
    func issueBook(book: Book, to reader: Reader) {
        reader.readBook(book: book)
    }
}

internal class NationalLibrary {
    var libraryInfo: LibraryInfo
    var authorInfo: AuthorInfo
    var books: [Book]
    var staff: [LibraryStaff]
    var readers: [Reader]
    
    init(libraryInfo: LibraryInfo, authorInfo: AuthorInfo, books: [Book], staff: [LibraryStaff], readers: [Reader]) {
        self.libraryInfo = libraryInfo
        self.authorInfo = authorInfo
        self.books = books
        self.staff = staff
        self.readers = readers
    }
    
    func searchBook(byTitle title: String) -> Book? {
        return books[0]
    }
    
    func searchBooks(byAuthor author: String) -> [Book] {
        return books
    }
    
    func availableBooks() -> [Book] {
        return books
    }
}

internal class TatarstanNationalLibrary : NationalLibrary {
    
    
    override func searchBook(byTitle title: String) -> Book? {
        return books.first(where: { $0.title.lowercased() == title.lowercased() })
    }
    
    override func searchBooks(byAuthor author: String) -> [Book] {
        return books.filter({ $0.author.lowercased() == author.lowercased() })
    }
    
    override func availableBooks() -> [Book] {
        return books
    }
}

// books
let book1 = Book(title: "Война и мир", author: "Лев Толстой", genre: .historical, language: .russian)
let book2 = Book(title: "1984", author: "Джордж Оруэлл", genre: .historical, language: .english)
let book3 = Book(title: "Мастер и Маргарита", author: "Михаил Булгаков", genre: .historical, language: .russian)

// lib staff
let librarian1 = LibraryStaff(name: "Александр", employeeID: 1)
let librarian2 = LibraryStaff(name: "Елена", employeeID: 2)

// lib readers
let reader1 = Reader(name: "Иван", id: 1)
let reader2 = Reader(name: "Мария", id: 2)

let libraryInfo = LibraryInfo(libraryName: "Национальная библиотека Республики Татарстан", location: "Казань", numBooks: 3)

// authors
let authorInfo = AuthorInfo(name: "Лев Толстой", birthYear: 1828)

// create lib
var nationalLibrary = TatarstanNationalLibrary(libraryInfo: libraryInfo, authorInfo: authorInfo, books: [book1, book2, book3], staff: [librarian1, librarian2], readers: [reader1, reader2])

// search books
if let foundBook = nationalLibrary.searchBook(byTitle: "Война и мир") {
    print("Найдена книга: '\(foundBook.title)' by \(foundBook.author)")
} else {
    print("Книга не найдена")
}

let booksByAuthor = nationalLibrary.searchBooks(byAuthor: "Михаил Булгаков")
if !booksByAuthor.isEmpty {
    print("Найдены книги автора 'Михаил Булгаков':")
    for book in booksByAuthor {
        print("- '\(book.title)'")
    }
} else {
    print("Книги автора 'Михаил Булгаков' не найдены")
}

// search available books
let availableBooks = nationalLibrary.availableBooks()
if !availableBooks.isEmpty {
    print("Доступные книги:")
    for book in availableBooks {
        print("- '\(book.title)' by \(book.author)")
    }
} else {
    print("Нет доступных книг")
}

librarian1.issueBook(book: book1, to: reader1)

reader1.readBooksList()

