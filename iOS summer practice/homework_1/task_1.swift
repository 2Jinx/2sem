import UIKit

/*
 TASK
 Реализовать структуру, которая будет имплементировать протокол HomeworkService.
 */


protocol HomeworkService {
    // Функция деления с остатком, должна вернуть в первой части результат деления, во второй части остаток.
    func divideWithRemainder(_ x: Int, by y: Int) -> (Int, Int)

    // Функция должна вернуть числа фибоначчи.
    func fibonacci(n: Int) -> [Int]

    // Функция должна выполнить сортировку пузырьком.
    func sort(rawArray: [Int]) -> [Int]

    // Функция должна преобразовать массив строк в массив первых символов строки.
    func firstLetter(strings: [String]) -> [Character]

    // Функция должна отфильтровать массив по условию, которое приходит в параметре `condition`. (Нельзя юзать `filter` у `Array`)
    func filter(array: [Int], condition: ((Int) -> Bool)) -> [Int]
}


struct Services: HomeworkService{
    
    func divideWithRemainder(_ x: Int, by y: Int) -> (Int, Int){
        let result = x / y
        let remainder = x % y
        return (result, remainder)
    }
    
    func fibonacci(n: Int) -> [Int]{
        var result : [Int] = []
        for i in 0..<n{
            result.append(countFib(n: i))
        }
        return result
    }
    // вспомогательная функция, которая считает отдельное число Фибоначчи
    private func countFib(n: Int) -> Int{
        if (n == 0 || n == 1){
            return n
        }
        else{
            return countFib(n: n - 1) + countFib(n: n - 2)
        }
    }
    
    func sort(rawArray: [Int]) -> [Int]{
        var sortedArray : [Int] = rawArray
        var flag = true
        while (flag){
            flag = false
            for i in 0..<sortedArray.count - 1{
                if (sortedArray[i] > sortedArray[i + 1]){
                    var temp = sortedArray[i]
                    sortedArray[i] = sortedArray[i + 1]
                    sortedArray[i + 1] = temp
                    flag = true
                }
            }
        }
        return sortedArray
    }
    
    func firstLetter(strings: [String]) -> [Character]{
        var chars: [Character] = []
        var element: String
        for i in 0..<strings.count{
            element = strings[i]
            chars.append(element.removeFirst())
        }
        return chars
    }
    
    func filter(array: [Int], condition: ((Int) -> Bool)) -> [Int] {
        var filteredArray = [Int]()
        
        for element in array {
            if condition(element) {
                filteredArray.append(element)
            }
        }
        
        return filteredArray
    }
}

var serv = Services()

// devide check
var result = serv.divideWithRemainder(10, by: 3)

// fibonacci check
var res: [Int] = serv.fibonacci(n: 10)

// bubble sort check
var raw : [Int] = [2, 5, 1, 3, 7, 0, 6, 4]
var sort: [Int] = serv.sort(rawArray: raw)

// chars array check
var strings : [String] = ["123", "321"]
var chars : [Character] = serv.firstLetter(strings: strings)

// filter check
var numbers: [Int] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
var filteredNumbers: [Int] = serv.filter(array: numbers) { number in
    return number % 2 == 0
}
