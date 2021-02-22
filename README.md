# Lab 2 : Tuples

## Task

1. Write a function `time` that represents the 12h formatted time as a tuple.
  - If hour value is beyond `[1,12]` range then set hour value to `12`
    - Write an auxiliary function `areHoursInvalid` that checks if an hour value is not valid
  - If minute value is beyond `[0,59]` range then set minute value to `0`
    - Write an auxiliary function `areMinutesInvalid` that checks if a minute value is not valid
2. Write a function `lessThen` compares if time, represented by a first tuple parameter, is less then a second time tuple parameter.

## Test

Press **Run** button to execute and test your program.

- Or run `make test` command in the command line to verify the correctness of your program.

## Submission

- Commit & push all changes that to the corresponding assignment repository on GitHub, using the **Repl.it** interface - **Version control** tab.
  - Make sure that you committed changes to following files:
    - `main.fs`
- Submit the link of the assignment GitHub repository in the corresponding assignment submission the Blackboard.
  - Open corresponding assignment on the Blackboard
  - In **Assignment Submission** section, press **Write Submission** button
  - Paste your assignment repository link in the **Text Submission** box
  - Submit the assignment

### Before You Submit

You are required to test that your submission works properly before submission. Make sure that your program compiles without errors. Once you have verified that the submission is correct, you can submit your work.

### Coding Style

In any programming project, matching the existing coding style is important. Having different coding styles intermixed leads to confusion and bugs. Students are required to follow the particular existing coding style that maintains the indentation style in `.fs` and `.fsx` files using spaces, not tabs.

In particular, pay close attention to function declarations and how the function name begins the line after the function return type. For helper functions which are limited in scope to a specific file, you must declare the function as `static` in the same file in which it is used.

*Indentation*: The indentation style for your work have to be 4 spaces. Many students are taught to use tabs for indentation, which can make code very hard to read, especially when there are several levels of indentation.

For additional information, see [F# style guide](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/) or [A comprehensive guide to F# Formatting Conventions](https://github.com/fsprojects/fantomas/blob/master/docs/FormattingConventions.md)
