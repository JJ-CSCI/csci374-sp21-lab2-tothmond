module Assignment

type AMPM = AM | PM

// This function checks if an hour value `h` is not in [1,12] range
let areHoursInvalid h =
    false

// This function checks if a minute value `m` is not in [0,59] range
let areMinutesInvalid m =
    false

// This function creates a valid time tuple
//      use above functions: areHoursInvalid & areMinutesInvalid
let time h m ampm :(int * int * AMPM) =
    (h, m, ampm)

// This function compares two times in tuple format
let lessThan (time1: int * int * AMPM) (time2: int * int * AMPM) :bool =
    false
