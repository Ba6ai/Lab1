open System //библиотека
                //список целых чисел   //возвр список целых чисел
let rec inputNum (currentList: int list) : int list = //рекурсивная функция inputNum
    printfn "Формирования списка из последних цифр"
    printfn "Введите 'ex' для завершения кода"
    let input = Console.ReadLine()
    
    if input = "ex" then
        currentList // возвращение текущего списка
    else
        match Int32.TryParse(input) with // преобразование строки в число
        | (true, num) -> //проверка на правильность преобразования
            let x = num%10 //берётся последнее цифра в числе
            inputNum(currentList @[x]) //добавление числа к текущему списку
        | (false, _) ->
            printfn "Ошибка! Введите корректное число."
            inputNum currentList // Пробуем снова
          
let rec minNum (n: int) : int= // поиск минимума
    if n < 10 then n
    else
        let lastDigit = n % 10 // Последняя цифра
        let restMin = minNum (n / 10) // Минимальная цифра в оставшейся части
        min lastDigit restMin // Возвращаем минимальную из двух


[<EntryPoint>] //точка входа
let main _ =
    let res = inputNum[]
    printfn "Список завершён %A" res

    printf "Введите число для поиска в нём минимальной цифры: "
    let num = int(Console.ReadLine())
    printfn "Минимальная цифра %A" (minNum num)

    0 // то же что и return 0