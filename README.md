# Restless OfxSharper
Provides extended Ofx services: parsing of multiple statements, closing statements, financial institution profile info; 
and Ofx request building.

## Main Features
- Build an Ofx request for a financial institution profile (what types of online services it supports) 
and transfrom the response into a usuable object.

- Build an Ofx request for an account statement (or multiple statements) and transform the resulting response. 
Request and response can include account closing statements as well.

## Financial Institution Profile

```c#
var builder = new OfxRequestBuilder();

builder.BuildOfxRequest(() => 
{
    builder.BuildSignOnMessageSet(OfxDataFactory.CreateBank(Bank, true));
    builder.BuildProfileMessageSetRequest();
});
```