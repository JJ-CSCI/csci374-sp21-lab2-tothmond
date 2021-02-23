module Assignment

type AMPM = AM | PM



// This function checks if an hour value `h` is not in [1,12] range
let areHoursInvalid h = 
  if h > 12 then true
  elif h < 1 then true
  else false

// This function checks if a minute value `m` is not in [0,59] range
let areMinutesInvalid m =
  if m > 59 then true
  elif m < 0 then true
  else false

// This function creates a valid time tuple
//      use above functions: areHoursInvalid & areMinutesInvalid
let time h m ampm :(int * int * AMPM) =
  let mutable x = 0
  let mutable y = 0
  if areHoursInvalid(h) then x <- 12
  else x <- h
  if areMinutesInvalid(m) then y <- 0
  else y <- m

  (x, y, ampm)

// This function compares two times in tuple format
let lessThan (time1: int * int * AMPM) (time2: int * int * AMPM) :bool =
  let x1,x2,x3 = time1
  let y1,y2,y3 = time2
  if (x3 = AM && y3 = PM) then true
  elif (x3 = y3 && x1 < y1) then true
  elif (x3 = y3 && x1 = y1 && x2 < y2) then true
  else false
