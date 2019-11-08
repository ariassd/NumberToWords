# NumbersToWords
Extension de la clase decimal para convertir números a letras, en español.

Extension de la clase DateTime para convertir fechas a letras, en español.

El método de extensión de fechas posee un parametro opcional llamado format que es del tipo ``` DateFormat ```
Los formatos para las fechas son:

|Formato                |Resultado                                              |
|-----------------------|-------------------------------------------------------|
|day_month              | veinticinco de octubre                                |
|day_month_year         | veinticinco de octubre de dos mil diecinueve          |
|dayName_day_month      | viernes veinticinco de octubre                        |
|dayName_day_month_year | viernes veinticinco de octubre de dos mil diecinueve	|
|month_year             | octubre de dos mil diecinueve                         |


Para usarolo solamente se debe de agregar el using de la librería o namespace de las extensiones en el caso de que se encuentren en un namespace diferente del que se desea usar.




Ejemplo de uso de números a letras

```c#

using NumberToWords;
....

var a = 1312313.13m;
var r = a.ToWords(showDecimals: true);
Console.Write(r);
Console.ReadLine();

decimal n = 20003004000;
Console.WriteLine($"number: {n.ToString("#,#.00#;(#,#.00#)")}");
Console.WriteLine(n.ToWords(false));

```

```sh

    un millón trecientos doce mil trecientos trece con trece céntimos

```


Ejemplo de uso de fechas a letras


```c#

using NumberToWords;
...

var date = DateTime.Now.ToWords(DateToWords.DateFormat.dayName_day_month_year);

Console.WriteLine($"hoy es {date}");
```

```sh

    hoy es viernes veinticinco de octubre de dos mil diecinueve
    
```
