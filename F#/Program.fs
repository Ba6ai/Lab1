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

type Complex = { re: float; im: float }

// Сложение
let add x y = { re = x.re + y.re; im = x.im + y.im }

// Вычитание
let sub x y = { re = x.re - y.re; im = x.im - y.im }

// Умножение
let mul x y = { 
    re = x.re * y.re - x.im * y.im
    im = x.re * y.im + x.im * y.re 
}

// Деление
let div x y =
    let znam = y.re * y.re + y.im * y.im
    { re = (x.re * y.re + x.im * y.im) / znam
      im = (x.im * y.re - x.re * y.im) / znam }

// Возведение в степень (целую)
let rec pow z n =
    match n with
    | 0 -> { re = 1.0; im = 0.0 }
    | 1 -> z
    | n when n < 0 -> div { re = 1.0; im = 0.0 } (pow z -n)
    | n -> mul z (pow z (n-1))

// Функция для красивого вывода комплексного числа
let printComplex (c: Complex) =
    if c.im >= 0 then
        printf "%f + %fi" c.re c.im
    else
        printf "%f - %fi" c.re (abs c.im)


[<EntryPoint>] //точка входа
let main _ =
    let res = inputNum[]
    printfn "Список завершён %A" res

    printf "Введите число для поиска в нём минимальной цифры: "
    let num = int(Console.ReadLine())
    printfn "Минимальная цифра %A" (minNum num)

    printfn "\n Комплексные числа"
    let a = { re = 2.0; im = 3.0 }
    let b = { re = 1.0; im = 4.0 }
    
    printf "a = "
    printComplex a
    printfn ""
    
    printf "b = "
    printComplex b
    printfn ""
    
    printf "a + b = "
    printComplex (add a b)
    printfn ""
    
    printf "a - b = "
    printComplex (sub a b)
    printfn ""
    
    printf "a * b = "
    printComplex (mul a b)
    printfn ""
    
    printf "a / b = "
    printComplex (div a b)
    printfn ""
    
    printf "a^2 = "
    printComplex (pow a 2)
    printfn ""
    
    printf "a^(-1) = "
    printComplex (pow a -1)
    printfn ""

    0 // то же что и return 0