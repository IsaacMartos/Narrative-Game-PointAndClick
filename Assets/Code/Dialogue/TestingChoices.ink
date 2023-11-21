-> main

=== main ===
Which weapon did you use to kill that asshole? #speaker:BAD COP #portrait:badcop_neutral
    + [Knife]
        -> chosen("knife")
    + [Card]
        -> chosen("card")
    + [Pistol]
        -> chosen("pistol")

=== chosen(weapon) ===
You killed her with that {weapon} litle bastard!#speaker:BAD COP #portrait:badcop_mad

-> END

