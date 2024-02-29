# DescartesEndPointProject

This is a simple and quick project with a few endpoints that you can send data to and then compare the data that has been stored in the dictionary.

## Endpoints

/v1/diff/<ID>/left: Accepts JSON containing base64 encoded binary data for the left side.
/v1/diff/<ID>/right: Accepts JSON containing base64 encoded binary data for the right side.
/v1/diff/<ID>: Provides information about the difference between the left and right data.

## Tests

DataControllerTests: these tests are used for testing the sending of data and checking if the set classes are properly called
DiffControllerTests: these tests are used for checking the difference between 2 sets of data and seeing if it returns the correct difference

## Extra Dependencies

[Moq](https://github.com/Moq/moq4) is a popular mocking library for .NET that helps with creating mock objects for testing purposes. 

To install Moq, add the following package reference to your project:

```bash
dotnet add package Moq