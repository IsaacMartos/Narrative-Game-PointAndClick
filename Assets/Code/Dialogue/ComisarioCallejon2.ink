
Parece que ya has terminado de inspeccionar la escena.

-> main
=== main ===
¿Sobre qué pista quieres hablar? #speaker:BAD COP #portrait:badcop_neutral
    + [Bolso]
        -> chosen("el bolso")
    + [Carta]
        -> chosen("la carta")
    + [Eso es todo]
        -> ending

=== chosen(weapon) ===
Si, {weapon} es una pista importante#speaker:BAD COP #portrait:badcop_mad
  -> ending
  
=== ending ===
Supongo que esto concluye el analisis de campo
Vamos a la comisaría

-> END
