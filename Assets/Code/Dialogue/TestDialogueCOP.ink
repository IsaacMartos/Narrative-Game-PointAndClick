Dialogo de ejemplo 0 #speaker:BAD COP #portrait:badcop_neutral
-> main

=== main ===
Hola, esto es el texto de ejemplo 1 
+ [¿Esto funciona?]
    Si! #portrait:badcop_happy
+ [Muestra el TxT Ej 2]
    Hola, esto es el texto de ejemplo 2.(Angry) #portrait:goodcop_mad

- Bueno, supongo que esto es el texto de ejemplo 3 #speaker:GOOD COP 
#portrait:goodcop_neutral

¿Quieres repetir? #speaker:BAD COP #portrait:badcop_neutral
+ [Si]
    -> main
+ [No, terminemos]
    Adios, texto de ejemplo 4
    ->END