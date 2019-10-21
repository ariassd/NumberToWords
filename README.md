# NumbersToWords
Extension de la clase decimal para convertir números a letras, en español

Ejemplo de uso

```c#
var a = 1312313.13m;
var r = a.ToWords(showDecimals: true);
Console.Write(r);
Console.ReadLine();

decimal n = 20003004000;
Console.WriteLine($"number: {n.ToString("#,#.00#;(#,#.00#)")}");
Console.WriteLine(n.ToWords(false));

```

```bash
un millón trecientos doce mil trecientos trece con trece céntimos
```