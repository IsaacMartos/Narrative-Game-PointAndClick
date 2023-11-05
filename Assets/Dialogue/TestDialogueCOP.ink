Dialogo de ejemplo 0 #speaker:BAD COP #portrait1:BC_neutral
-> main

=== main ===
Hola, esto es el texto de ejemplo 1 
+ [¿Esto funciona?]
    Si! #portrait1:BC_happy
+ [Muestra el TxT Ej 2]
    Hola, esto es el texto de ejemplo 2.(Angry) #portrait1:BC_angry

- Bueno, supongo que esto es el texto de ejemplo 3 #speaker:GOOD COP #portrait2:GC_neutral

¿Quieres repetir? #speaker:BAD COP #portrait1:BC_neutral
+ [Si]
    -> main
+ [No, terminemos]
    Adios, texto de ejemplo 4
    ->END