//------------------------------
//   DO NOT MODIFY THIS FILE
//------------------------------
module Test

open Expecto
open Assignment

let ``should equal`` y s x = Expect.equal x y s
let ``should be greater`` y s x = Expect.isTrue (lessThan y x) s
let ``shouldn't be greater`` y s x = Expect.isFalse (lessThan y x) s

let tests =
  testList "Tests" [
    testCase "c1" (fun () ->
      Expect.isFalse (areHoursInvalid 11) "11 is a valid hour in 12-hour am/pm clock"
    );
    testCase "c2" (fun () ->
      Expect.isTrue (areHoursInvalid 21) "21 is not a valid hour in 12-hour am/pm clock"
    );
    testCase "c3" (fun () ->
      Expect.isFalse (areMinutesInvalid 21) "21 is a valid minute value"
    );
    testCase "c4" (fun () ->
      Expect.isTrue (areMinutesInvalid 71) "71 is not a valid minute value"
    );
    testCase "t1" (fun () ->
      (time 20 10 PM) |> ``should equal`` (time 12 10 PM) "Incorrect hour value is reset to 12: 20:10PM -> 12:10PM"
    );
    testCase "t2" (fun () ->
      (time 10 70 PM) |> ``should equal`` (time 10 00 PM) "Incorrect minute value is reset to 0: 10:70PM -> 10:00PM"
    );
    testCase "t3" (fun () ->
      (time 20 65 PM) |> ``should equal`` (time 12 00 PM) "Incorrect time value is reset to noon: 20:65PM -> 12:00PM"
    );
    testCase "t4" (fun () ->
      (time 10 11 AM) |> ``should equal`` (time 10 11 AM) "Correct time format"
    );
    testCase "t5" (fun () ->
      (time 10 11 AM) |> ``should be greater`` (time 10 10 AM) "Time comparison: 10:11AM > 10:10AM"
    );
    testCase "t6" (fun () ->
      (time 10 10 AM) |> ``shouldn't be greater`` (time 10 11 AM) "Time comparison: 10:11AM ≮ 10:10AM"
    );
    testCase "t7" (fun () ->
      (time 10 11 PM) |> ``should be greater`` (time 10 10 PM) "Time comparison: 10:11PM > 10:10PM"
    );
    testCase "t8" (fun () ->
      (time 10 10 PM) |> ``shouldn't be greater`` (time 10 11 PM) "Time comparison: 10:11PM ≮ 10:10PM"
    );
    testCase "t9" (fun () ->
      (time 1 15 PM) |> ``should be greater`` (time 11 59 AM) "Time comparison: 1:15PM > 11:59AM"
    );
    testCase "t10" (fun () ->
      (time 1 15 AM) |> ``shouldn't be greater`` (time 11 15 AM) "Time comparison: 11:15AM ≮ 1:15AM"
    );
    testCase "t11" (fun () ->
      (time 11 59 AM) |> ``shouldn't be greater`` (time 11 59 AM) "Time comparison: 11:59AM ≮ 11:59AM"
    );
    testCase "t12" (fun () ->
      (time 11 59 PM) |> ``should be greater`` (time 11 59 AM) "Time comparison: 11:59PM > 11:59AM"
    );
  ]




open System
open Expecto.Impl
open Expecto.Logging
open Expecto.Logging.Message

[<EntryPoint>]
let main args =
  let customFail = { TestPrinters.defaultPrinter with
                        failed = fun n m d ->
                            let lines = m.Split('\n')
                            let res = Array.tryFindIndex (fun (s:string) -> s.Contains("tests.fs")) lines
                            let i = if res.IsNone then 3 else res.Value
                            let newmsg = lines.[0..i] |> Array.fold (fun r s -> r + s + "\n") ""
                            async {
                              do! logger.log LogLevel.Error (
                                    eventX "{testName} failed in {duration}. {message}"
                                    >> setField "testName" n
                                    >> setField "duration" d
                                    >> setField "message" (newmsg.TrimEnd('\n')))
                            }
                    }
  let config = [
    Printer customFail
  ]
  runTestsWithCLIArgs config args tests
